using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models;
using Test2.Services;
using Test2.ViewModels;

namespace Test2.Controllers
{
    public class AppController:Controller
    {
        private readonly IMailService _mailService;
        private readonly IProtoRepository _repository;

        public AppController(IMailService mailService,IProtoRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var results = _repository.GetAllProducts();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            ViewBag.Title = "Contact Us";
            if(ModelState.IsValid)
            {
                //send the email
                _mailService.SendMessage("ahmedabdelwasaa@outlook.com",model.Subject,$"From:{model.Name} - {model.Email},Massage:{model.Message}");
                ViewBag.UserMessage = "Mail Sent ";
                ModelState.Clear();
            }
            else
            {
                // nothing todo
            }
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }


        public IActionResult Shop()
        {

            var res = _repository.GetAllProducts();
            return View(res);
        }
    }
}
