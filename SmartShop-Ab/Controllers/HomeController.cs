using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartShop_Ab.Models;
using SmartShop_Ab.Utility;
using X.PagedList;


namespace SmartShop_Ab.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _db;
        public HomeController(UserContext db)
        {
            _db = db;
        }
        public IActionResult HomeIndex(int? page)
        {
            return View(_db.StockManagements.ToList().ToPagedList());
        }
        //GET product detail acation method
        public ActionResult HomeDetail(int? Id)
        {

            if (Id == null)
            {
                return NotFound();
            }

            var um = _db.StockManagements.FirstOrDefault(c => c.Id == Id);
            if (um == null)
            {
                return NotFound();
            }
            return View(um);
        }
        //POST product detail acation method
        [HttpPost]
        [ActionName("Detail")]
        public ActionResult Detail(int? Id)
        {
            List<StockManagement> products = new List<StockManagement>();
            if (Id == null)
            {
                return NotFound();
            }
            var um = _db.StockManagements.FirstOrDefault(c => c.Id == Id);
            if (um == null)
            {
                return NotFound();
            }
            products = HttpContext.Session.Get<List<StockManagement>>("products");
            if (products == null)
            {
                products = new List<StockManagement>();
            }
            products.Add(um);
            HttpContext.Session.Set("products", products);
            return RedirectToAction("HomeIndex", "Home");
        }
        //GET Remove action methdo
        [ActionName("Remove")]
        public IActionResult RemoveToCart(int? id)
        {
            List<AddProduct> products = HttpContext.Session.Get<List<AddProduct>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction("HomeIndex","Home");
        }
        //GET product Cart action method
        public IActionResult Cart()
        {
           return View(_db.AddProducts.ToList());
        }
        public IActionResult AddCart()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProduct um)  
        {

            if (ModelState.IsValid)
            {

                _db.AddProducts.Add(um);
                await _db.SaveChangesAsync();
                TempData["msg"] = "Product type has been saved";
                return RedirectToAction("Add", "Dashboard");
            }
            return View(um);
        }

    }
}
