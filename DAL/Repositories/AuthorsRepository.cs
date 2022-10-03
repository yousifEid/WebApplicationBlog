using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorsRepository
    {
        private BlogDbContext db = new BlogDbContext();

        public Authors Insert(Authors authors)
        {
            db.Authors.Add(authors);
            db.SaveChanges();
            return authors;
        }

        public Authors Update(Authors authors)
        {
            db.Entry(authors).State = EntityState.Modified;
            db.SaveChanges();
            return authors;
        }

        public Authors Delete(int id)
        {
            var authors = db.Authors.Find(id);
            db.Entry(authors).State = EntityState.Deleted;
            db.Authors.Remove(authors);
            db.SaveChanges();
            return authors;
        }

        public List<Authors> GetAll()
        {
            var authors = db.Authors.ToList();

            return authors;
        }

        public Authors GetById(int id)
        {
            var authors = db.Authors.Find(id);
            return authors;
        }
    }
}
