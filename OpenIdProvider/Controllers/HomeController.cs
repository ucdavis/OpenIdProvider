using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace OpenIdProvider.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 86400, VaryByParam = "none", VaryByHeader = "accept", Location = OutputCacheLocation.Any)]
        public ActionResult Index()
        {
            Debug.Assert(Request != null, "Request != null");
            Debug.Assert(Request.AcceptTypes != null, "Request.AcceptTypes != null");

            if (Request.AcceptTypes.Contains("application/xrds+xml", StringComparer.OrdinalIgnoreCase))
            {
                ViewBag.OpIdentifier = true; //return xrds if this is an openId request
                ControllerContext.HttpContext.Response.ContentType = "application/xrds+xml";
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
