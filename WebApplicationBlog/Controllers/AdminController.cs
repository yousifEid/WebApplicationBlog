using Blog.BLL.Domains;
using Blog.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminDomain _adminDomain;

        public AdminController(AdminDomain adminDomain)
        {
            _adminDomain = adminDomain;
        }
        public IActionResult Index()
        {
            var admin = _adminDomain.GetAll();
            return View(admin);
        }

        public IActionResult CreateAdmin()
        {
            return View();
        }

        public IActionResult AddAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _adminDomain.Insert(admin);
                return RedirectToAction("Index", "Admin");
            }

            return View("CreateAdmin", admin);
        }

        public IActionResult EditAdmin(int id)
        {
            var admin = _adminDomain.GetById(id);
            return View(admin);
        }

        public IActionResult ModifyAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _adminDomain.Update(admin);

                return RedirectToAction("Index", "Admin");
            }

            return View("Index", admin);
        }

        public IActionResult DeleteAdmin(int id)
        {
            var admin = _adminDomain.GetById(id);
            return View("DeleteAdmin", admin);
        }

        public IActionResult ConfirmDeleteAdmin(int id)
        {
            var admin = _adminDomain.Delete(id);

            return RedirectToAction("Index", admin);
        }
    }
}
