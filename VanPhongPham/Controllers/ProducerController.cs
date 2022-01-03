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
            return View(db.Producer.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Producer_Id, Producer_Name, ImageFile,Producer_Description,Origin")] Producer p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
                    string extension = Path.GetExtension(p.ImageFile.FileName);                    
                    p.Producer_Images = fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);
                    //Xóa file nếu đã có
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await p.ImageFile.CopyToAsync(fileStream);
                    }
                    db.Add(p);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Producer p = db.Producer.FirstOrDefault(x => x.Producer_Id == id);
            return View(p);
        }
        [HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Producer_Id, Producer_Name, Producer_Images, Producer_Description, Origin")] Producer p, IFormFile customFile)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (!customFile.Equals(null))
        //            {
        //                var img = (from i in db.Producer where i.Producer_Id == id select i).SingleOrDefault();
        //                var pathCurrent = Path.Combine(_hostEnvironment.WebRootPath , "images", img.Producer_Images);
        //                if (System.IO.File.Exists(pathCurrent))
        //                {
        //                    System.IO.File.Delete(pathCurrent);
        //                }
        //                string wwwRootPath = _hostEnvironment.WebRootPath;
        //                string fileName = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
        //                string extension = Path.GetExtension(p.ImageFile.FileName);
        //                fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
        //                p.Producer_Images = @"~/images/" + fileName /*+ DateTime.Now.ToString("yymmssfff") + extension*/;
        //                string path = Path.Combine(wwwRootPath + "/images/", fileName);
        //                using (var fileStream = new FileStream(path, FileMode.Create))
        //                {
        //                    await p.ImageFile.CopyToAsync(fileStream);
        //                }
        //            }
        //            db.Entry(p).State = EntityState.Modified;
        //            await db.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError(string.Empty, ex.Message);
        //    }
        //    return View(p);
        //}
        public async Task<IActionResult> Edit(int id, [Bind("Producer_Id, Producer_Name, Producer_Images, Producer_Description, Origin, ImageFile")] Producer p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string partCurent = p.Producer_Images;
                    if (p.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(p.ImageFile.FileName);
                        string extension = Path.GetExtension(p.ImageFile.FileName);
                        fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
                        p.Producer_Images = fileName /*+ DateTime.Now.ToString("yymmssfff") + extension*/;
                        string path = Path.Combine(wwwRootPath + "/images/", fileName);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await p.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    db.Entry(p).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(p);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                Producer p = db.Producer.SingleOrDefault(x => x.Producer_Id == id);
                var pathCurrent = Path.Combine(_hostEnvironment.WebRootPath, "images", p.Producer_Images);
                if (System.IO.File.Exists(pathCurrent))
                {
                    System.IO.File.Delete(pathCurrent);
                }
                db.Producer.Remove(p);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
