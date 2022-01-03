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
    public class TaiKhoan : Controller
    {
        private readonly VanPhongPhamContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TaiKhoan(VanPhongPhamContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: TaiKhoan
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }
       

        // GET: TaiKhoan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaiKhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_Id,First_Name,Last_Name,Avatar,Address,BirthDay,Sex,Email,PhoneNumber,UserName,Password,Description,isActive, ImageFile")] Users users)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(users.ImageFile.FileName);
                string extension = Path.GetExtension(users.ImageFile.FileName);
                users.Avatar = fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                //Xóa file nếu đã có
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await users.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: TaiKhoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.User.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: TaiKhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_Id,First_Name,Last_Name,Avatar,Address,BirthDay,Sex,Email,PhoneNumber,UserName,Password,Description,isActive, ImageFile")] Users users)
        {
            if (id != users.User_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string partCurent = users.Avatar;
                    if (users.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(users.ImageFile.FileName);
                        string extension = Path.GetExtension(users.ImageFile.FileName);
                        fileName = fileName /*+ DateTime.Now.ToString("yymmssfff")*/ + extension;
                        users.Avatar = fileName /*+ DateTime.Now.ToString("yymmssfff") + extension*/;
                        string path = Path.Combine(wwwRootPath + "/images/", fileName);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await users.ImageFile.CopyToAsync(fileStream);
                        }
                    }
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.User_Id))
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
            return View(users);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                Users users = _context.User.SingleOrDefault(x => x.User_Id == id);
                var pathCurrent = Path.Combine(_hostEnvironment.WebRootPath, "images", users.Avatar);
                if (System.IO.File.Exists(pathCurrent))
                {
                    System.IO.File.Delete(pathCurrent);
                }
                _context.User.Remove(users);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.User.Any(e => e.User_Id == id);
        }
    }
}
