using System.Linq;
using System.Web.Mvc;
using thewayshop.Models;

namespace thewayshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly eshopEntities _ctx = new eshopEntities();

        public ActionResult Index()
        {
            var newProducts = _ctx.SanPhams
                .Where(sp => sp.NgayThemSP > SanPham.threshold && sp.KhuyenMai == 0)
                .OrderByDescending(sp => sp.NgayThemSP)
                .Take(4).ToList();

            var saleProducts = _ctx.SanPhams.Where(sp => sp.KhuyenMai > 0).ToList();
            newProducts.AddRange(Utility.GetRandomElements(saleProducts, 4));


            return View(Utility.GetRandomElements(newProducts, newProducts.Count));
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