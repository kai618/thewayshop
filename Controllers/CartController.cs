using System.Linq;
using System.Web.Mvc;
using thewayshop.Models;

namespace thewayshop.Controllers
{
    public class CartController : Controller
    {
        private readonly eshopEntities _ctx = new eshopEntities();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            if (Session["user"] == null) return RedirectToAction("SignIn", "User");
            var userName = Session["user"].ToString();
            var user = _ctx.KhachHangs.FirstOrDefault(kh => kh.UserName == userName);

            return View(user);
        }
    }
}