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

            return View();
        }
    }
}