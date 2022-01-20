using Microsoft.AspNetCore.Mvc;
using PMS.Data;
using PMS.Models;
using PMS.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private ApplicationDbContext _context;

        public OrderController(ApplicationDbContext db)
        {
            _context = db;
        }

        //GET Checkout actioin method

        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Checkout(Order anOrder)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.PorductId = product.ProductId;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }

            anOrder.OrderNo = GetOrderNo();
            _context.Orders.Add(anOrder);
            await _context.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<Product>());
            return View();
        }


        public string GetOrderNo()
        {
            int rowCount = _context.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }
    }
}
