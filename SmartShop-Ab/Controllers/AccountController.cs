using Microsoft.AspNetCore.Mvc;
using SmartShop_Ab.Models;

namespace SmartShop_Ab.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login l)
        {
            if (ModelState.IsValid)
            {
                using (UserContext ac = new UserContext())
                {
                    var Result = ac.UserMasters.Where(x => x.UserId == l.UserId && x.Password == l.Password);
                    if (Result.Count() > 0)
                    {
                        var user = Result.FirstOrDefault();
                        HttpContext.Session.SetInt32("role", user.RoleID);
                        HttpContext.Session.SetString("UserId", user.UserId);
                        TempData["msg"] = "1";
                        ModelState.Clear();
                        return RedirectToAction("HomeIndex", "Home");


                    }
                    else
                    {
                        TempData["msg"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserMaster um)
        {
            um.RoleID = 2;

            {
                using (UserContext db = new UserContext())
                {
                    db.UserMasters.Add(um);
                    if (db.SaveChanges() > 0)
                    {
                        TempData["msg"] = "1";
                        ModelState.Clear();
                    }
                    else
                    {
                        TempData["msg"] = "0";
                    }
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
