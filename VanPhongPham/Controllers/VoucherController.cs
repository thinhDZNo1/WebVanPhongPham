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
    public class VoucherController : Controller
    {
        private readonly VanPhongPhamContext _context;

        public VoucherController(VanPhongPhamContext context)
        {
            _context = context;
        }

        // GET: Voucher
        public async Task<IActionResult> Index()
        {
            var vanPhongPhamContext = _context.Voucher.Include(v => v.Products).Include(v => v.Promotion);
            return View(await vanPhongPhamContext.ToListAsync());
        }

        // GET: Voucher/Create
        public IActionResult Create()
        {
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name");
            ViewData["Promotion_Id"] = new SelectList(_context.Promotion, "Promotion_Id", "Promotion_Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Promotion_Id,Product_Id")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voucher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", voucher.Product_Id);
            ViewData["Promotion_Id"] = new SelectList(_context.Promotion, "Promotion_Id", "Promotion_Name", voucher.Promotion_Id);
            return View(voucher);
        }

        // GET: Voucher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Voucher.FindAsync(id);
            if (voucher == null)
            {
                return NotFound();
            }
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", voucher.Product_Id);
            ViewData["Promotion_Id"] = new SelectList(_context.Promotion, "Promotion_Id", "Promotion_Name", voucher.Promotion_Id);
            return View(voucher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Promotion_Id,Product_Id")] Voucher voucher)
        {
            if (id != voucher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voucher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoucherExists(voucher.Id))
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
            ViewData["Product_Id"] = new SelectList(_context.Products, "Product_Id", "Product_Name", voucher.Product_Id);
            ViewData["Promotion_Id"] = new SelectList(_context.Promotion, "Promotion_Id", "Promotion_Name", voucher.Promotion_Id);
            return View(voucher);
        }

        // GET: Voucher/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                Voucher v = _context.Voucher.SingleOrDefault(x => x.Id == id);
                _context.Voucher.Remove(v);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool VoucherExists(int id)
        {
            return _context.Voucher.Any(e => e.Id == id);
        }
    }
}
