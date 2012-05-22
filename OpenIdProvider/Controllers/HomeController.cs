using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCDArch.Core.Utils;

namespace OpenIdProvider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Debug.Assert(Request != null, "Request != null");
            Debug.Assert(Request.AcceptTypes != null, "Request.AcceptTypes != null");

            if (Request.AcceptTypes.Contains("application/xrds+xml"))
            {
                ViewData["OPIdentifier"] = true; //return xrds if this is an openId request
                return View("Xrds");
            }
            
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
