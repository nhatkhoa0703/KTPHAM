using System.Linq;
using System.Web.Mvc;
using KTPHAM.Models;

namespace KTPHAM.Controllers
{
    public class AuthController : Controller
    {
        private KTPHAMDbContext db = new KTPHAMDbContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            // Tìm user với username và password
            var user = db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            if (user != null)
            {
                // Lưu thông tin user vào session
                Session["UserID"] = user.UserID;
                Session["Username"] = user.Username;
                Session["Role"] = user.Role;

                return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang Home
            }

            ViewBag.Error = "Invalid username or password!";
            return View();
        }

        // Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
