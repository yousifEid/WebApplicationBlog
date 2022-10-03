using BLL.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationBlog.Models;

namespace WebApplicationBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArticlesDomain _articlesDomain;
        private readonly AuthorsDomain _authorsDomain;
        private readonly TagsDomain _tagsDomain;
        public HomeController(ILogger<HomeController> logger,ArticlesDomain articleDomain,
            AuthorsDomain authorsDomain,TagsDomain tagsDomain)
        {
            _logger = logger;
            _articlesDomain = articleDomain;
            _authorsDomain = authorsDomain;
            _tagsDomain = tagsDomain;
        }

        public IActionResult Index()
        {
            var articles = _articlesDomain.GetLastArticle();
            var authors = _authorsDomain.GetLastAuthors();
            ViewBag.Authors = authors;
            var tags = _tagsDomain.GetRandomTag();
            ViewBag.TagName = tags;
            return View(articles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}