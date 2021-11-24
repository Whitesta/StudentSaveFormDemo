using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSaveFormDemo.Controllers
{
    public class CalculateController : Controller
    {
        // GET: Calculate
        public ActionResult Index(double number1=0,double number2=0)
        {
            var plus = number1 + number2;
            ViewBag.pls = plus;
            var minus = number1 - number2;
            ViewBag.mns = minus;
            var divide = number1 / number2;
            ViewBag.dvd = divide;
            var multiply = number1 * number2;
            ViewBag.multy = multiply;
            return View();
        }
    }
}