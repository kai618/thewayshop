using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace thewayshop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Shop
        public ActionResult Filter(int typeId)
        {
            return View();
        }
    }
}