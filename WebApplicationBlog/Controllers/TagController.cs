using BLL.Domains;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBlog.Controllers
{
    public class TagController : Controller
    {
        public readonly TagsDomain _tagsDomain;
        public readonly ArticlesDomain _articlesDomain;

        public TagController(TagsDomain tagsDomain,ArticlesDomain articlesDomain)
        {
            _tagsDomain = tagsDomain;
            _articlesDomain = articlesDomain;
        }

        public IActionResult Index()
        {
            var tags = _tagsDomain.GetAll();
            return View(tags);
        }

        public IActionResult CreateTags()
        {
            return View();
        }

        public IActionResult AddTags(Tags tags)
        {
            if (ModelState.IsValid)
            {
                _tagsDomain.Insert(tags);
                return RedirectToAction("Index", "Tag");
            }

            return View("CreateTags",tags);
        }

        public IActionResult EditTags(int id)
        {
            var tag = _tagsDomain.GetById(id);
           
            return View(tag);
        }

        public IActionResult ModifyTags(Tags tags)
        {
            if (ModelState.IsValid)
            {
                _tagsDomain.Update(tags);

                return RedirectToAction("Index", "Tag");
            }

            return View("Index", tags);
        }

        public IActionResult DeleteTags(int id)
        {
            var tags = _tagsDomain.GetById(id);

            return View("DeleteTags", tags);
        }

        public IActionResult ConfirmDeleteTags(int id)
        {
            var tags = _tagsDomain.Delete(id);

            return RedirectToAction("Index", tags);
        }

        public IActionResult GetRandomTag()
        {
            return View();
        }

        public IActionResult TagDetails(int id)
        {
            var tag = _tagsDomain.GetTagById(id);
            var articles = _articlesDomain.GetArticleByTagId(id);
            ViewBag.ArticleTitle = articles;
            return View(tag);
        }
    }
}
