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
using Microsoft.AspNet.Identity;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var post = db.Post.Include(p => p.AspNetUsers).Include(p => p.PostType);
            return View(post.ToList());
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            //ViewBag.AspNetUsersID = new SelectList(db.Users., "Id", "Email");
            ViewBag.PostTypeID = new SelectList(db.PostType, "PostTypeID", "Title");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,PostTitle,PostText,PostTypeID,PostShortDiscription,KeyWord,PostImage")] Post post,HttpPostedFileBase imgupl)
        {
            if (ModelState.IsValid)
            {
                post.PostDate=DateTime.Now;
                post.AspNetUsersID = User.Identity.GetUserId();
                string filename = Guid.NewGuid() + Path.GetExtension(imgupl.FileName);
                imgupl.SaveAs(Server.MapPath("/PageImages/" +filename));
                post.PostImage = filename;
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AspNetUsersID = new SelectList(db.AspNetUsers, "Id", "Email", post.AspNetUsersID);
            ViewBag.PostTypeID = new SelectList(db.PostType, "PostTypeID", "Title", post.PostTypeID);
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AspNetUsersID = new SelectList(db.AspNetUsers, "Id", "Email", post.AspNetUsersID);
            ViewBag.PostTypeID = new SelectList(db.PostType, "PostTypeID", "Title", post.PostTypeID);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,PostTitle,PostText,PostTypeID,PostShortDiscription,PostDate,KeyWord,AspNetUsersID,PostImage")] Post post,HttpPostedFileBase imgupl)
        {
            if (ModelState.IsValid)
            {
                if (imgupl != null)
                {
                    if (post.PostImage !=null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/"+post.PostImage));
                    }

                    post.PostImage = Guid.NewGuid() + Path.GetExtension(imgupl.FileName);
                    imgupl.SaveAs(Server.MapPath("/PageImages/"+post.PostImage));
                }
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AspNetUsersID = new SelectList(db.AspNetUsers, "Id", "Email", post.AspNetUsersID);
            ViewBag.PostTypeID = new SelectList(db.PostType, "PostTypeID", "Title", post.PostTypeID);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Post.Find(id);
            db.Post.Remove(post);
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
