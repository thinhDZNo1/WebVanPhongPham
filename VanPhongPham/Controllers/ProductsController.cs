using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VanPhongPhamDTO.Entities;
using VanPhongPhamDTO.EntityFramework;


namespace VanPhongPham.Controllers
{
    public class ProductsController : Controller
    {
        private readonly VanPhongPhamContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(VanPhongPhamContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var vanPhongPhamContext = _context.Products.Include(p => p.Category_Detail).Include(p => p.Producer);
            return View(await vanPhongPhamContext.ToListAsync());
        }


        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CD_Id"] = new SelectList(_context.Category_Detail, "CD_Id", "CD_Name");
            ViewData["Producer_Id"] = new SelectList(_context.Producer, "Producer_Id", "Producer_Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_Id,Product_Name,ImageFile,Description,Producer_Id,Size,Status,Unit,CD_Id,Stock,Price,Detail_Description,ImageFile2")] Products products)
        {
            if (ModelState.IsValid)
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
                if (products.ImageFile2 != null) 
                {
                    foreach (var file in products.ImageFile2)
                    {
                        string wwwRootPath2 = _hostEnvironment.WebRootPath;
                        string fileName2 = Path.GetFileNameWithoutExtension(file.FileName);
                        string extension2 = Path.GetExtension(file.FileName);
                        fileName2 = fileName2 /*+ DateTime.Now.ToString("yymmssfff")*/ + extension2;
                        //products.Description_Images += "<img class=\"tbslider\" src=\"//images//" + fileName2 + "\">";
                        products.Description_Images += fileName2 + ",";
                        string path2 = Path.Combine(wwwRootPath + "/images/", fileName2);
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
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CD_Id"] = new SelectList(_context.Category_Detail, "CD_Id", "CD_Name", products.CD_Id);
            ViewData["Producer_Id"] = new SelectList(_context.Producer, "Producer_Id", "Producer_Name", products.Producer_Id);
            return View(products);
        }

        // GET: Products/Edit/5
        [HttpGet]
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
            ViewData["CD_Id"] = new SelectList(_context.Category_Detail, "CD_Id", "CD_Name", products.CD_Id);
            ViewData["Producer_Id"] = new SelectList(_context.Producer, "Producer_Id", "Producer_Name", products.Producer_Id);
            if (products.Description_Images == null)
            {
                ViewData["MultiImage"] = null;
            }
            else
            {
                string[] str = products.Description_Images.Split(',');
                ViewData["MultiImage"] = str;
            }
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_Id,Product_Name,Product_Images,Description,Producer_Id,Size,Status,Unit,CD_Id,Stock,Price,Detail_Description,Description_Images, ImageFile, ImageFile2")] Products products)
        {
            if (id != products.Product_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(products.ImageFile != null)
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
                    if (products.ImageFile2 != null)
                    {
                        products.Description_Images = "";
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
            ViewData["Producer_Id"] = new SelectList(_context.Producer, "Producer_Id", "Producer_Name", products.Producer_Id);
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Products p = _context.Products.SingleOrDefault(x => x.Producer_Id == id);
                var pathCurrent = Path.Combine(_hostEnvironment.WebRootPath, "images", p.Product_Images);
                if (System.IO.File.Exists(pathCurrent))
                {
                    System.IO.File.Delete(pathCurrent);
                }
                if(p.Description_Images!= null)
                {
                    string[] str = p.Description_Images.Split(',');
                    foreach (string item in str)
                    {
                        pathCurrent = Path.Combine(_hostEnvironment.WebRootPath, "images", item);
                        if (System.IO.File.Exists(pathCurrent))
                        {
                            System.IO.File.Delete(pathCurrent);
                        }
                    }
                }
                _context.Products.Remove(p);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ProductsByBrand(int id)
        {
            var products = (from p in _context.Producer
                            join pro in _context.Products on p.Producer_Id equals pro.Producer_Id
                            where p.Producer_Id == id
                            select pro).ToList();
            var producer = _context.Producer.SingleOrDefault(p => p.Producer_Id == id);
            var newProduct = _context.Products.OrderByDescending(p => p.Product_Id).Take(8).ToList();
            var brand = _context.Producer.ToList();
            var tuple = new Tuple<List<Products>,  List<Products>, Producer, List<Producer>>(products, newProduct, producer, brand );
            return View(tuple);
        }
        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Product_Id == id);
        }
    }
}
