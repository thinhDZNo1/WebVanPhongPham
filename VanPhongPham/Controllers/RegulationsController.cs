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
    public class RegulationsController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();


        // GET: Regulations
        public async Task<IActionResult> Index()
        {
            var regulations = db.Regulations.Include(r => r.Users);
            return View(await regulations.ToListAsync());
        }

        
        public IActionResult Create()
        {
            ViewData["User_Id"] = new SelectList(db.User, "User_Id", "Last_Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Content,User_Id")] Regulations regulations)
        {
            if (ModelState.IsValid)
            {
                db.Add(regulations);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["User_Id"] = new SelectList(db.User, "User_Id", "Last_Name", regulations.User_Id);
            return View(regulations);
        }

        // GET: Regulations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulations = await db.Regulations.FindAsync(id);
            if (regulations == null)
            {
                return NotFound();
            }
            ViewData["User_Id"] = new SelectList(db.User, "User_Id", "Last_Name", regulations.User_Id);
            return View(regulations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Content,User_Id")] Regulations regulations)
        {
            if (id != regulations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(regulations);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegulationsExists(regulations.Id))
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
            ViewData["User_Id"] = new SelectList(db.User, "User_Id", "Last_Name", regulations.User_Id);
            return View(regulations);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Regulations r = db.Regulations.SingleOrDefault(x => x.Id == id);                
                db.Regulations.Remove(r);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RegulationsExists(int id)
        {
            return db.Regulations.Any(e => e.Id == id);
        }
    }
}
