using System.Linq;
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
            ViewBag.products = _ctx.SanPhams.Where(s => s.TenSP.ToLower().Contains(keyword.ToLower())).ToList();

            return View("Filter");
        }

        public ActionResult Details(int id)
        {
            var product = _ctx.SanPhams.FirstOrDefault(s => s.MaSP == id);

            var sameTypeProducts = _ctx.SanPhams.Where(s => s.MaLoaiSP == product.MaLoaiSP).ToList();

            ViewBag.recProducts = Utility.GetRandomElements(sameTypeProducts, 5);

            return View(product);
        }
    }
}