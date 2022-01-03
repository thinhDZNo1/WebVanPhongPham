using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VanPhongPhamDTO.Entities
{
    public class Categories
    {
        [Key]
        [Display(Name = "Mã danh mục")]
        public int Category_Id { get; set; }
        [Required]
        [Display(Name = "Tên danh mục")]
        public string Category_Name { get; set; }
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
        public virtual List<Category_Detail> Category_Detail { get; set; }
    }
}
