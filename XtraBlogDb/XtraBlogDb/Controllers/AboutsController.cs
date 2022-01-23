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
    public class AboutsController : Controller
    {
        //private NTier_Context db = new NTier_Context();
        AboutManager aboutManager = new AboutManager(new EfAboutDAL());
        [Authorize]
        // GET: Abouts
        public ActionResult Index()
        {
            return View(aboutManager.GetAboutList());
        }

        // GET: Abouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutManager.GetAboutByAboutId(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // GET: Abouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file,[Bind(Include = "AboutId,AboutText,Image,Background,Teamwork,OurCoreValue")] About about)
        {
            string ResimAdi;
            string adres;
            if (file != null)
            {
                ResimAdi = System.IO.Path.GetFileName(file.FileName);
                adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);

                about.Image = ResimAdi;
            }
            if (ModelState.IsValid)
            {
                aboutManager.Add(about);
                return RedirectToAction("Index");
            }

            return View(about);
        }

        // GET: Abouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutManager.GetAboutByAboutId(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "AboutId,AboutText,Image,Background,Teamwork,OurCoreValue")] About about)
        {
            string ResimAdi;
            string adres;
            var blogGet = aboutManager.GetAboutByAboutId(about.AboutId);
            string onceki = blogGet.Image;
            if (file != null)
            {
                ResimAdi = System.IO.Path.GetFileName(file.FileName);
                adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);

                about.Image = ResimAdi;
            }
            else
            {
                about.Image = onceki;
            }
            if (ModelState.IsValid)
            {
                aboutManager.Update(about);
                return RedirectToAction("Index");
            }
            return View(about);
        }

        // GET: Abouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = aboutManager.GetAboutByAboutId(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About about = aboutManager.GetAboutByAboutId(id);
            aboutManager.Delete(about);
            return RedirectToAction("Index");
        }
    }
}
