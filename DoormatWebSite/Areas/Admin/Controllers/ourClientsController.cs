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
    public class ourClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ourClients
        public ActionResult Index()
        {
            return View(db.ourClients.ToList());
        }

        // GET: Admin/ourClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ourClients ourClients = db.ourClients.Find(id);
            if (ourClients == null)
            {
                return HttpNotFound();
            }
            return View(ourClients);
        }

        // GET: Admin/ourClients/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/ourClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Image")] ourClients ourClients, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    ourClients.Image = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/PageImages/" + ourClients.Image));
                }
                db.ourClients.Add(ourClients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(ourClients);
        }

        // GET: Admin/ourClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ourClients ourClients = db.ourClients.Find(id);
            if (ourClients == null)
            {
                return HttpNotFound();
            }
            return PartialView(ourClients);
        }

        // POST: Admin/ourClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Image")] ourClients ourClients, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (ourClients.Image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + ourClients.Image));
                    }


                    ourClients.Image = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + ourClients.Image));
                }
                db.Entry(ourClients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(ourClients);
        }

        // GET: Admin/ourClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ourClients ourClients = db.ourClients.Find(id);
            if (ourClients == null)
            {
                return HttpNotFound();
            }
            return PartialView(ourClients);
        }

        // POST: Admin/ourClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ourClients ourClients = db.ourClients.Find(id);
            if (ourClients.Image != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + ourClients.Image));
            }
            db.ourClients.Remove(ourClients);
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
