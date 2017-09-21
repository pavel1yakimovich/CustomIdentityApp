using IdentityApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ClaimsAuthorize(Age = 18)]
        public ActionResult EighteenPlus()
        {
            ViewBag.Message = "18+.";

            return View();
        }
        
        [ClaimsAuthorize(Age = 22)]
        public ActionResult TwentyTwoPlus()
        {
            ViewBag.Message = "22+";

            return View();
        }
    }
}