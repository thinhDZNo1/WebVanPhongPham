using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPhamDTO.EntityFramework;
using VanPhongPhamDTO.Entities;

namespace VanPhongPham.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
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
                        }).FirstOrDefault();

            if (user != null)
            {
                //foreach (var item in user)
                //{
                //    HttpContext.Session.SetInt32("userid", item.UserId);
                //    HttpContext.Session.SetInt32("isActive", item.isActive);
                //    HttpContext.Session.SetInt32("fullname", item.UserId);
                //    HttpContext.Session.SetString("avatar", item.FirstName);
                //    HttpContext.Session.SetString("avatar", item.LastName);
                //    HttpContext.Session.SetString("avatar", item.FirstName);
                //    HttpContext.Session.SetString("avatar", item.Avatar);
                //    HttpContext.Session.SetString("avatar", item.Address);
                //}
                if (user.isActive == 1 || user.isActive == 2)
                {
                    HttpContext.Session.SetString("usernamelg", user.UserName);
                    HttpContext.Session.SetInt32("isActivelg", user.isActive);
                    HttpContext.Session.SetInt32("useridlg", user.UserId);
                    HttpContext.Session.SetString("firstnamelg", user.FirstName);
                    HttpContext.Session.SetString("lastnamelg", user.LastName);
                    HttpContext.Session.SetString("avatarlg", user.Avatar);
                    HttpContext.Session.SetString("addresslg", user.Address);
                    return Redirect("/Admin/Home/Index");
                }
                else
                {
                    ViewBag.error = "<p class=\"alert alert-danger\">Tài khoản không có quyền hạn ở đây!!</p>";
                }
            }
            ViewBag.error = "<p class=\"alert alert-danger\">Sai tên đăng nhập hoặc mật khẩu!</p>";
            return View(user);
        }
    }
}
