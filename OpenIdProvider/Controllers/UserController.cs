using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenIdProvider.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Identity(string id)
        {
            var redirect = RedirectIfNotNormalizedRequestUri(id);
            if (redirect != null)
            {
                return redirect;
            }
            
            if (Request.AcceptTypes != null && Request.AcceptTypes.Contains("application/xrds+xml"))
            {
                return View("Xrds");
            }

            ViewData["username"] = id;

            return View();
        }

        public ActionResult Xrds(string id)
        {
            return View();
        }

        private ActionResult RedirectIfNotNormalizedRequestUri(string user)
        {
            Uri normalized = Models.User.GetClaimedIdentifierForUser(user);
            if (Request.Url != normalized)
            {
                return Redirect(normalized.AbsoluteUri);
            }

            return null;
        }
    }
}