using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoormatWebSite.Tools;
using IdentitySample.Models;

namespace DoormatWebSite.Controllers
{
    public class PostController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Post
        [Route("Posts")]
        public ActionResult Archive(int pageid = 1)
        {
            int culter = 1;
            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                {
                    culter = 2;
                        break;
                    }
            }
            int skip = (pageid - 1) * 6;
            int Count = db.Post.Count();
            ViewBag.PageID = pageid;
            ViewBag.PageCount = Math.Ceiling(Convert.ToDecimal(Count) / 6);
            var posts = db.Post.Where(p=>p.PostType.Lanid==culter).OrderByDescending(p => p.PostDate).Skip(skip).Take(6).ToList();
            ViewBag.backgrand = xml.loadline("bloggResult/Backgrand");
            return View(posts);
        }

        [Route("Posts/{PostCategory}/{PostTitle}")]
        public ActionResult PostResult(string PostCategory, string PostTitle)
        {
            ViewBag.PostCategory = PostCategory;
            var post = db.Post.Where(p => p.PostTitle.Contains(PostTitle)).SingleOrDefault();
            return View(post);
        }

        public ActionResult RelatedPost(int Category)
        {
            var post = db.Post.Where(p => p.PostTypeID == Category).OrderByDescending(p => p.PostDate).Take(2).ToList();
            return PartialView(post);
        }

        public ActionResult ShowGroupOnSiderBar()
        {
            int culter = 1;
            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culter = 2;
                        break;
                    }
            }

            var groups = db.PostType.Where(p => p.Lanid == culter).ToList();
            return PartialView(groups);
        }

        
        public ActionResult Postsearch(string search, int pageid = 1)
        {
            ViewBag.curentSearch = search;
            ViewBag.backgrand = xml.loadline("bloggResult/Backgrand");
            int skip = (pageid - 1) * 6;
            int Count = db.Post.Count();
            ViewBag.PageID = pageid;
            ViewBag.PageCount = Math.Ceiling(Convert.ToDecimal(Count) / 6);
            var posts = db.Post.Where(p => p.AspNetUsers.UserName == search||p.PostTitle== search||p.PostType.Title== search).OrderByDescending(p => p.PostDate).Skip(skip).Take(6).ToList();
            return View(posts);
        }

        
        public ActionResult LastPost()
        {
            int culter = 1;
            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culter = 2;
                        break;
                    }
            }

            var lastPost = db.Post.Where(p => p.PostType.Lanid == culter).OrderByDescending(p => p.PostDate).Take(5)
                .ToList();
            return PartialView(lastPost);
        }
    }
}