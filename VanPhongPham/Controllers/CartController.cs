using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanPhongPham.Models;
using VanPhongPhamDTO.Entities;
using VanPhongPhamDTO.EntityFramework;

namespace VanPhongPham.Controllers
{
    public class CartController : Controller
    {

        VanPhongPhamContext db = new VanPhongPhamContext();
        public IActionResult Order()
        {            
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ChangeAddress(string address)
        {
            Users users = db.User.FirstOrDefault(x => x.User_Id == HttpContext.Session.GetInt32("userid"));
            users.Address = address;
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            HttpContext.Session.SetString("address", address);
            return Json(new { address });
        }
        public IActionResult ShoppingCart()
        {
            return View();
        }
        public JsonResult ListCarts()
        {
            List<CartItem> carts = HttpContext.Session.Get<List<CartItem>>("Cart") as List<CartItem>;
            return Json(carts);
        }
        //public JsonResult ListOrder()
        //{
        //    List<CartItem> carts = HttpContext.Session.Get<List<CartItem>>("Cart") as List<CartItem>;
        //    List<Promotion> promotions = db.Promotion.ToList();
        //    List<Voucher> vouchers = db.Voucher.ToList();
        //    return Json(new { carts, promotions, vouchers });
        //}
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            List<CartItem> carts = null;
            if (HttpContext.Session.Get<List<CartItem>>("Cart") == null)//Nếu giỏ hàng rỗng
            {
                carts = new List<CartItem>();
                carts.Add(new CartItem { Products = db.Products.Find(id), Quantity = 1 });
            }
            else//đã có trong giỏ
            {
                carts = HttpContext.Session.Get<List<CartItem>>("Cart") as List<CartItem>;
                CartItem Product = carts.SingleOrDefault(x => x.Products.Product_Id == id);
                if (Product != null)//đã có sản phẩm trong giỏ hàng
                {
                    Product.Quantity++;
                }
                else
                {
                    carts.Add(new CartItem { Products = db.Products.Find(id), Quantity = 1 });

                }
            }
            //Cập nhật lại session
            HttpContext.Session.Set<List<CartItem>>("Cart", carts);
            double summary = 0;
            foreach (var item in carts)
            {
                if (item.Products.NewPrice != 0)
                {
                    summary += (double)(item.Quantity * item.Products.NewPrice);
                }
                else
                {
                    summary += (double)(item.Quantity * item.Products.Price);
                }
            }
            //Trả lại  tổng số lượng hàng hóa cần mua
            return Json(new { total = carts.Sum(x => x.Quantity), summary });
        }
        
