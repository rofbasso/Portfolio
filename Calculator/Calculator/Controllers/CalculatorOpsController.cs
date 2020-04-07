using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Models;
using Calculator.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorOpsController : Controller
    {

        public IActionResult Index(double num1, double num2, string button)
        {
            try
            {
                CalculatorOp calc = new CalculatorOp(num1, num2);

                ViewData["op"] = button;
                ViewData["num1"] = num1;
                ViewData["num2"] = num2;

                calc.Resultado(num1, num2, button);

                return View(calc);
            }
            catch (DivideByZeroException e)
            {
                throw new DivideByZeroException(e.Message);
            }
        }
                
    }
}