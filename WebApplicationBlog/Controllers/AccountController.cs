using BLL.Domains;
using Blog.BLL.Domains;
using Blog.DAL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBlog.Models;

namespace WebApplicationBlog.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthorsDomain _authorDomain;
        private readonly AdminDomain _adminDomain;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AccountController(AuthorsDomain authorsDomain,
            AdminDomain adminDomain, IWebHostEnvironment hostingEnvironment)
        {
            _authorDomain = authorsDomain;
            _adminDomain = adminDomain;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AddLogin(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (loginViewModel.UserType=="author")
                {
                    bool authorIsExist = _authorDomain.ValidateLogin(loginViewModel.Mail, loginViewModel.Password);
                    if (authorIsExist)
                    {
                        Authors authors = _authorDomain.GetByLogin(loginViewModel.Mail, loginViewModel.Password);
                        HttpContext.Session.SetString("IsLoggedIn", "true");
                        HttpContext.Session.SetString("LoggedInUserId", authors.Id.ToString());
                        HttpContext.Session.SetString("LoggedInUserName", authors.Name);
                        HttpContext.Session.SetString("LoggedInUserMail", authors.Mail);
                        HttpContext.Session.SetString("LoggedInUserType", "author");

                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "InValid email or password");
                    }

                }
                else if (loginViewModel.UserType=="admin")
                {
                    bool adminIsExist = _adminDomain.ValidateLogin(loginViewModel.Mail, loginViewModel.Password);
                    if (adminIsExist)
                    {
                        Admin admin = _adminDomain.GetByLogin(loginViewModel.Mail, loginViewModel.Password);
                        HttpContext.Session.SetString("IsLoggedIn", "true");
                        HttpContext.Session.SetString("LoggedInUserId", admin.Id.ToString());
                        HttpContext.Session.SetString("LoggedInUserName", admin.Name);
                        HttpContext.Session.SetString("LoggedInUserMail", admin.Mail);
                        HttpContext.Session.SetString("LoggedInUserType", "admin");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "InValid email or password");
                    }
                }
            }
            return View("Login", loginViewModel);
        }


        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AddRegister(RegisterViewModel author,IFormFile? photo)
        {
            if (ModelState.IsValid)
            {
                bool isExist = _authorDomain.IsExist(author.Name, author.Mail);
                if (!isExist)
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, photo.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    author.Photo= "/uploads/" + photo.FileName;

                    Authors authorRegister = new Authors()
                    {
                        Id = author.Id,
                        Name=author.Name,
                        Mail=author.Mail,
                        Password=author.Password,
                        Photo=author.Photo
                    };

                    _authorDomain.Insert(authorRegister);
                    ViewBag.Message = "تم التسجيل بنجاح";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Name or Email already exists");
                }
            }
            return View("Register",author);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("IsLoggedIn", "false");

            return RedirectToAction("Index", "Home");
        }
    }
}
