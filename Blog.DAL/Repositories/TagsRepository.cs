using DAL.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TagsRepository
    {
        private BlogDbContext _db;

        public TagsRepository(BlogDbContext db)
        {
            _db = db;
        }

        public Tags Insert(Tags tags)
        {
            _db.Tags.Add(tags);
            _db.SaveChanges();
            return tags;
        }

        public Tags Update(Tags tags)
        {
            _db.Entry(tags).State = EntityState.Modified;
            _db.SaveChanges();
            return tags;
        }

        public Tags Delete(int id)
        {
            var tags = _db.Tags.Find(id);
            _db.Entry(tags).State = EntityState.Deleted;
            _db.Tags.Remove(tags);
            _db.SaveChanges();
            return tags;
        }

        public List<Tags> GetAll()
        {
            var tags = _db.Tags.ToList();

            return tags;
        }

        public Tags GetById(int id)
        {
            var tags = _db.Tags.Find(id);
            return tags;
        }

        public List<Tags> GetRandomTag()
        {
            var tags = _db.Tags.OrderBy(e => e.Name).ToList();
            return tags;
        }

        public Tags GetTagById(int id)
        {
            var tag = _db.Tags.Where(e => e.Id == id).Include(e => e.ArticleTags).FirstOrDefault();
            return tag;
        }
    }
}
