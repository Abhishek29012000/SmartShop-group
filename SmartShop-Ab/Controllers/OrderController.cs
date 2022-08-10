using Microsoft.AspNetCore.Mvc;
using SmartShop_Ab.Models;
using SmartShop_Ab.Utility;

namespace SmartShop_Ab.Controllers
{
    public class OrderController : Controller
    {
        private UserContext _db;
        public OrderController(UserContext db)
        {
            _db = db;
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
            List<AddProduct> products = HttpContext.Session.Get<List<AddProduct>>("products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.Id = product.Id;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }
            anOrder.OrderNo = GetOrderNo();
            _db.Orders.Add(anOrder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<AddProduct>());
            return View();
        }
        public string GetOrderNo()
        {
            int rowCount = _db.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }
    }
}

