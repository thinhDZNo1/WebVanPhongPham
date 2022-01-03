using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanPhongPhamDTO.Entities;
using VanPhongPhamDTO.EntityFramework;

namespace VanPhongPham.Controllers
{
    public class CategoriesController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();

        public async Task<IActionResult> Index()
        {
            return View(await db.Categories.ToListAsync());
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category_Id,Category_Name,Description")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                db.Add(categories);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categories);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await db.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Category_Id,Category_Name,Description")] Categories categories)
        {
            if (id != categories.Category_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(categories);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.Category_Id))
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
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Categories c = db.Categories.SingleOrDefault(x => x.Category_Id == id);
                db.Categories.Remove(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        private bool CategoriesExists(int id)
        {
            return db.Categories.Any(e => e.Category_Id == id);
        }
    }
}
