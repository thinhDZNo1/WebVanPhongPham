using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Products
    {
        [Display(Name = "Mã sản phẩm")]
        [Key]
        public int Product_Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required]

        public string Product_Name { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Product_Images { get; set; }
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
        [Display(Name = "Thương hiệu")]
        public int Producer_Id { get; set; }
        [ForeignKey("Producer_Id")]
        public Producer Producer { get; set; }        
        [Display(Name = "Kích cỡ")]
        [MaxLength(50)]
        public string Size { get; set; }
        [MaxLength(30)]
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
        [Display(Name = "Đơn vị")]
        [MaxLength(30)]
        public string Unit { get; set; }
        [Display(Name = "Loại")]
        [Required]
        public int CD_Id { get; set; }
        [ForeignKey("CD_Id")]
        public Category_Detail Category_Detail { get; set; }
        [Display(Name = "Số lượng")]
        public int Stock { get; set; }
        [Display(Name = "Giá")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "giảm giá")]
        public Decimal NewPrice { get; set; }
        [Display(Name = "Giới thiệu")]
        public string Detail_Description { get; set; }
        [Display(Name = "Ảnh chi tiết")]
        public string Description_Images { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile[] ImageFile2 { get; set; }
        public virtual List<Voucher> Voucher { get; set; }
        public virtual List<OrderDetail> Order { get; set; }
    }
}
