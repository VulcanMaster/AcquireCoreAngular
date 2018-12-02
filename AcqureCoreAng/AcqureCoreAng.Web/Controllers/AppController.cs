using AcqureCoreAng.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcqureCoreAng.Web.Services;

namespace AcqureCoreAng.Web.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            this._mailService = mailService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            //throw new InvalidOperationException("Bad things happened.");
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            //throw new InvalidOperationException("Bad things happen");
            //throw new InvalidOperationException("Bad things happened.");
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // send email
                _mailService.SendMessage(model.Email, model.Subject, model.Message);
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                // show error
            }
            return View();

        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            //throw new InvalidOperationException("Bad things happened.");
            return View();
        }

    }
}
