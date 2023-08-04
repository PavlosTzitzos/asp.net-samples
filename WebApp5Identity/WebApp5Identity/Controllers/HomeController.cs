using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace WebApp5Identity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var user = HttpContext.User as ClaimsPrincipal;
            if (!user.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                ViewBag.Message = "Cannot detect the Age - Claim is absent.";
                return View();
            }

            int minAge = 16;
            var dateOfBirth = Convert.ToDateTime(user.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

            if (calculateAge(dateOfBirth) >= minAge)
            {
                ViewBag.Message = "You can view this page.";
            }
            else
            {
                ViewBag.Message = "Your cannot view this page - your age is bellow permitted one.";
            }

            return View();
        }

        private int calculateAge(DateTime dateOfBirth)
        {
            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
            {
                calculatedAge--;
            }
            return calculatedAge;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

