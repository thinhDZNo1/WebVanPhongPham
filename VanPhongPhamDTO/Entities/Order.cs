using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Order
    {
        [Key]
        public int Order_ID { get; set; }
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public Users Users { get; set; }
        public DateTime DateOrder { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Payment { get; set; }
        public string Reason { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }

    }
}
