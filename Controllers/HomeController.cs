using System;
using System.Linq;
using System.Web.Mvc;
using thewayshop.Models;

namespace thewayshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly eshopContext _ctx = new eshopContext();

        public ActionResult Index()
        {
            ViewBag.types = _ctx.LoaiSanPhams.Take(6).ToList();

            ViewBag.newProducts =
                _ctx.SanPhams.Where(p => p.NgayThemSP > DateTime.Today.AddMonths(-2)).Take(4).ToList();

            ViewBag.saleProducts = _ctx.SanPhams.Where(p => p.KhuyenMai > 0).Take(4).ToList();

            return View();
        }
    }
}