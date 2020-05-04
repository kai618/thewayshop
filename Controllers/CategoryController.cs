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
        private readonly eshopEntities _ctx = new eshopEntities();

        // GET: Category
        [ChildActionOnly]
        public ActionResult HomePage()
        {
            var types = _ctx.LoaiSanPhams.ToList();


            return PartialView(Utility.GetRandomElements(types, 6));
        }

        [ChildActionOnly]
        public ActionResult DropDownMenu()
        {
            var typeGroups = new List<TypeGroup>();

            var groups = _ctx.NhomLoaiSanPhams.ToList();
            groups.ForEach(g => typeGroups.Add(new TypeGroup
            {
                Name = g.TenNhom,
                Types = _ctx.LoaiSanPhams
                    .Where(t => t.MaNhom == g.MaNhom)
                    .Select(t => new TypeInfo()
                    {
                        Id = t.MaLoaiSP,
                        Name = t.TenLoaiSP,
                    })
                    .ToList()
            }));

            return PartialView(typeGroups);
        }

        [ChildActionOnly]
        public ActionResult ProductPage(string typeId)
        {
            ViewBag.selectedType = typeId;

            var typeGroups = new List<TypeGroup>();

            var groups = _ctx.NhomLoaiSanPhams.ToList();
            groups.ForEach(g => typeGroups.Add(new TypeGroup
            {
                Id = g.MaNhom,
                Name = g.TenNhom,
                Types = _ctx.LoaiSanPhams
                    .Where(t => t.MaNhom == g.MaNhom)
                    .Select(t => new TypeInfo()
                    {
                        Id = t.MaLoaiSP,
                        Name = t.TenLoaiSP,
                        Count = _ctx.SanPhams.Count(p => p.MaLoaiSP == t.MaLoaiSP)
                    })
                    .ToList()
            }));

            return PartialView(typeGroups);
        }
    }
}