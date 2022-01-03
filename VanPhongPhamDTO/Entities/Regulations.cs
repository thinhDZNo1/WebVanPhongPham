using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Regulations
    {
        [Key]
        [Display(Name = "Mã")]
        public int Id { get; set; }
        [Display(Name = "Tên điều khoản")]
        public string Name { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Người viết")]
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public Users Users { get; set; }
    }
}
