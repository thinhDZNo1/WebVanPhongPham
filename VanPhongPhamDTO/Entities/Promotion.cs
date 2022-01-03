using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Promotion
    {
        [Key]
        [Display(Name = "Mã")]
        public int Promotion_Id { get; set; }
        [Display(Name = "Tên chương trình giảm giá")]
        [Required]
        public string Promotion_Name { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string Images { get; set; }
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
        [Display(Name = "Ngày bắt đầu")]
        public DateTime Start_Day { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime End_Date { get; set; }
        [Display(Name = "Giảm(%)")]
        public decimal Discount { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public virtual List<Voucher> Voucher { get; set; }
    }
}
