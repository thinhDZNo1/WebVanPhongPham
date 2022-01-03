using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPhamDTO.EntityFramework;

namespace VanPhongPham.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();
        public IActionResult Index(int id)
        {
            ViewBag.UserId = id;
            return View();
        }
        public JsonResult Info()
        {
            return Json(db.User.ToList());
        }
    }
}
