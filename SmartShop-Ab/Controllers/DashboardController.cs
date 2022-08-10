using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartShop_Ab.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SmartShop_Ab.Controllers
{
    public class DashboardController : Controller
    {
        private UserContext _db;
        private IHostingEnvironment _he;

        public DashboardController(UserContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        [AllowAnonymous]
        public IActionResult Add()
        {
            return View(_db.AddProducts.ToList());
        }
        public IActionResult AddProduct()
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
        //GET Edit Action Method
        
        public ActionResult EditProduct(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var um = _db.AddProducts.Find(Id);
            if (um == null)
            {
                return NotFound();
            }
            return View(um);
        }
        //POST Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(AddProduct um)
        {
            if (ModelState.IsValid)
            {
                _db.Update(um);
                await _db.SaveChangesAsync();
                TempData["msg"] = "Product type has been updated";
                return RedirectToAction("Add", "Dashboard");
            }
            return View(um);
        }

        //GET Details Action Method
        public ActionResult DetailsProduct(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var um = _db.AddProducts.Find(Id);
            if (um == null)
            {
                return NotFound();
            }
            return View(um);
        }
        //POST DetailsProduct Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsProduct(AddProduct um)
        {
            return RedirectToAction("Add","Dashboard");
        }
        //GET Delete Action Method
        public ActionResult DeleteProduct(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var um = _db.AddProducts.Find(Id);
            if (um == null)
            {
                return NotFound();
            }
            return View(um);
        }
        //POST Delete Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(AddProduct um)
        {
            
            if (ModelState.IsValid)
            {
                _db.Remove(um);
                await _db.SaveChangesAsync();
                TempData["msg"] = "Product type has been deleted";
                return RedirectToAction("Add","Dashboard");
            }
            return View(um);
        }
        public IActionResult StockIndex()
        {
            return View(_db.StockManagements.ToList());
        }
        //POST Index action method
        [HttpPost]
        public ActionResult StockIndex(string searchBy, string search)
        {
            if (searchBy == "Quantity")
            {
                return View(_db.StockManagements.Where(x => x.Quantity.Equals(search) || search == null).ToList());
            }
            else
            {
                return View(_db.StockManagements.Where(x => x.ProductName.StartsWith(search) || search == null).ToList());
            }
           
        }

            //Get Create method
        public IActionResult Create()
        {
            
            return View();
        }
        //Post Create method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockManagement sm,IFormFile image)
        {
            if(!ModelState.IsValid)
            {
               
                if (image!=null)
                {
                    var name=Path.Combine(_he.WebRootPath+"/images",Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    sm.ProductImage = "images/" +image.FileName;
                }
                if(image==null)
                {
                    sm.ProductImage = "images/noimage.jpg";
                }
                _db.StockManagements.Add(sm);
                await _db.SaveChangesAsync();
                return RedirectToAction("StockIndex", "Dashboard");
            }
            return View(sm);
        }
        //get Edit Action
        public ActionResult Edit(int? Id)
        {

            if (Id == null)
            {
                return NotFound();
            }
            var sm=_db.StockManagements.FirstOrDefault(c => c.Id==Id);
            if (sm == null)
            {
                return NotFound();
            }
            return View(sm);
        }
        //post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StockManagement sm,IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    sm.ProductImage = "images/" + image.FileName;
                }
                if (image == null)
                {
                    sm.ProductImage = "images/noimage.jpg";
                }
                _db.StockManagements.Update(sm);
                await _db.SaveChangesAsync();
                return RedirectToAction("StockIndex", "Dashboard");
            }
            return View(sm);
        }
        //Get Details
        public ActionResult Details(int? Id)
        {
            if(Id==null)
            {
                return NotFound();
            }
            var sm = _db.StockManagements.FirstOrDefault(c => c.Id == Id);
            if (sm == null)
            {
                return NotFound();
            }
            return View(sm);
        }
        //get Delete Action
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var sm=_db.StockManagements.FirstOrDefault();
            if (sm == null)
            {
                return NotFound();
            }
            return View(sm);
        }
        //POST Delete Action Method
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var sm=_db.StockManagements.FirstOrDefault(c=>c.Id == Id);
            if(sm == null)
            {
                return NotFound();
            }
            _db.StockManagements.Remove(sm);
            await _db.SaveChangesAsync();
            return RedirectToAction("StockIndex", "Dashboard");
        }
         public IActionResult Home()
        {
            using (UserContext db = new UserContext())
            {
                TempData["msg"]=db.AddProducts.ToList();
            }
            return View();
        }
        //get product card action 
        public IActionResult Card()
        {
            return View();
        }
        public IActionResult Search(string Empsearch)
        {
            ViewData["search"] = Empsearch;
            using (UserContext db = new UserContext())
            {
                TempData["emp"] = db.StockManagements.Where(x => x.ProductName.Contains(Empsearch)).ToList();
            }
            return View();
        }
    }
}
