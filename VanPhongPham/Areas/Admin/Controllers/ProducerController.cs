using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPhamDTO.EntityFramework;
using VanPhongPhamDTO.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace VanPhongPham.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProducerController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProducerController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(db.Producer.ToList());
        }
        [HttpPost]
        public JsonResult Create([FromBody] Producer p, IFormFile customFile)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(customFile.FileName);
            string extension = Path.GetExtension(customFile.FileName);
            p.Producer_Images = fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            //Xóa file nếu đã có
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                p.ImageFile.CopyTo(fileStream);
            }
            db.Producer.Add(p);
            db.SaveChanges();
            return Json(p);
        }

    }
}
