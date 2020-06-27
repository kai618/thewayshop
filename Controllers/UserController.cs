using System.Web.Mvc;
using thewayshop.ViewModel;

namespace thewayshop.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager _userMgr = new UserManager();

        [HttpGet]
        public ActionResult SignUp()
        {
            if (Session["user"] != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignupUser user)
        {
            if (!ModelState.IsValid) return View();
            if (_userMgr.SignUp(user))
            {
                Session["user"] = user.UserName;
                return View("Welcome");
            }
            ModelState.AddModelError("unavailable", "The user name or email address has already existed!");
            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            if (Session["user"] != null) return RedirectToAction("Index", "Home");
            if (Request.UrlReferrer != null)
            {
                TempData["previousUrl"] = Request.UrlReferrer.ToString();
            }
                
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInUser user)
        {
            if (!ModelState.IsValid) return View();
            if (_userMgr.SignIn(user))
            {
                Session["user"] = user.UserName;
                if (TempData.ContainsKey("previousUrl")) return Redirect(TempData["previousUrl"].ToString());
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("unavailable", "The user name or email address has already existed!");
            return View();
        }


        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }

        // Testing only
        //public ActionResult Welcome()
        //{
        //    return View();
        //}
    }
}