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
    public class SliderController : Controller
    {
        private readonly VanPhongPhamContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public SliderController(VanPhongPhamContext context, IWebHostEnvironment hostEnvironment)
        {
            this._context = context;
            this._hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SLider_Id,ImageFile,Topic,Slider_Description")] Slider slider)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(slider.ImageFile.FileName);
                string extension = Path.GetExtension(slider.ImageFile.FileName);
                slider.SLider_Images = fileName = fileName + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await slider.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Slider/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SLider_Id,SLider_Images,Topic,Slider_Description, ImageFile")] Slider slider)
        {
            if (id != slider.SLider_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string partCurent = slider.SLider_Images;
                    if (slider.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(slider.ImageFile.FileName);
                        string extension = Path.GetExtension(slider.ImageFile.FileName);                        
                        slider.SLider_Images = fileName = fileName + extension;
                        string path = Path.Combine(wwwRootPath + "/images/", fileName);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await slider.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.SLider_Id))
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
            return View(slider);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Slider s = _context.Sliders.SingleOrDefault(x => x.SLider_Id == id);
                var pathCurrent = Path.Combine(_hostEnvironment.WebRootPath, "images",s.SLider_Images);
                if (System.IO.File.Exists(pathCurrent))
                {
                    System.IO.File.Delete(pathCurrent);
                }
                _context.Sliders.Remove(s);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
            return _context.Sliders.Any(e => e.SLider_Id == id);
        }
    }
}
