using BLL.Domains;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBlog.Controllers
{
    public class AuthorController : Controller
    {
        public readonly AuthorsDomain _authorsDomain;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public readonly ArticlesDomain _articlesDomain;
        

        public AuthorController(AuthorsDomain authorsDomain, IWebHostEnvironment webHostEnvironment,
            ArticlesDomain articlesDomain)
        {
            _authorsDomain = authorsDomain;
            _hostingEnvironment = webHostEnvironment;
            _articlesDomain = articlesDomain;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("LoggedInUserType") == "author")
            {
                int loggedInUserId = int.Parse(HttpContext.Session.GetString("LoggedInUserId"));
                var authors = _authorsDomain.GetAuthorById(loggedInUserId);
                return View(authors);
            }
            else
            {
                var authors = _authorsDomain.GetAll();
                return View(authors);
            }
        }

        public IActionResult CreateAuthors()
        {
            return View();
        }

        public IActionResult AddAuthors(Authors authors, IFormFile? photo)
        {
            if (ModelState.IsValid)
            {
                if (photo!=null)
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, photo.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    authors.Photo = "/uploads/" + photo.FileName;
                }
                _authorsDomain.Insert(authors);
                return RedirectToAction("Index", "Author");
            }

            return View("CreateAuthors", authors);
        }

        public IActionResult EditAuthors(int id)
        {
            var authors = _authorsDomain.GetById(id);

            return View(authors);
        }

        public IActionResult ModifyAuthors(Authors authors, IFormFile? photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", photo.FileName);
                    using (var newFile = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(newFile);
                    }
                    authors.Photo = "/uploads/" + photo.FileName;
                }

                _authorsDomain.Update(authors);

                return RedirectToAction("Index", "Author");
            }

            return View("EditAuthors", authors);
        }

        public IActionResult DeleteAuthors(int id)
        {
            var author = _authorsDomain.GetById(id);

            return View("DeleteAuthors", author);
        }

        public IActionResult ConfirmDeleteAuthors(int id)
        {
            var author = _authorsDomain.Delete(id);

            return RedirectToAction("Index", author);
        }

        public IActionResult AuthorDetails(int id)
        {
            var author = _authorsDomain.GetAuthorById(id);
            var articles = _articlesDomain.GetArticleByAuthorId(id);
            ViewBag.ArticleTitle = articles;
            return View(author.FirstOrDefault());
        }
    }
}
