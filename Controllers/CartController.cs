
using System.Web.Mvc;

namespace thewayshop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            if (Session["user"] == null) return RedirectToAction("SignIn", "User");
            return View();
        }
    }
}