        [HttpPost]
        public JsonResult ReduceProductCart(int id)
        {
            List<CartItem> carts = null;
            if (HttpContext.Session.Get<List<CartItem>>("Cart") == null)//Nếu giỏ hàng rỗng
            {
                carts = new List<CartItem>();
                //carts.Add(new CartItem { Products = db.Products.Find(id), Quantity = 1 });
            }
            else//đã có trong giỏ
            {
                carts = HttpContext.Session.Get<List<CartItem>>("Cart") as List<CartItem>;
                CartItem Product = carts.SingleOrDefault(x => x.Products.Product_Id == id);
                if (Product != null)//đã có sản phẩm trong giỏ hàng
                {
                    Product.Quantity--;
                }
                else
                {
                    //carts.Add(new CartItem { Products = db.Products.Find(id), Quantity = 1 });

                }
            }
            //Cập nhật lại session
            HttpContext.Session.Set<List<CartItem>>("Cart", carts);
            double summary = 0;
            foreach (var item in carts)
            {
                if (item.Products.NewPrice != 0)
                {
                    summary += (double)(item.Quantity * item.Products.NewPrice);
                }
                else
                {
                    summary += (double)(item.Quantity * item.Products.Price);
                }
            }
            return Json(new { total = carts.Sum(x => x.Quantity), summary });
        }
        [HttpPost]
        public JsonResult RemoveCart(int id)
        {
            List<CartItem> carts = null;
            if (HttpContext.Session.Get<List<CartItem>>("Cart") == null)//Nếu giỏ hàng rỗng
            {
                carts = new List<CartItem>();
                //carts.Add(new CartItem { Products = db.Products.Find(id), Quantity = 1 });
            }
            else//đã có trong giỏ
            {
                carts = HttpContext.Session.Get<List<CartItem>>("Cart") as List<CartItem>;
                CartItem Product = carts.SingleOrDefault(x => x.Products.Product_Id == id);
                if (Product != null)//đã có sản phẩm trong giỏ hàng
                {
                    carts.Remove(Product);
                }
                else
                {
                   // carts.Add(new CartItem { Products = db.Products.Find(id), Quantity = 1 });

                }
            }
            //Cập nhật lại session
            HttpContext.Session.Set<List<CartItem>>("Cart", carts);
            return Json(new { total = carts.Sum(x => x.Quantity) });
        }
        public JsonResult AddProductToCart(int id, int quan)
        {
            List<CartItem> carts = null;
            if (HttpContext.Session.Get<List<CartItem>>("Cart") == null)
            {
                carts = new List<CartItem>();
                carts.Add(new CartItem { Products = db.Products.Find(id), Quantity = quan });
            }
            else//đã có trong giỏ
            {
                carts = HttpContext.Session.Get<List<CartItem>>("Cart") as List<CartItem>;
                CartItem Product = carts.SingleOrDefault(x => x.Products.Product_Id == id);
                if (Product != null)//đã có sản phẩm trong giỏ hàng
                {
                    Product.Quantity += quan;
                }
                else
                {
                    carts.Add(new CartItem { Products = db.Products.Find(id), Quantity = quan });

                }
            }
            //Cập nhật lại session
            HttpContext.Session.Set<List<CartItem>>("Cart", carts);
            return Json(new { total = carts.Sum(x => x.Quantity) });
        }
        [HttpPost]
        public JsonResult ThanhToan(string note, string payment, int n)
        {
            Order order = new Order();
            List<CartItem> cartItems = (List<CartItem>)HttpContext.Session.Get<List<CartItem>>("Cart");
            order.User_Id = (int)HttpContext.Session.GetInt32("userid");
            order.Total = (decimal)n;
            order.Status = "Đang chờ xử lý";
            order.Note = note;
            order.Payment = payment;
            order.DateOrder = DateTime.Now;
            db.Order.Add(order);
            db.SaveChanges();
            List<Order> order1 = db.Order.OrderByDescending(x => x.Order_ID).Take(1).ToList();
            foreach (var item in cartItems)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.Product_Id = item.Products.Product_Id;
                orderDetail.Order_ID = order1[0].Order_ID;
                orderDetail.Amount = item.Quantity;
                db.OrderDetail.Add(orderDetail);
                db.SaveChanges();
            }
            HttpContext.Session.Set<List<CartItem>>("Cart", null);
            string url = "/Account/Information/#manage";
            return Json(new { url });
        }
        public JsonResult ListOrder()
        {            
            var order = (from o in db.Order where o.User_Id == HttpContext.Session.GetInt32("userid") orderby o.DateOrder descending select o).ToList();
            return Json(order);
        }
        public IActionResult ListOrderDT()
        {
            var orderDT = (from o in db.Order
                           join od in db.OrderDetail on o.Order_ID equals od.Order_ID
                           join p in db.Products on od.Product_Id equals p.Product_Id
                           where o.User_Id == HttpContext.Session.GetInt32("userid")
                           select new
                           {
                               o.Status,
                               od.Amount,
                               p.Product_Images,
                               p.Product_Name,
                               p.Unit,
                               p.NewPrice,
                               p.Price
                           }).ToList();
            return Json(orderDT);
        }
       public JsonResult Cancel(int id, string note)
        {
            Order order = db.Order.SingleOrDefault(x => x.Order_ID == id);
            order.Status = "Đã hủy";
            order.Note = note;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            string path = "/Account/Information/#manage";
            return Json(new { path });

        }
        //public JsonResult ListOrder()
        //{
        //    var order = (from o in db.Order where o.User_Id == HttpContext.Session.GetInt32("userid") select o).ToList();
        //    return Json(order);
        //}
        //public JsonResult ListOrderDT()
        //{
        //    var orderDT = (from o in db.Order
        //                   join od in db.OrderDetail on o.Order_ID equals od.Order_ID
        //                   join p in db.Products on od.Product_Id equals p.Product_Id
        //                   where o.User_Id == HttpContext.Session.GetInt32("userid")
        //                   select new
        //                   {
        //                       o.Status,
        //                       od.Amount,
        //                       p.Product_Images,
        //                       p.Product_Name,
        //                       p.Unit,
        //                       p.NewPrice,
        //                       p.Price
        //                   }).ToList();
        //    return Json(orderDT);
        //}
    }
}
