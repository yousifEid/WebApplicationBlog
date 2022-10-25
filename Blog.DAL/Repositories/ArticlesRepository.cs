using DAL.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArticlesRepository
    {
        private BlogDbContext _db;

        public ArticlesRepository(BlogDbContext db)
        {
            _db = db;
        }

        public Articles Insert(Articles articles)
        {
            _db.Articles.Add(articles);
            _db.SaveChanges();
            return articles;
        }

        public Articles Update(Articles articles)
        {
            _db.Entry(articles).State = EntityState.Modified;
            _db.SaveChanges();
            return articles;
        }

        public Articles Delete(int id)
        {
            var articles = _db.Articles.Include(e => e.Authors).Where(e => e.Id == id).FirstOrDefault();
            _db.Entry(articles).State = EntityState.Deleted;
            _db.Articles.Remove(articles);
            _db.SaveChanges();
            return articles;
        }

        public List<Articles> GetAll()
        {
            var articles = _db.Articles.Include(e => e.Authors).ToList();

            return articles;
        }

        public Articles GetById(int id)
        {
            var articles = _db.Articles.Include(e => e.Authors).Where(e => e.Id == id).FirstOrDefault();
            return articles;
        }

        public List<Articles> GetLastArticle()
        {
            var articles = _db.Articles.Include(e => e.Authors).Take(3).OrderByDescending(e => e.Id).ToList();
            return articles;
        }

        public Articles GetArticleById(int id)
        {
            var article = _db.Articles.Where(e => e.Id == id).Include(e => e.Authors)
             .Include(e => e.ArticleTags).FirstOrDefault();
            return article;
        }

        public List<Articles> GetArticleByAuthorId(int id)
        {
            var article = _db.Articles.Where(e => e.AuthorsId == id).Include(e => e.Authors)
            .Include(e => e.ArticleTags).ToList();
            return article;
        }

        public List<ArticleTags> GetArticleByTagId(int id)
        {
            var articleTags = _db.ArticleTags.Where(e => e.TagsId == id).
            Include(e => e.Articles).Include(e => e.Articles).ToList();

            return articleTags;
        }

        public Articles IncreaseViewsCount(int id)
        {
            var article = _db.Articles.Where(e => e.Id == id).Include(e => e.Authors)
            .Include(e => e.ArticleTags).FirstOrDefault();

            article.ViewsCount += 1;

            Update(article);

            return article;
        }

        public List<ArticleTags> GetTagsByArticleId(int id)
        {
            var tags = _db.ArticleTags.Where(e => e.ArticlesId == id).Include(e => e.Tags).ToList();
            return tags;
        }

        public List<Articles> SearchResult(Articles articles)
        {
            List<Articles> foundArticles = _db.Articles.Where(e => e.Title.Contains(articles.Title))
                                     .Include(e => e.Authors)
                                     .ToList();
            return foundArticles;
        }
    }
}
