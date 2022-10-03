using BLL.Domains;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationBlog.Controllers
{
    public class ArticleTagController : Controller
    {
        public readonly ArticlesTagsDomain _articlesTagsDomain;
        public readonly TagsDomain _tagsDomain;
        public readonly ArticlesDomain _articlesDomain;

        public ArticleTagController(ArticlesTagsDomain articlesTagsDomain,TagsDomain tagsDomain,
            ArticlesDomain articlesDomain)
        {
            _articlesTagsDomain = articlesTagsDomain;
            _tagsDomain = tagsDomain;
            _articlesDomain = articlesDomain;
        }

        public IActionResult Index()
        {
            var articlesTags = _articlesTagsDomain.GetAll();
            return View(articlesTags);
        }

        public IActionResult CreateArticlesTags()
        {
            List<Tags> tags = _tagsDomain.GetAll();
            ViewBag.Tags = new SelectList(tags, "Id", "Name");

            List<Articles> articles = _articlesDomain.GetAll();
            ViewBag.Articles = new SelectList(articles, "Id", "Title");

            return View();
        }

        public IActionResult AddArticlesTags(ArticleTags articleTags)
        {
            if (ModelState.IsValid)
            {
                _articlesTagsDomain.Insert(articleTags);
                return RedirectToAction("Index", "ArticleTag");
            }

            List<Tags> tags = _tagsDomain.GetAll();
            ViewBag.Tags = new SelectList(tags, "Id", "Name");

            List<Articles> articles = _articlesDomain.GetAll();
            ViewBag.Articles = new SelectList(articles, "Id", "Title");

            return View("CreateArticlesTags", articleTags);
        }

        public IActionResult EditArticlesTags(int id)
        {
            var articleTags = _articlesTagsDomain.GetById(id);

            List<Tags> tags = _tagsDomain.GetAll();
            ViewBag.Tags = new SelectList(tags, "Id", "Name");

            List<Articles> articles = _articlesDomain.GetAll();
            ViewBag.Articles = new SelectList(articles, "Id", "Title");

            return View(articleTags);
        }

        public IActionResult ModifyArticlesTags(ArticleTags articleTags)
        {
            if (ModelState.IsValid)
            {
                _articlesTagsDomain.Update(articleTags);

                return RedirectToAction("Index", "ArticleTag");
            }

            return View("Index",articleTags);
        }

        public IActionResult DeleteArticlesTags(int id)
        {
            var articleTags = _articlesTagsDomain.GetById(id);

            return View("DeleteArticlesTags",articleTags);
        }

        public IActionResult ConfirmDeleteArticlesTags(int id)
        {
            var articleTags = _articlesTagsDomain.Delete(id);

            return RedirectToAction("Index",articleTags);
        }
    }
}
