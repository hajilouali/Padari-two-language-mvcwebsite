using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;

namespace DoormatWebSite.Areas.Admin.Controllers
{
    public class VideoWarpController : Controller
    {
        // GET: Admin/VideoWarp
        public ActionResult Index()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Server.MapPath("/App_Data/PageContent/Content.xml"));
            ViewBag.backgrand = xmlDocument.SelectSingleNode("/Root/videoWarp/backgrand").InnerText;
            ViewBag.videoImage = xmlDocument.SelectSingleNode("/Root/videoWarp/videoImage").InnerText;
            ViewBag.VideoURL = xmlDocument.SelectSingleNode("/Root/videoWarp/VideoURL").InnerText;
            ViewBag.URLbutten = xmlDocument.SelectSingleNode("/Root/videoWarp/URLbutten").InnerText;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase imguplbackgrand, HttpPostedFileBase imguplVideo,string URL, HttpPostedFileBase vidupl,string URLbutten)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Server.MapPath("/App_Data/PageContent/Content.xml"));
            if (imguplbackgrand !=null)
            {
                if (xmlDocument.SelectSingleNode("/Root/videoWarp/backgrand").InnerText !=null)
                {
                    System.IO.File.Delete(Server.MapPath("/PageImages/"+ xmlDocument.SelectSingleNode("/Root/videoWarp/backgrand").InnerText));
                }

                string fileName = Guid.NewGuid() + Path.GetExtension(imguplbackgrand.FileName);
                xmlDocument.SelectSingleNode("/Root/videoWarp/backgrand").InnerText = fileName;
                imguplbackgrand.SaveAs(Server.MapPath("/PageImages/" + fileName));
            }
            if (imguplVideo != null)
            {
                if (xmlDocument.SelectSingleNode("/Root/videoWarp/videoImage").InnerText != null)
                {
                    System.IO.File.Delete(Server.MapPath("/PageImages/" + xmlDocument.SelectSingleNode("/Root/videoWarp/videoImage").InnerText));
                }

                string fileName = Guid.NewGuid() + Path.GetExtension(imguplVideo.FileName);
                xmlDocument.SelectSingleNode("/Root/videoWarp/videoImage").InnerText =  fileName;
                imguplVideo.SaveAs(Server.MapPath("/PageImages/" + fileName));
            }

            if (vidupl !=null)
            {
                if (xmlDocument.SelectSingleNode("/Root/videoWarp/VideoURL").InnerText.Contains("PageImages"))
                {
                    System.IO.File.Delete(Server.MapPath(xmlDocument.SelectSingleNode("/Root/videoWarp/VideoURL").InnerText));
                }
                string fileName = Guid.NewGuid() + Path.GetExtension(vidupl.FileName);
                xmlDocument.SelectSingleNode("/Root/videoWarp/VideoURL").InnerText = "/PageImages/" + fileName;
                vidupl.SaveAs(Server.MapPath("/PageImages/" + fileName));
            }
            else
            {
                xmlDocument.SelectSingleNode("/Root/videoWarp/VideoURL").InnerText = URL;
            }

            xmlDocument.SelectSingleNode("/Root/videoWarp/URLbutten").InnerText = URLbutten;
            xmlDocument.Save(Server.MapPath("/App_Data/PageContent/Content.xml"));
            return RedirectToAction("Index");
        }
    }
}