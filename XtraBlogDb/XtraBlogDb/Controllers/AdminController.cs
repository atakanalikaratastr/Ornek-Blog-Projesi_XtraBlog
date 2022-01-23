using NTier.Bussines.Concrete;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XtraBlogDb.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}