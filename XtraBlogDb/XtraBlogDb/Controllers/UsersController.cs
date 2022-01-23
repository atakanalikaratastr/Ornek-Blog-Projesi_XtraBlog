using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NTier.Bussines.Concrete;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;

namespace XtraBlogDb.Controllers
{
    public class UsersController : Controller
    {
        //NTier_Context db = new NTier_Context();
        UserManager userManager = new UserManager(new EfUserDAL(), new TitleManager(new EfTitleDAL()));
        TitleManager TitleManager = new TitleManager(new EfTitleDAL());
        //ViewModel viewModel = new ViewModel();
        [Authorize]
        // GET: Users
        public ActionResult Index()
        {

            return View(userManager.GetUserDetails());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userManager.GetUserByUserId(id);
            ViewBag.TitleName = TitleManager.GetTitleByTitleId(user.TitleId).Name.ToString();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from i in TitleManager.GetTitleList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.TitleId.ToString()
                                           }).ToList();
            ViewBag.TitleList = deger1;
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,TitleId,Name,Surname,Mail,Password,Statement")] User user, string tagName)
        {
            if (ModelState.IsValid)
            {
                int titleId = Convert.ToInt32(tagName);
                user.TitleId = titleId;
                userManager.Add(user);
                return RedirectToAction("Index");
            }

            //ViewBag.TitleList = new SelectList(viewModel.Title, "TitleId", "Name", user.TitleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<SelectListItem> deger1 = (from i in TitleManager.GetTitleList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.TitleId.ToString()
                                           }).ToList();
            ViewBag.TitleList = deger1;
            User user = userManager.GetUserByUserId(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,TitleId,Name,Surname,Mail,Password,Statement")] User user)
        {
            if (ModelState.IsValid)
            {
                userManager.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userManager.GetUserByUserId(id);
            ViewBag.TitleName = TitleManager.GetTitleByTitleId(user.TitleId).Name.ToString();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = userManager.GetUserByUserId(id);
            userManager.Delete(user);
            return RedirectToAction("Index");
        }
    }
}
