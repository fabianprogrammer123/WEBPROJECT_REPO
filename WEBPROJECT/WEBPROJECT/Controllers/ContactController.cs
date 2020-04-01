using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBPAGE_PROJECT.ViewModel;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace WEBPAGE_PROJECT.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("../ContactView");
        }
        [HttpPost]

        public IActionResult Index(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);

                    msz.To.Add("emile33333@gmail.com");
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("emile33333@gmail.com", "");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us!";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $"Sorry, we have a problem here: {ex.Message}";
                }
            }

            return View("../ContactView");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}