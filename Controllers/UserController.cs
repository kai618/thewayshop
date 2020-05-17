using System;
using System.Web.Mvc;
using thewayshop.Models;
using thewayshop.ViewModel;

namespace thewayshop.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager _userMgr = new UserManager();

        [HttpGet]
        public ActionResult SignUp()
        {
            if (Session["user"] != null) RedirectToAction("Index", "Home");
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


            ModelState.AddModelError("unavailable",
                "The user name or email address has already existed!");
            return View();
        }

        // Testing only
        //public ActionResult Welcome()
        //{
        //    return View();
        //}
    }
}