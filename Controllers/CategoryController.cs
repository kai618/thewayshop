using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thewayshop.Models;
using thewayshop.ViewModel;

namespace thewayshop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly eshopContext _ctx = new eshopContext();

        // GET: Category
        [ChildActionOnly]
        public ActionResult HomePage()
        {
            var types = _ctx.LoaiSanPhams.Take(6).ToList();
            return PartialView(types);
        }

        [ChildActionOnly]
        public ActionResult DropDownMenu()
        {
            var typeGroups = new List<TypeGroup>();
            
            var groups = _ctx.NhomLoaiSanPhams.ToList();
            groups.ForEach(g => typeGroups.Add(new TypeGroup
            {
                Group = g,
                Types = _ctx.LoaiSanPhams.Where(t => t.MaNhom == g.MaNhom).ToList()
            }));


            return PartialView(typeGroups);
        }
    }
}