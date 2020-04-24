using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoormatWebSite.Models;
using DoormatWebSite.Models.Model;
using IdentitySample.Models;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    public class SlidersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        // GET: Admin/Sliders
        public ActionResult Index()
        {
            var slider = db.Slider.Include(s => s.languageType);
            return View(slider.ToList());
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            ViewBag.Lanid = new SelectList(db.languageType, "Lanid", "Type");
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderID,Image,Title,SubTitle,Subtitle1,Subtitle2,Lanid")] Slider slider,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    slider.Image = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/PageImages/" + slider.Image));
                }
                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lanid = new SelectList(db.languageType, "Lanid", "Type", slider.Lanid);
            return View(slider);
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type", slider.languageType);
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderID,Image,Title,SubTitle,Subtitle1,Subtitle2,Lanid")] Slider slider, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (slider.Image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + slider.Image));
                    }


                    slider.Image = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + slider.Image));
                }
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.languageType = new SelectList(db.languageType, "Lanid", "Type", slider.languageType);
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Slider.Find(id);
            if (slider.Image != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + slider.Image));
            }
            db.Slider.Remove(slider);
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
