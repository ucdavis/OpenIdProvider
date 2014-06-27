using System.Web.Mvc;
using System.Web.Security;
using OpenIdProvider.Helpers;

namespace OpenIdProvider.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOn(string returnUrl)
        {
            var actionResult = CasMvc.Login(); //Do the CAS Login

            if (actionResult != null)
            {
                return actionResult;
            }

            TempData["URL"] = returnUrl;

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("https://cas.ucdavis.edu/cas/logout");
        }
    }
}
