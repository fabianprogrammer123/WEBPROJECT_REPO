using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WEBPAGE_PROJECT.Controllers
{
    public class DownloadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult DownloadFile()
        {
            // S/C
            // string path = @"D:\Uploaded_Files\";
            string path = @"C:\Users\EmileMesselken\Desktop\Powerpoint-Project\Insert_pictures_here\";

            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "OpenXML_PP.pptx");
            string fileName = "PowerPoint.pptx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}