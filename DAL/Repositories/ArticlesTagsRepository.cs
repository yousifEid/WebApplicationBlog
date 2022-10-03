using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArticlesTagsRepository
    {
        private BlogDbContext db = new BlogDbContext();

        public ArticleTags Insert(ArticleTags articleTags)
        {
            db.ArticleTags.Add(articleTags);
            db.SaveChanges();
            return articleTags;
        }

        public ArticleTags Update(ArticleTags articleTags)
        {
            db.Entry(articleTags).State = EntityState.Modified;
            db.SaveChanges();
            return articleTags;
        }

        public ArticleTags Delete(int id)
        {
            var articleTags = db.ArticleTags.Find(id);
            db.Entry(articleTags).State = EntityState.Deleted;
            db.ArticleTags.Remove(articleTags);
            db.SaveChanges();
            return articleTags;
        }

        public List<ArticleTags> GetAll()
        {
            var articleTags = db.ArticleTags.Include(e=>e.Articles).Include(e=>e.Tags).ToList();

            return articleTags; 
        }

        public ArticleTags GetById(int id)
        {
            var articleTags = db.ArticleTags.Find(id);
            return articleTags;
        }
    }
   
}
