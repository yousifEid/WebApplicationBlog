using BLL.Domains;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationBlog.Controllers
{
    public class ArticleController : Controller
    {
        public readonly ArticlesDomain _articlesDomain;
        public readonly AuthorsDomain _authorsDomain;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _HttpContextAccessor;

        public ArticleController(ArticlesDomain articlesDomain, AuthorsDomain authorsDomain,
            IWebHostEnvironment webHostEnvironment,IHttpContextAccessor httpContextAccessor)
        {
            _articlesDomain = articlesDomain;
            _authorsDomain = authorsDomain;
            _hostingEnvironment = webHostEnvironment;
            _HttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            if ( _HttpContextAccessor.HttpContext.Session.GetString("LoggedInUserType") == "author")
            {
                int loggedInUserId = int.Parse(HttpContext.Session.GetString("LoggedInUserId"));
                var articles = _articlesDomain.GetArticleByAuthorId(loggedInUserId);
                return View(articles);
            }
                
            else
            {
                var articles = _articlesDomain.GetAll(); 
                return View(articles);
            }

           
        }

        public IActionResult CreateArticles()
        {
            List<Authors> authors = _authorsDomain.GetAll();
            ViewBag.Authors = new SelectList(authors, "Id", "Name");
            return View();
        }

        public IActionResult AddArticles(Articles articles, IFormFile? photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, photo.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    articles.Photo = "/uploads/" + photo.FileName;
                }
                _articlesDomain.Insert(articles);
                return RedirectToAction("Index", "Article");
            }

            List<Authors> authors = _authorsDomain.GetAll();
            ViewBag.Authors = new SelectList(authors, "Id", "Name");

            return View("AddArticles", articles);
        }

        public IActionResult EditArticles(int id)
        {
            var articles = _articlesDomain.GetById(id);

            List<Authors> authors = _authorsDomain.GetAll();
            ViewBag.Authors = new SelectList(authors, "Id", "Name");

            return View(articles);
        }

        public IActionResult ModifyArticles(Articles articles, IFormFile? photo)
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
                    articles.Photo = "/uploads/" + photo.FileName;
                }

                _articlesDomain.Update(articles);

                return RedirectToAction("Index", "Article");
            }

            List<Authors> authors = _authorsDomain.GetAll();
            ViewBag.Authors = new SelectList(authors, "Id", "Name");

            return View("ModifyArticles", articles);
        }

        public IActionResult DeleteArticles(int id)
        {
            var articles = _articlesDomain.GetById(id);

            return View("DeleteArticles", articles);
        }

        public IActionResult ConfirmDeleteArticles(int id)
        {
            var articles = _articlesDomain.Delete(id);

            return RedirectToAction("Index", articles);
        }

        public IActionResult ArticleDetails(int id)
        {
            _articlesDomain.IncreaseViewsCount(id);

            var article = _articlesDomain.GetArticleById(id);
            var tags = _articlesDomain.GetTagsByArticleId(id);
            ViewBag.TagName = tags;
            return View(article);
        }

        //[HttpGet]
        //public IActionResult Search()
        //{
        //    return View();
        //}

        //[HttpPost]
        [HttpGet]
        public IActionResult Search(Articles article, int pageIndex = 1)
        {
            var foundArticle = _articlesDomain.SearchResult(article, pageIndex, 3);
            if (foundArticle!= null)
            {
                ViewBag.IsSearch = true;
                ViewBag.FoundArticle = foundArticle;
            }
            return View(article);
        }

        
    }
}
