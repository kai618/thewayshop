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
            ViewBag.products = GetShowcaseProducts();

            return View();
        }

        private List<SanPham> GetShowcaseProducts()
        {
            var ran = new Random();

            var newProducts = _ctx.SanPhams
                .Where(sp => sp.NgayThemSP > SanPham.threshold && sp.KhuyenMai == 0)
                .OrderByDescending(sp => sp.NgayThemSP)
                .Take(4).ToList();

            // fetch all sale products
            var saleProducts = _ctx.SanPhams.Where(sp => sp.KhuyenMai > 0).ToList();
            // add 4 random sale products to newProducts
            for (var i = 0; i < 4; i++)
            {
                var product = saleProducts[ran.Next(saleProducts.Count)];
                newProducts.Add(product);
                saleProducts.Remove(product);
            }


            var randomisedProducts = new List<SanPham>();
            for (int i = 0, length = newProducts.Count; i < length; i++)
            {
                var index = ran.Next(newProducts.Count);
                randomisedProducts.Add(newProducts[index]);
                newProducts.RemoveAt(index);
            }

            return randomisedProducts;
        }
    }
}


//public static DateTime threshold = DateTime.Today.AddMonths(-1);
//public ShowcaseType LayLoaiTrungBay()
//{
//if (NgayThemSP > threshold) return ShowcaseType.New;
//else if (KhuyenMai > 0) return ShowcaseType.Sale;
//return ShowcaseType.Normal;
//}
//}
//}

//public enum ShowcaseType
//{
//New,
//Sale,
//Normal
//}