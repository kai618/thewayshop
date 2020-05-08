using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thewayshop.Models;

namespace thewayshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly eshopEntities _ctx = new eshopEntities();

        // GET: Shop
        public ActionResult Filter(string typeId)
        {
            ViewBag.selectedType = typeId;
            ViewBag.products = _ctx.SanPhams.Where(s => s.MaLoaiSP == typeId).ToList();

            return View();
        }

        public ActionResult Search(string keyword)
        {
            ViewBag.products = _ctx.SanPhams.Where(s => s.TenSP.Contains(keyword));

            return View("Filter");
        }
    }
}