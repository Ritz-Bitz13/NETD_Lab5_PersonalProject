using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleWebAppForDemonstration.Models;


namespace SampleWebAppForDemonstration.Controllers
{
    public class HomeController : Controller
    {

        List<car> carList = new List<car>();
      public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Register(car model)
        {
       

            if (ModelState.IsValid)
            {
                ViewData["Message"] = "Make: " + model.make + "\n Model: " + model.modelName + "\n Year: " + model.year + "\n Kilometers: " + model.kilometers;
                ViewData["Appraisal"] = "This car is valued at: " + model.calcValue(model.year, model.kilometers);

               
              

                return View("Registered", model);


            }
            else
            {
                return View("Bad");
               
            }

            //return Content(message);

        }
    }
}
