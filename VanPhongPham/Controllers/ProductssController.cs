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
    public class ProductssController : Controller
    {
        private readonly VanPhongPhamContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductssController(VanPhongPhamContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Productss
        public async Task<IActionResult> Index()
        {
            var vanPhongPhamContext = _context.Products.Include(p => p.Category_Detail).Include(p => p.Producer);
            return View(await vanPhongPhamContext.ToListAsync());
        }

        // GET: Productss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category_Detail)
                .Include(p => p.Producer)
                .FirstOrDefaultAsync(m => m.Product_Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Productss/Create
        public IActionResult Create()
        {
            ViewData["CD_Id"] = new SelectList(_context.Category_Detail, "CD_Id", "CD_Name");
            ViewData["Producer_Id"] = new SelectList(_context.Producer, "Producer_Id", "Origin");
            return View();
        }

        // POST: Productss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_Id,Product_Name,Product_Images,Description,Producer_Id,Size,Status,Unit,CD_Id,Stock,Price,Detail_Description,Description_Images")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CD_Id"] = new SelectList(_context.Category_Detail, "CD_Id", "CD_Name", products.CD_Id);
            ViewData["Producer_Id"] = new SelectList(_context.Producer, "Producer_Id", "Origin", products.Producer_Id);
            return View(products);
        }

        // GET: Productss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            if (products.Description_Images == null) 
            {
                ViewData["MultiImage"] = null;
            }
            else
            {
                string[] str = products.Description_Images.Split(',');
                ViewData["MultiImage"] = str;
            }
            ViewData["CD_Id"] = new SelectList(_context.Category_Detail, "CD_Id", "CD_Name", products.CD_Id);
            ViewData["Producer_Id"] = new SelectList(_context.Producer, "Producer_Id", "Origin", products.Producer_Id);
            return View(products);
        }

        // POST: Productss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_Id,Product_Name,Product_Images,Description,Producer_Id,Size,Status,Unit,CD_Id,Stock,Price,Detail_Description,Description_Images,ImageFile,ImageFile2")] Products products)
        {
            if (id != products.Product_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (products.ImageFile != null)
                    {

                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(products.ImageFile.FileName);
                        string extension = Path.GetExtension(products.ImageFile.FileName);
                        products.Product_Images = fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
                        string path = Path.Combine(wwwRootPath + "/images/", fileName);
                        //Xóa file nếu đã có
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await products.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    string di = products.Description_Images;
                    if(products.ImageFile2 != null)
                    {
                        foreach (var file in products.ImageFile2)
                        {
                            string wwwRootPath2 = _hostEnvironment.WebRootPath;
                            string fileName2 = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension2 = Path.GetExtension(file.FileName);
                            fileName2 = fileName2 /*+ DateTime.Now.ToString("yymmssfff")*/ + extension2;
                            products.Description_Images += fileName2 + ",";
                            string path2 = Path.Combine(wwwRootPath2 + "/images/", fileName2);
                            //Xóa file nếu đã có
                            if (System.IO.File.Exists(path2))
                            {
                                System.IO.File.Delete(path2);
                            }
                            using (var fileStream = new FileStream(path2, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                    if (products.Description_Images == null)
                    {
                        products.Description_Images = di;
                    }

                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Product_Id))
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
            ViewData["CD_Id"] = new SelectList(_context.Category_Detail, "CD_Id", "CD_Name", products.CD_Id);
            ViewData["Producer_Id"] = new SelectList(_context.Producer, "Producer_Id", "Origin", products.Producer_Id);
            return View(products);
        }

        // GET: Productss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category_Detail)
                .Include(p => p.Producer)
                .FirstOrDefaultAsync(m => m.Product_Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Productss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Product_Id == id);
        }
    }
}
