using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanPhongPhamDTO.Entities;
using VanPhongPhamDTO.EntityFramework;

namespace VanPhongPham.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly VanPhongPhamContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PromotionsController(VanPhongPhamContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promotion.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Promotion_Id,Promotion_Name,ImageFile,Description,Start_Day,End_Date,Discount")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                if (promotion.ImageFile!= null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(promotion.ImageFile.FileName);
                    string extension = Path.GetExtension(promotion.ImageFile.FileName);
                    promotion.Images = fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
                    string path = Path.Combine(wwwRootPath + "/images/", fileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await promotion.ImageFile.CopyToAsync(fileStream);
                    }
                }
                _context.Add(promotion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotion.FindAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return View(promotion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Promotion_Id,Promotion_Name,Images,Description,Start_Day,End_Date,Discount,ImageFile")] Promotion promotion)
        {
            if (id != promotion.Promotion_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (promotion.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(promotion.ImageFile.FileName);
                        string extension = Path.GetExtension(promotion.ImageFile.FileName);
                        fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
                        promotion.Images = fileName /*+ DateTime.Now.ToString("yymmssfff") + extension*/;
                        string path = Path.Combine(wwwRootPath + "/images/", fileName);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await promotion.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(promotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionExists(promotion.Promotion_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Promotion p = _context.Promotion.SingleOrDefault(x => x.Promotion_Id == id);
                var pathCurrent = Path.Combine(_hostEnvironment.WebRootPath, "images", p.Images);
                if (System.IO.File.Exists(pathCurrent))
                {
                    System.IO.File.Delete(pathCurrent);
                }
                _context.Promotion.Remove(p);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool PromotionExists(int id)
        {
            return _context.Promotion.Any(e => e.Promotion_Id == id);
        }
    }
}
