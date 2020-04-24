using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml;
using DoormatWebSite.Models;
using DoormatWebSite.Models.Model;
using IdentitySample.Models;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    public class PlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Plans
        public ActionResult Index()
        {
            var plan = db.Plan.Include(p => p.languageType);
            return View(plan.ToList());
        }

        // GET: Admin/Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Admin/Plans/Create
        public ActionResult Create()
        {
            ViewBag.LanCode = new SelectList(db.languageType, "Lanid", "Type");
            return PartialView();
        }

        // POST: Admin/Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Icon,Title,Discription,Subtitle,Lanid")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Plan.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanCode = new SelectList(db.languageType, "Lanid", "Type", plan.languageType);
            return PartialView(plan);
        }

        // GET: Admin/Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanCode = new SelectList(db.languageType, "Lanid", "Type", plan.languageType);
            return PartialView(plan);
        }

        // POST: Admin/Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Icon,Title,Discription,Subtitle,Lanid")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanCode = new SelectList(db.languageType, "Lanid", "Type", plan.languageType);
            return PartialView(plan);
        }

        // GET: Admin/Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return PartialView(plan);
        }

        // POST: Admin/Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plan.Find(id);
            db.Plan.Remove(plan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PlanSetting()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("/App_Data/PageContent/Content.xml"));
            ViewBag.backgrand = xml.SelectSingleNode("/Root/plan/backgrandplan").InnerText;
            ViewBag.Url= xml.SelectSingleNode("/Root/plan/urlplan").InnerText;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlanSetting(string URL, HttpPostedFileBase imgupl)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("/App_Data/PageContent/Content.xml"));
            xml.SelectSingleNode("/Root/plan/urlplan").InnerText = URL;
            if (imgupl != null)
            {
                if (xml.SelectSingleNode("/Root/plan/backgrandplan").InnerText!=null)
                {
                    System.IO.File.Delete(Server.MapPath("/PageImages/" + xml.SelectSingleNode("/Root/plan/backgrandplan").InnerText));
                }
                string filename = Guid.NewGuid() + Path.GetExtension(imgupl.FileName);
                xml.SelectSingleNode("/Root/plan/backgrandplan").InnerText = filename;
                imgupl.SaveAs(Server.MapPath("/PageImages/" + filename));
            }
            xml.Save(Server.MapPath("/App_Data/PageContent/Content.xml"));
            return RedirectToAction("PlanSetting");
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
