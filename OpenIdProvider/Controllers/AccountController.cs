using System.Web.Mvc;
using System.Web.Security;
using OpenIdProvider.Helpers;

namespace OpenIdProvider.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOn(string returnUrl)
        {
            return CasMvc.LoginAndRedirect();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("https://cas.ucdavis.edu/cas/logout");
        }
    }
}
