using System;
using System.Collections.Generic;
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
            ViewBag.products = GetShowCaseProduct();

            return View();
        }

        private List<SanPham> GetShowCaseProduct()
        {
            var threshold = DateTime.Today.AddMonths(-2);
            var newProducts =
                _ctx.SanPhams.Where(sp => sp.NgayThemSP > threshold && sp.KhuyenMai == 0).Take(4).ToList();
            newProducts.ForEach(sp => sp.LoaiTrungBay = ShowCaseType.New);

            var saleProducts = _ctx.SanPhams.Where(sp => sp.KhuyenMai > 0).Take(4).ToList();
            saleProducts.ForEach(sp => sp.LoaiTrungBay = ShowCaseType.Sale);

            newProducts.AddRange(saleProducts);

            var ran = new Random();
            var randomisedProducts = new List<SanPham>();
            var length = newProducts.Count;

            for (var i = 0; i < length; i++)
            {
                var index = ran.Next(newProducts.Count);
                randomisedProducts.Add(newProducts[index]);
                newProducts.RemoveAt(index);
            }

            return randomisedProducts;
        }
    }

    public enum ShowCaseType
    {
        New,
        Sale
    }
}