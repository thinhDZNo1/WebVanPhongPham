using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPhamDTO.Entities;
using VanPhongPhamDTO.EntityFramework;

namespace VanPhongPham.Controllers
{
    public class AccountController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Login(int id)
        {
            if (id == 1)
            {
                ViewBag.login = "switched";
                ViewBag.register = "";
                ViewBag.path = "/Home/Index";
            }
            else if (id == 2)
            {
                ViewBag.login = "";
                ViewBag.register = "switched";
                ViewBag.path = "/Home/Index";
            }
            else if (id == 3)
            {
                ViewBag.login = "switched";
                ViewBag.register = "";
                ViewBag.path = "/Category/Category";
            }
            else if (id == 4)
            {
                ViewBag.login = "";
                ViewBag.register = "switched";
                ViewBag.path = "/Category/Category";
            }
            else if (id == 5)
            {
                ViewBag.login = "switched";
                ViewBag.register = "";
                ViewBag.path = "/Category/CategoryDetail";
            }
            else if (id == 6)
            {
                ViewBag.login = "";
                ViewBag.register = "switched";
                ViewBag.path = "/Category/CategoryDetail";
            }
            else if (id == 7)
            {
                ViewBag.login = "switched";
                ViewBag.register = "";
                ViewBag.path = "/Home/Search";
            }
            else if (id == 8)
            {
                ViewBag.login = "";
                ViewBag.register = "switched";
                ViewBag.path = "/Home/Search";
            }
            else if (id == 9)
            {
                ViewBag.login = "switched";
                ViewBag.register = "";
                ViewBag.path = "/Cart/ShoppingCart";
            }
            else if (id == 10)
            {
                ViewBag.login = "";
                ViewBag.register = "switched";
                ViewBag.path = "/Cart/ShoppingCart";
            }
            else if (id == 11)
            {
                ViewBag.login = "switched";
                ViewBag.register = "";
                ViewBag.path = "/Cart/Order";
            }
            else if (id == 12)
            {
                ViewBag.login = "";
                ViewBag.register = "switched";
                ViewBag.path = "/Products/ProductsByBrand";
            }
            else if (id == 13)
            {
                ViewBag.login = "switched";
                ViewBag.register = "";
                ViewBag.path = "/Products/ProductsByBrand";
            }
            else if (id == 14)
            {
                ViewBag.login = "";
                ViewBag.register = "switched";
                ViewBag.path = "/Home/ProductDetail";
            }
            else if (id == 15)
            {
                ViewBag.login = "switched";
                ViewBag.register = "";
                ViewBag.path = "/Home/ProductDetail";
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string redirect, string username, string password)
        {
            var user = (from p in db.User 
                        where p.UserName == username && p.Password == password
                        select new
                        {
                            UserName = p.UserName,
                            isActive = p.isActive,
                            UserId = p.User_Id,
                            FirstName = p.First_Name,
                            LastName = p.Last_Name,
                            Avatar = p.Avatar,
                            Address = p.Address,
                            Password = p.Password,
                        }).FirstOrDefault();

            if (user != null)
            {
                if (user.isActive == 3)
                {
                    HttpContext.Session.SetString("username", user.UserName);
                    HttpContext.Session.SetString("pass", user.Password);
                    HttpContext.Session.SetInt32("isActive", user.isActive);
                    HttpContext.Session.SetInt32("userid", user.UserId);
                    HttpContext.Session.SetString("avatar", user.Avatar);
                    HttpContext.Session.SetString("address", user.Address);
                    ViewBag.goTo = null;
                    return Redirect(redirect);
                }
                else if (user.isActive == 2 || user.isActive == 1)
                {
                    ViewBag.goTo = "admin";
                }
                else
                {
                    ViewBag.goTo = "lock";
                }

            }
            else
            {
                ViewBag.error = "<p class=\"alert alert-danger\">Sai tên đăng nhập hoặc mật khẩu!</p>";
                ViewBag.path = redirect;
            }

            return View(user);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("pass");
            HttpContext.Session.Remove("isActive");
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Remove("avatar");
            HttpContext.Session.Remove("address");
            return Redirect("/");

        }
        
        [HttpPost]
        public IActionResult Register(string redirect, Users user)
        {
            if (!db.User.Any(x=>x.UserName.Equals(user.UserName)))
            {
                db.User.Add(user);
                db.SaveChanges();
                Users users = db.User.FirstOrDefault(x => x.UserName.Equals(user.UserName));
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetInt32("isActive", user.isActive);
                HttpContext.Session.SetInt32("userid", users.User_Id);
                HttpContext.Session.SetString("avatar", user.Avatar);
                HttpContext.Session.SetString("address", user.Address);
                return Redirect(redirect);
            }
            else
            {                                
                return Redirect("/Account/Login/19");
            }            
        }
        [HttpPost]
        public JsonResult Registers([FromBody]Users user)
        {
            bool flag = true;
            if (!db.User.Any(x => x.UserName.Equals(user.UserName))){
                db.User.Add(user);
                db.SaveChanges();
                Users users = db.User.FirstOrDefault(x => x.UserName.Equals(user.UserName));
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetString("pass", user.Password);
                HttpContext.Session.SetInt32("isActive", user.isActive);
                HttpContext.Session.SetInt32("userid", users.User_Id);
                HttpContext.Session.SetString("avatar", user.Avatar);
                HttpContext.Session.SetString("address", user.Address);
                flag = false;
            }
            return Json(new { flag });
        }
        public IActionResult Information()
        {
            var order = (from o in db.Order where o.User_Id == HttpContext.Session.GetInt32("userid") orderby o.DateOrder descending select o).ToList();
            var orderDT = db.OrderDetail.ToList();
            var product = db.Products.ToList();
            var turple = new Tuple<List<Order>, List<OrderDetail>, List<Products>>(order, orderDT, product);
            return View(turple);
        }
        public JsonResult Account()
        {
            int? id = HttpContext.Session.GetInt32("userid");
            Users users = db.User.FirstOrDefault(x => x.User_Id == id);
            return Json(new { users});
        }
        [HttpPost]
        public JsonResult ChangeImages(IFormFile file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            string filess = fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            //Xóa file nếu đã có
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyToAsync(fileStream);
            }
            int? id = HttpContext.Session.GetInt32("userid");
            Users users = db.User.FirstOrDefault(x => x.User_Id == id);
            users.Avatar = filess;
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            filess = @"\images\" + filess;
            return Json(new { filess});
        }
        public JsonResult GetID(int id)
        {
            Users users = db.User.SingleOrDefault(x => x.User_Id == id);
            string date = users.BirthDay.ToString("yyyy-MM-dd");
            return Json(new { users, date });
        }
        [HttpPost]
        public JsonResult Update([FromBody]Users users)
        {
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            string date = users.BirthDay.ToString("dd/MM/yyyy");
            HttpContext.Session.SetString("address", users.Address);
            return Json(new { users, date });
        }
        [HttpPost]
        public JsonResult ChangedPass(int id, string oldpass, string newpass, string pass)
        {
            Users users = db.User.FirstOrDefault(x => x.User_Id == id);
            users.Password = pass;
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            HttpContext.Session.SetString("pass", users.Password);
            return Json(new { users });
        }
    }
}
