using DAL.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArticlesTagsRepository
    {
        private BlogDbContext _db;

        public ArticlesTagsRepository(BlogDbContext db)
        {
            _db = db;
        }

        public ArticleTags Insert(ArticleTags articleTags)
        {
            _db.ArticleTags.Add(articleTags);
            _db.SaveChanges();
            return articleTags;
        }

        public ArticleTags Update(ArticleTags articleTags)
        {
            _db.Entry(articleTags).State = EntityState.Modified;
            _db.SaveChanges();
            return articleTags;
        }

        public ArticleTags Delete(int id)
        {
            var articleTags = _db.ArticleTags.Include(e => e.Articles).Include(e => e.Tags).Where(e => e.Id == id).FirstOrDefault();
            _db.Entry(articleTags).State = EntityState.Deleted;
            _db.ArticleTags.Remove(articleTags);
            _db.SaveChanges();
            return articleTags;
        }

        public List<ArticleTags> GetAll()
        {
            var articleTags = _db.ArticleTags.Include(e=>e.Articles).Include(e=>e.Tags).ToList();

            return articleTags; 
        }

        public ArticleTags GetById(int id)
        {
            var articleTags = _db.ArticleTags.Include(e=>e.Articles).Include(e=>e.Tags).Where(e=>e.Id==id).FirstOrDefault();
            return articleTags;
        }
    }
   
}
