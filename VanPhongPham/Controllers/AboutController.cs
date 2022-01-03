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
    public class AboutController : Controller
    {
        VanPhongPhamContext db = new VanPhongPhamContext();

        // GET: About
        public async Task<IActionResult> Index()
        {
            var user = db.About.Include(a =>a.Users);
            return View(await user.ToListAsync());
        }

        // GET: About/Create
        public IActionResult Create()
        {
            ViewData["User_Id"] = new SelectList(db.User, "User_Id", "Last_Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AB_Id,Name,Content,Company_PN,Company_Email,User_Id")] About about)
        {
            if (ModelState.IsValid)
            {
                db.Add(about);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["User_Id"] = new SelectList(db.User, "User_Id", "Last_Name" , about.User_Id);
            return View(about);
        }

        // GET: About/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await db.About.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            ViewData["User_Id"] = new SelectList(db.User, "User_Id", "Last_Name", about.User_Id);
            return View(about);
        }

        // POST: About/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AB_Id,Name,Content,Company_PN,Company_Email,User_Id")] About about)
        {
            if (id != about.AB_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(about);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutExists(about.AB_Id))
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
            ViewData["User_Id"] = new SelectList(db.User, "User_Id", "Last_Name", about.User_Id);
            return View(about);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                About a = db.About.SingleOrDefault(x => x.AB_Id == id);
                db.About.Remove(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
            return db.About.Any(e => e.AB_Id == id);
        }
    }
}
