using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class About
    {
        [Key]
        [Display(Name = "mã")]
        public int AB_Id { get; set; }
        [Required]
        [Display(Name = "Tên thông tin")]
        public string Name { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Company_PN { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Company_Email { get; set; }
        [Display(Name = "Tên")]
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public Users Users { get; set; }
    }
}
