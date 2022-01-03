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
    public class Users
    {
        [Key]
        [Display(Name = "Mã")]
        public int User_Id { get; set; }
        [Display(Name = "Họ")]
        public string First_Name { get; set; }
        [Display(Name = "Tên")]
        public string Last_Name { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Giới tính")]
        public string Sex { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
        [Display(Name = "Quyền hạn")]
        public int isActive { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        public virtual List<Regulations> Regulations { get; set; }
        public virtual List<About> About { get; set; }
        public virtual List<Order> Order { get; set; }

    }
}
