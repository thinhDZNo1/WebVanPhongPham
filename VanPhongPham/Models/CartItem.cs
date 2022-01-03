using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPhamDTO.Entities;

namespace VanPhongPham.Models
{
    public class CartItem
    {
        public Products Products { get; set; }
        public int Quantity { get; set; }
    }
}
