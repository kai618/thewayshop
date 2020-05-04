using System.Collections.Generic;
using thewayshop.Models;

namespace thewayshop.ViewModel
{
    public class TypeGroup
    {
        public NhomLoaiSanPham Group { get; set; }
        public List<LoaiSanPham> Types { get; set; }
    }
}