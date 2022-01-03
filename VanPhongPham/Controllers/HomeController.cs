using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPham.Models;
using VanPhongPhamDTO.Entities;
using VanPhongPhamDTO.EntityFramework;

namespace VanPhongPham.Controllers
{
    public class HomeController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();
        public IActionResult Index()
        {
            var slider = db.Sliders.ToList();
            var brand = db.Producer.ToList();
            var categories = db.Categories.ToList();
            var category_DT = db.Category_Detail.ToList();
            var product= db.Products.ToList();
            var listNew = db.Products.OrderByDescending(x => x.Product_Id).Take(10).ToList();
            var turple = new Tuple<List<Slider>, List<Producer>, List<Categories>, List<Category_Detail>, List<Products>, List<Products>>
                (slider, brand, categories, category_DT, product, listNew);
            return View(turple);
        }
        public IActionResult ProductDetail(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Product_Id == id);
            var producer = db.Producer.FirstOrDefault(x => x.Producer_Id == product.Producer_Id);
            if (product.Description_Images == null)
            {
                ViewData["MultiImage"] = null;
            }
            else
            {
                string[] str = product.Description_Images.Split(',');
                ViewData["MultiImage"] = str;
            }
            var similarProduct = db.Products.Where(x => x.Product_Id != id && x.CD_Id == product.CD_Id)
                                                     .OrderBy(emp => Guid.NewGuid())
                                                     .Take(5).ToList();
            var productSale = (from p in db.Products where p.Product_Id != id && p.NewPrice != 0 select p).Take(5).ToList();
            var tuple = new Tuple<Products, Producer, List<Products>, List<Products>>(product, producer, similarProduct, productSale);
            return View(tuple);
        }
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string keyWord)
        {
            List<Products> products = null;
            if (keyWord != null && keyWord != "")
            {
                products = (from p in db.Products where p.Product_Name.ToUpper().Contains(keyWord.ToUpper()) select p).ToList();
                ViewBag.products = products.ToList();
                ViewBag.count = products.Count();
                ViewBag.key = keyWord;
            }
            else
            {
                ViewBag.products = null;
                ViewBag.count = 0;
                ViewBag.key = keyWord;
            }
            ViewBag.listNew = db.Products.OrderByDescending(x => x.Product_Id).Take(10).ToList();
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
