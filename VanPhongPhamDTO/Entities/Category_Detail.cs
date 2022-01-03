using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Category_Detail
    {
        [Key]
        [Display(Name = "Mã loại sản phẩm")]
        public int CD_Id { get; set; }
        [Required]
        [Display(Name = "Tên loại sản phẩm")]
        public string CD_Name { get; set; }
        [Display(Name = "Miêu tả")]
        public string CD_Description { get; set; }
        [Display(Name = "Danh mục")]
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Categories Categories { get; set; }
        public virtual List<Products> Products { get; set; }
        public virtual List<Promotion> Promotion { get; set; }
    }
}
