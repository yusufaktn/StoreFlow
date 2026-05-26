using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using StoreFlow.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreFlow.Controllers
{
    public class OrderController : Controller
    {
        // Veritabanı bağlantısı için context sınıfımızı tanımlıyoruz
        private readonly MyContext _myContext;

        public OrderController(MyContext myContext)
        {
            _myContext = myContext;
        }

        // Siparişleri listeleyen sayfa
        public IActionResult Index(int page = 1, int pagesize = 10, string searchtext = null)
        {
            // Siparişleri müşteri ve detaylarıyla birlikte getiriyoruz
            var query = _myContext.Orders
                .Include(x => x.Customer)
                .OrderByDescending(x => x.OrderId)
                .AsQueryable();

            // Arama metni varsa filtreleme yapıyoruz
            if (!string.IsNullOrWhiteSpace(searchtext))
            {
                query = query.Where(x => x.Customer.FirstName.Contains(searchtext) || x.Customer.LastName.Contains(searchtext));
            }

            // Sayfalama işlemleri
            var totalCount = query.Count();
            var orders = query.Skip((page - 1) * pagesize).Take(pagesize).ToList();

            // View tarafına bilgileri gönderiyoruz
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pagesize);
            ViewBag.PageSize = pagesize;
            ViewBag.SearchText = searchtext;

            return View(orders);
        }

        // Yeni sipariş oluşturma sayfası (GET)
        [HttpGet]
        public IActionResult CreateOrder()
        {
            // Müşterileri dropdown için listeliyoruz
            List<SelectListItem> customers = _myContext.Customers
                .Select(x => new SelectListItem
                {
                    Text = x.FirstName + " " + x.LastName,
                    Value = x.CustomerId.ToString()
                }).ToList();

            // Ürünleri dropdown için listeliyoruz
            List<SelectListItem> products = _myContext.Products
                .Where(x => x.ProductStock > 0)
                .Select(x => new SelectListItem
                {
                    Text = x.ProductName + " (Stok: " + x.ProductStock + ")",
                    Value = x.ProductId.ToString()
                }).ToList();

            ViewBag.CustomerList = customers;
            ViewBag.ProductList = products;

            return View();
        }

        // Yeni sipariş oluşturma (POST)
        [HttpPost]
        public IActionResult CreateOrder(Order order, List<int> ProductId, int Quantity)
        {
            // Basitlik olması adına şimdilik tek ürünlü sipariş mantığı
            foreach(var item in ProductId)
            {
                var product = _myContext.Products.Find(item);
                if (product == null || product.ProductStock<1)
                {
                    return RedirectToAction("Index");
                }
            }
            
            
            if (product != null)
            {
                // Sipariş detayını oluşturuyoruz
                var detail = new OrderDetail
                {
                    ProductId = ,
                    Unit_Price = product.ProductPrice,
                    Unit_Product_Count = Quantity
                };

                order.OrderDetails = new List<OrderDetail> { detail };
                order.TotalPrice = product.ProductPrice * Quantity;
                order.Total_Product_Count = Quantity;

                // Stoktan düşüyoruz
                product.ProductStock -= Quantity;

                _myContext.Orders.Add(order);
                _myContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Sipariş silme işlemi
        public IActionResult DeleteOrder(int id)
        {
            var order = _myContext.Orders.Find(id);
            if (order != null)
            {
                _myContext.Orders.Remove(order);
                _myContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Sipariş güncelleme sayfası (GET)
        [HttpGet]
        public IActionResult UpdateOrder(int id)
        {
            var order = _myContext.Orders.Find(id);
            return View(order);
        }

        // Sipariş güncelleme (POST)
        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            var value = _myContext.Orders.Find(order.OrderId);
            value.OrderStatus = order.OrderStatus;
            value.PaymentMethod = order.PaymentMethod;
            value.ShippingAddress = order.ShippingAddress;
            value.Notes = order.Notes;

            _myContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
