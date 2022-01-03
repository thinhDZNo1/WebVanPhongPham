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
    public class NewsController : Controller
    {
        private readonly VanPhongPhamContext _context;

        private readonly IWebHostEnvironment _hostEnvironment;

        public NewsController(VanPhongPhamContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("New_Id,New_Name,Images,Description,Content")] News news)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(news.ImageFile.FileName);
                string extension = Path.GetExtension(news.ImageFile.FileName);
                news.Images = fileName = fileName + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await news.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("New_Id,New_Name,Images,Description,Content")] News news)
        {
            if (id != news.New_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (news.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(news.ImageFile.FileName);
                        string extension = Path.GetExtension(news.ImageFile.FileName);
                        news.Images = fileName = fileName + extension;
                        string path = Path.Combine(wwwRootPath + "/images/", fileName);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await news.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.New_Id))
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
            return View(news);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                News n = _context.News.SingleOrDefault(x => x.New_Id == id);
                var pathCurrent = Path.Combine(_hostEnvironment.WebRootPath, "images", n.Images);
                if (System.IO.File.Exists(pathCurrent))
                {
                    System.IO.File.Delete(pathCurrent);
                }
                _context.News.Remove(n);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.New_Id == id);
        }
    }
}
