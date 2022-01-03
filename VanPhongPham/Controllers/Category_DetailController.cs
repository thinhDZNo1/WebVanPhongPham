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
    public class Category_DetailController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();

        // GET: Category_Detail
        public async Task<IActionResult> Index()
        {
            var category_Details = db.Category_Detail.Include(c => c.Categories);
            return View(await category_Details.ToListAsync());
        }

       
        public IActionResult Create()
        {
            ViewData["Category_Id"] = new SelectList(db.Categories, "Category_Id", "Category_Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CD_Id,CD_Name,CD_Description,Category_Id")] Category_Detail category_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Add(category_Detail);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category_Id"] = new SelectList(db.Categories, "Category_Id", "Category_Name", category_Detail.Category_Id);
            return View(category_Detail);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category_Detail = await db.Category_Detail.FindAsync(id);
            if (category_Detail == null)
            {
                return NotFound();
            }
            ViewData["Category_Id"] = new SelectList(db.Categories, "Category_Id", "Category_Name", category_Detail.Category_Id);
            return View(category_Detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CD_Id,CD_Name,CD_Description,Category_Id")] Category_Detail category_Detail)
        {
            if (id != category_Detail.CD_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(category_Detail);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Category_DetailExists(category_Detail.CD_Id))
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
            ViewData["Category_Id"] = new SelectList(db.Categories, "Category_Id", "Category_Name", category_Detail.Category_Id);
            return View(category_Detail);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Category_Detail c = db.Category_Detail.SingleOrDefault(c => c.Category_Id == id);
                db.Category_Detail.Remove(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool Category_DetailExists(int id)
        {
            return db.Category_Detail.Any(e => e.CD_Id == id);
        }
    }
}
