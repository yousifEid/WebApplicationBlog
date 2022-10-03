using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArticlesRepository
    {
        private BlogDbContext db = new BlogDbContext();

        public Articles Insert(Articles articles)
        {
            db.Articles.Add(articles);
            db.SaveChanges();
            return articles;
        }

        public Articles Update(Articles articles)
        {
            db.Entry(articles).State = EntityState.Modified;
            db.SaveChanges();
            return articles;
        }

        public Articles Delete(int id)
        {
            var articles = db.Articles.Find(id);
            db.Entry(articles).State = EntityState.Deleted;
            db.Articles.Remove(articles);
            db.SaveChanges();
            return articles;
        }

        public List<Articles> GetAll()
        {
            var articles = db.Articles.Include(e=>e.Authors).ToList();

            return articles;
        }

        public Articles GetById(int id)
        {
            var articles = db.Articles.Find(id);
            return articles;
        }
    }
}
