using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPhamDTO.Entities;
using VanPhongPhamDTO.EntityFramework;

namespace VanPhongPham.Controllers
{
    public class CategoryController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();
        public IActionResult Category(int id)
        {
            var category = db.Categories.SingleOrDefault(x => x.Category_Id == id);
            var listNew = db.Products.OrderByDescending(x => x.Product_Id).Take(10).ToList();
            var model = new Tuple<Categories, List<Products>>(category, listNew);
            return View(model);
        }
        public IActionResult CategoryDetail(int id)
        {
            var catedetail = db.Category_Detail.SingleOrDefault(x => x.CD_Id == id);
            var listNew = db.Products.OrderByDescending(x => x.Product_Id).Take(10).ToList();
            var model = new Tuple<Category_Detail, List<Products>>(catedetail, listNew);
            return View(model);
        }
    }
}
