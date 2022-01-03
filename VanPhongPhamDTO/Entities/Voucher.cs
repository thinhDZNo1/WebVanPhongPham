using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Voucher
    {
        [Key]
        [Display(Name = "Mã")]
        public int Id { get; set; }
        [Display(Name = "Chương trình giảm giá")]
        public int Promotion_Id { get; set; }

        [ForeignKey("Promotion_Id")]
        public Promotion Promotion { get; set; }
        public int Product_Id { get; set; }

        [ForeignKey("Product_Id")]
        public Products Products { get; set; }
    }
}
