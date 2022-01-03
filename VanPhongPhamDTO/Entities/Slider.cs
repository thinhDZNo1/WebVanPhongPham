using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Slider
    {
        [Display(Name = "Mã slider")]
        [Key]
        public int SLider_Id { get; set; }
        [Display(Name = "Ảnh")]
        public string SLider_Images { get; set; }
        [Display(Name = "Chủ đề")]
        public string Topic { get; set; }
        [Display(Name = "Miêu tả")]
        public string Slider_Description { get; set; }
        [NotMapped]//Thuộc tính không lưu
        public IFormFile ImageFile { get; set; }
    }
}
