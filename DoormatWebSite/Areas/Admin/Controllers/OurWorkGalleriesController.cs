using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DoormatWebSite.Models;
using DoormatWebSite.Models.Model;
using IdentitySample.Models;
using PagedList;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    public class OurWorkGalleriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Result(string search, int? page)
        {

            IQueryable<OurWorkGallery> WorkGallerys = db.OurWorkGallery.Include(o => o.OurWorkGalleryType);
            //var ourWorkGallery = db.OurWorkGallery.Include(o => o.OurWorkGalleryType).Include(o => o.ImageSize);
            WorkGallerys = WorkGallerys.OrderBy(c => c.date);
            if (!String.IsNullOrWhiteSpace(search))
            {
                ViewBag.CurrentSearch = search;
                WorkGallerys = WorkGallerys.Where(c => c.Name.Contains(search));
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return PartialView(WorkGallerys.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/OurWorkGalleries
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Admin/OurWorkGalleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurWorkGallery ourWorkGallery = db.OurWorkGallery.Find(id);
            if (ourWorkGallery == null)
            {
                return HttpNotFound();
            }
            return PartialView(ourWorkGallery);
        }

        // GET: Admin/OurWorkGalleries/Create
        public ActionResult Create()
        {
            ViewBag.OurWorkGalleryTypeId = new SelectList(db.OurWorkGalleryType, "OurWorkGalleryTypeid", "Title");
            return PartialView();
        }

        // POST: Admin/OurWorkGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,OurWorkGalleryTypeid,Name,Image,idSize")] OurWorkGallery ourWorkGallery, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    ourWorkGallery.Image = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/PageImages/" + ourWorkGallery.Image));
                }
                ourWorkGallery.date=DateTime.Now;
                db.OurWorkGallery.Add(ourWorkGallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OurWorkGalleryTypeId = new SelectList(db.OurWorkGalleryType, "OurWorkGalleryTypeid", "Title", ourWorkGallery.OurWorkGalleryType);
            return PartialView(ourWorkGallery);
        }

        // GET: Admin/OurWorkGalleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurWorkGallery ourWorkGallery = db.OurWorkGallery.Find(id);
            if (ourWorkGallery == null)
            {
                return HttpNotFound();
            }
            ViewBag.OurWorkGalleryTypeId = new SelectList(db.OurWorkGalleryType, "id", "Title", ourWorkGallery.OurWorkGalleryType);
            return PartialView(ourWorkGallery);
        }

        // POST: Admin/OurWorkGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,OurWorkGalleryTypeid,Name,Image,idSize,date")] OurWorkGallery ourWorkGallery, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (ourWorkGallery.Image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + ourWorkGallery.Image));
                    }


                    ourWorkGallery.Image = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + ourWorkGallery.Image));
                }
                
                db.Entry(ourWorkGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OurWorkGalleryTypeId = new SelectList(db.OurWorkGalleryType, "OurWorkGalleryTypeid", "Title", ourWorkGallery.OurWorkGalleryType);
            return PartialView(ourWorkGallery);
        }

        // GET: Admin/OurWorkGalleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurWorkGallery ourWorkGallery = db.OurWorkGallery.Find(id);
            if (ourWorkGallery == null)
            {
                return HttpNotFound();
            }
            return PartialView(ourWorkGallery);
        }

        // POST: Admin/OurWorkGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurWorkGallery ourWorkGallery = db.OurWorkGallery.Find(id);
            if (ourWorkGallery.Image != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + ourWorkGallery.Image));
            }
            db.OurWorkGallery.Remove(ourWorkGallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
