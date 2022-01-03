using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Producer
    {
        [Display(Name = "Mã thương hiệu")]
        [Key]
        public int Producer_Id { get; set; }
        [Display(Name = "Tên thương hiệu")]
        [Required]
        [MaxLength(100)]
        public string Producer_Name { get; set; }
        [Display(Name = "Ảnh đại diện")]
        [DataType(DataType.Upload)]
        public string Producer_Images { get; set; }
        [Display(Name = "Miêu tả")]
        public string Producer_Description { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Quốc gia")]
        public string Origin { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        public virtual List<Products> Products { get; set; }
    }
}
