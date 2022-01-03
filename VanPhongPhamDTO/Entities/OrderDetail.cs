using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Products Products { get; set; }
        public int Order_ID { get; set; }
        [ForeignKey("Order_ID")]
        public Order Order { get; set; }
        public int Amount { get; set; }
    }
}
