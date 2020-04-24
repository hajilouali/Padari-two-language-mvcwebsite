using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Xml;
using DoormatWebSite.Models;
using DoormatWebSite.Models.Model;
using DoormatWebSite.Tools;
using Newtonsoft.Json;
using PagedList;
using IdentitySample.Models;

namespace IdentitySample.Controllers
{

    public class HomeController : Controller
    {
        
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult Index()
        {

            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        ViewBag.SiteName = xml.loadline("siteSetting/sitenameFarsi");
                        ViewBag.Discription = xml.loadline("siteSetting/sitediscriptionFarsi");
                        ViewBag.KeyWord = xml.loadline("siteSetting/sitekeywordsFarsi");
                        break;
                    }
                case "en-US":

                    ViewBag.SiteName = xml.loadline("siteSetting/siteName");
                    ViewBag.Discription = xml.loadline("siteSetting/siteDiscription");
                    ViewBag.KeyWord = xml.loadline("siteSetting/sitekeywords");
                    break;
            }
            return View();
        }


        [HttpPost]
        public ActionResult Index(string Name, string Email, string Message, FormCollection form)
        {
            string urlToPost = "https://www.google.com/recaptcha/api/siteverify";
            string secretKey = "6LcrI3oUAAAAAH4GFEN1SAYFSbwOfdLW0VXiFeM8"; // change this
            string gRecaptchaResponse = form["g-recaptcha-response"];

            var postData = "secret=" + secretKey + "&response=" + gRecaptchaResponse;

            // send post data
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToPost);
            request.Method = "POST";
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
            }

            // receive the response now
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            // validate the response from Google reCaptcha
            var captChaesponse = JsonConvert.DeserializeObject<reCaptchaResponse>(result);
            if (!captChaesponse.Success)
            {
                ViewBag.Message = "Sorry, please validate the reCAPTCHA";
                ViewBag.IsSuccess = false;
                return View();

            }

            try
            {
                string messagesend = string.Format("from:" + Name + "/n" + Message);
                ViewBag.Message = Mail.SendEmail("hajilouali@gmail.com", "Info@padari.ir", "ارسال تماس باما", messagesend);
                ViewBag.IsSuccess = true;
            }
            catch
            {
                ViewBag.Message = "error send Message";
                ViewBag.IsSuccess = false;
            }


            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Header()
        {
            ViewBag.Number1 = xml.loadline("contact/phonenumber1");
            ViewBag.number2 = xml.loadline("contact/phonenumber2");
            ViewBag.mobile = xml.loadline("contact/Mobile");
            ViewBag.Facebook = xml.loadline("contact/FacebookUrl");
            ViewBag.Instagram = xml.loadline("contact/instagramurl");
            ViewBag.Telegram = xml.loadline("contact/telegramurl");
            ViewBag.googleplus = xml.loadline("contact/GooglePlus");
            ViewBag.logo = xml.loadline("siteSetting/logo");
            return PartialView();
        }

        public ActionResult Slider()
        {
            int culture = 1;


            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culture = 2;
                        break;
                    }
            }

            var sliders = db.Slider.Where(a => a.Lanid == culture).Include(a => a.languageType).ToList();
            return PartialView(sliders);
        }

        public ActionResult ourservices()
        {
            int culture = 1;


            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culture = 2;
                        break;
                    }
            }

            var ourservice = db.OurService.Where(p => p.Lanid == culture).Include(p => p.languageType).ToList();
            return PartialView(ourservice);
        }

        public ActionResult portfolio()
        {
            XmlDocument xldoc = new XmlDocument();
            xldoc.Load(Server.MapPath("/App_Data/PageContent/Content.xml"));
            ViewBag.BackGrand = xldoc.SelectSingleNode("/Root/portfolio/Backgrand").InnerText;
            return View();
        }

        public ActionResult ourCustomer()
        {
            int culture = 1;


            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culture = 2;
                        break;
                    }
            }
            List<string> cList = new List<string>();
            foreach (var VARIABLE in db.ourClients.ToList())
            {
                cList.Add(VARIABLE.Image);
            }

            ViewBag.cList = cList;
            var ourservice = db.ourClientsText.Where(p => p.Lanid == culture).Include(p => p.languageType).ToList();
            return PartialView(ourservice);
        }

        public ActionResult PlanResult()
        {
            int culture = 1;


            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culture = 2;
                        break;
                    }
            }
            var plan = db.Plan.Where(p => p.Lanid == culture).ToList();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Server.MapPath("/App_Data/PageContent/Content.xml"));
            ViewBag.Backgrand = xmlDocument.SelectSingleNode("/Root/plan/backgrandplan").InnerText;
            ViewBag.URL = xmlDocument.SelectSingleNode("/Root/plan/urlplan").InnerText;
            return PartialView(plan);
        }

        public ActionResult MarketInfo()
        {
            return PartialView();
        }

        public ActionResult VideoWarp()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("/App_Data/PageContent/Content.xml"));
            ViewBag.backgrand = xml.SelectSingleNode("/Root/videoWarp/backgrand").InnerText;
            ViewBag.videoImage = xml.SelectSingleNode("/Root/videoWarp/videoImage").InnerText;
            ViewBag.VideoURL = xml.SelectSingleNode("/Root/videoWarp/VideoURL").InnerText;
            ViewBag.URLbutten = xml.SelectSingleNode("/Root/videoWarp/URLbutten").InnerText;
            return PartialView();
        }

        public ActionResult BlogResult()
        {
            int culture = 1;
            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culture = 2;
                        break;
                    }

            }

            var lastpost = db.Post.Where(p => p.PostType.Lanid == culture).Include(p => p.AspNetUsers)
                .Include(p => p.PostType).OrderByDescending(p => p.PostDate).Take(3).ToList();
            return PartialView(lastpost);
        }

        public ActionResult CuntactUS()
        {
            int culture = 1;


            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culture = 2;
                        break;
                    }
            }

            var Offices = db.Partner.Where(p => p.Lanid == culture && p.BranchOffice == true)
                .Include(p => p.LanguageType).ToList();
            return PartialView(Offices);
        }

        public ActionResult FoteResult()
        {
            ViewBag.logo = xml.loadline("siteSetting/logo");
            ViewBag.Number1 = xml.loadline("contact/phonenumber1");
            ViewBag.number2 = xml.loadline("contact/phonenumber2");
            ViewBag.mobile = xml.loadline("contact/Mobile");
            ViewBag.Facebook = xml.loadline("contact/FacebookUrl");
            ViewBag.Instagram = xml.loadline("contact/instagramurl");
            ViewBag.Telegram = xml.loadline("contact/telegramurl");
            ViewBag.googleplus = xml.loadline("contact/GooglePlus");
            int culture = 0;
            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        ViewBag.address = xml.loadline("contact/addressFa");
                        ViewBag.aboutus = xml.loadline("footer/aboutUsFa");
                        culture = 2;
                        break;
                    }
                case "en-US":
                    {
                        ViewBag.address = xml.loadline("contact/addressEn");
                        ViewBag.aboutus = xml.loadline("footer/aboutUs");
                        culture = 1;
                        break;
                    }
            }

            var lastPost = db.Post.Where(p => p.PostType.Lanid == culture).Include(p => p.AspNetUsers)
                .Include(p => p.PostType).OrderByDescending(p => p.PostDate).Take(3).ToList();


            return PartialView(lastPost);
        }

        public ActionResult copywrite()
        {
            return PartialView("CopyWrite");
        }

        public ActionResult PortfolioResult(string search, int? page)
        {

            int culture = 1;
            IQueryable<OurWorkGallery> WorkGallerys = db.OurWorkGallery.Include(o => o.OurWorkGalleryType);
            WorkGallerys = WorkGallerys.OrderBy(c => c.date);
            if (!string.IsNullOrWhiteSpace(search))
            {
                ViewBag.CurrentSearch = search;
                WorkGallerys = WorkGallerys.Where(c => c.OurWorkGalleryType.Title.Contains(search));
            }

            WorkGallerys = WorkGallerys.Where(c => c.OurWorkGalleryType.Lanid == culture);
            ViewBag.CuntportfolioTitleAll = "All";
            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR":
                    {
                        culture = 2;
                        ViewBag.CuntportfolioTitleAll = "همه";
                        WorkGallerys = WorkGallerys.Where(c => c.OurWorkGalleryType.Lanid == culture);
                        break;
                    }
            }

            ViewBag.CuntportfolioTitle = db.OurWorkGalleryType.Where(c => c.Lanid == culture).Count();
            List<string> titeList = new List<string>();

            foreach (var VARIABLE in db.OurWorkGalleryType.Where(c => c.Lanid == culture))
            {
                titeList.Add(VARIABLE.Title);
            }



            ViewBag.titeList = titeList;
            int pageSize = 12;
            int pageNumber = page ?? 1;
            return PartialView(WorkGallerys.ToPagedList(pageNumber, pageSize));
        }

    }
}
