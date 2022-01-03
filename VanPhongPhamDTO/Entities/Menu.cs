using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Menu
    {
        [Key]
        [Display(Name = "Mã")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên mục")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Đường dẫn")]
        public string Link { get; set; }
        [Display(Name = "thẻ")]
        public string Target { get; set; }
        [Display(Name = "Trạng thái")]
        public string Status { get; set; }
    }
}
