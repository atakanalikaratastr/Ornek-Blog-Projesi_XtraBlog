using NTier.Bussines.Concrete;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace XtraBlogDb.Controllers
{
    public class SecurityController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDAL(), new TitleManager(new EfTitleDAL()));
        TitleManager titleManager = new TitleManager(new EfTitleDAL());
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {

            var userLoginControl = userManager.GetUserList().FirstOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);
            if (userLoginControl != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                //HttpCookie cookieUserName = new HttpCookie("userName", user.Name);
                //Response.Cookies.Add(cookieUserName);
                Session["UserId"] = userLoginControl.UserId;
                Session["UserTitle"] = titleManager.GetTitleByTitleId(userLoginControl.TitleId).Name;
                Session["UserName"] = userLoginControl.Name;
                Session["UserSurName"] = userLoginControl.Surname;
                Session["Statment"] = userLoginControl.Statement;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Message = "Geçersiz Kullanıcı";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}