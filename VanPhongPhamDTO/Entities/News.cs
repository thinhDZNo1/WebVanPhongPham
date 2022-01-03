using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class News
    {
        [Key]
        [Display(Name = "Mã bài viết")]
        public int New_Id { get; set; }
        [Required]
        [Display(Name = "Tên bài viết")]
        public string New_Name { get; set; }
        [Display(Name = "Ảnh tiêu đề")]
        public string Images { get; set; }
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
