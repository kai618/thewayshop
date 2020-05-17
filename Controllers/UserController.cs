using System.Web.Mvc;
using thewayshop.ViewModel;

namespace thewayshop.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult SignUp(SignupUser user)
        {

            return View();
        }
    }
}