using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HttpRequests.Controllers
{
    public class HomeController : Controller
    {
        private string requestType;
        private string ipAddress;
        private string url;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
     
        private void getInformationAboutRequest()
        {
              requestType = HttpContext.Request.HttpMethod;
              if (!String.IsNullOrEmpty(HttpContext.Request.ServerVariables["HTTP_CLIENT_IP"]))
                  ipAddress = HttpContext.Request.ServerVariables["HTTP_CLIENT_IP"];
              else
                  ipAddress = HttpContext.Request.ServerVariables["REMOTE_ADDR"];
              //Get the url of the current request
               url = HttpContext.Request.Url.AbsoluteUri;

              SaveInformationToFile();
        }
        [HttpGet]
        public ActionResult HandleGetRequest()
        {
            getInformationAboutRequest();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult HandlePostRequest()
        {
            getInformationAboutRequest();
            return RedirectToAction("Index", "Home");
        }
 
        [HttpPut]
        public JsonResult Put(int id)
        {
            getInformationAboutRequest();
            return Json("Response from HomeController");
        }
       
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            getInformationAboutRequest();
            return Json("Response from HomeController");
        }
        private void SaveInformationToFile()
        {
            string path = Server.MapPath("~/App_Data/informationRequests.txt"); 
 
            // This text is added only once to the file.
            if (!System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine(requestType);
                    sw.WriteLine(ipAddress);
                    sw.WriteLine(url);
                }
                return;
            }
            //Append lines to file 
            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine("************************************************************");
                sw.WriteLine(requestType);
                sw.WriteLine(ipAddress);
                sw.WriteLine(url);
            }
        }
    }
}