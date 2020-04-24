using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;



namespace DoormatWebSite.Tools
{
    public static class xml
    {
        public static string loadline(string Route)
        {
            XmlDocument xmlDocument=new XmlDocument();
            xmlDocument.Load(HttpContext.Current.Server.MapPath("/App_Data/PageContent/Content.xml"));
            string result = xmlDocument.SelectSingleNode("/Root/"+Route).InnerText;
            return result;
        }

        public static bool SavetoXml(string Route, string text)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("/App_Data/PageContent/Content.xml");
                xmlDocument.SelectSingleNode("/Root/" + Route).InnerText = text;
                xmlDocument.Save("/App_Data/PageContent/Content.xml");
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}