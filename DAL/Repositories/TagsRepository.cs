using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TagsRepository
    {
        private BlogDbContext db = new BlogDbContext();

        public Tags Insert(Tags tags)
        {
            db.Tags.Add(tags);
            db.SaveChanges();
            return tags;
        }

        public Tags Update(Tags tags)
        {
            db.Entry(tags).State = EntityState.Modified;
            db.SaveChanges();
            return tags;
        }

        public Tags Delete(int id)
        {
            var tags = db.Tags.Find(id);
            db.Entry(tags).State = EntityState.Deleted;
            db.Tags.Remove(tags);
            db.SaveChanges();
            return tags;
        }

        public List<Tags> GetAll()
        {
            var tags = db.Tags.ToList();

            return tags;
        }

        public Tags GetById(int id)
        {
            var tags = db.Tags.Find(id);
            return tags;
        }
    }
}
