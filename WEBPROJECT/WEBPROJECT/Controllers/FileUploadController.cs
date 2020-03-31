using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBPAGE_PROJECT.Controllers
{
    public class FileUploadController : Controller
    {

        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            int counter = 0;

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                counter++;

                if (formFile.Length > 0)
                {
                    // S/C
                    //var filePath = @"D:\Uploaded_Files\pic" + counter.ToString() + ".jpg";
                    var filePath = @"C:\Users\EmileMesselken\Desktop\Powerpoint-Project\Insert_pictures_here\pic" + counter.ToString() + ".jpg";
                    filePaths.Add(filePath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            // PP Creation

            Open_XML_Project.Create_PP obj = new Open_XML_Project.Create_PP();
            obj.Create_PP_action();

            // Redirect to Download

            return RedirectToAction("Index", "Download");
        }
    }
}