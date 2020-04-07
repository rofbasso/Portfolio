using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;
using Calculator.Models.ViewModels;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {      

        public IActionResult Index()
        {
            
            return RedirectToAction("../CalculatorOps/Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Hello, my name is Rodrigo Basso and I did this project to practice and develop my skills in .Net";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Where to find me";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
