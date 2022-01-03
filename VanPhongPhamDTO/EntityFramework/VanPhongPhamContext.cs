using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPhamDTO.Entities;

namespace VanPhongPhamDTO.EntityFramework
{
    public class VanPhongPhamContext : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Category_Detail> Category_Detail { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Regulations> Regulations { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public VanPhongPhamContext() { }
        public VanPhongPhamContext(DbContextOptions<VanPhongPhamContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =DESKTOP-E71IRH8;Database=VanPhongPhamDB;Integrated security = true;");
        }
    }
}
