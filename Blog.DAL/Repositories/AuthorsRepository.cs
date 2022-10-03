using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorsRepository
    {
        private BlogDbContext _db;

        public AuthorsRepository(BlogDbContext db)
        {
            _db = db;
        }

        public Authors Insert(Authors authors)
        {
            _db.Authors.Add(authors);
            _db.SaveChanges();
            return authors;
        }

        public Authors Update(Authors authors)
        {
            _db.Entry(authors).State = EntityState.Modified;
            _db.SaveChanges();
            return authors;
        }

        public Authors Delete(int id)
        {
            var authors = _db.Authors.Find(id);
            _db.Entry(authors).State = EntityState.Deleted;
            _db.Authors.Remove(authors);
            _db.SaveChanges();
            return authors;
        }

        public List<Authors> GetAll()
        {
            var authors = _db.Authors.ToList();

            return authors;
        }

        public Authors GetById(int id)
        {
            var authors = _db.Authors.Find(id);
            return authors;
        }

        public List<Authors> GetLastAuthors()
        {
            var authors = _db.Authors.Take(4).OrderBy(e => Guid.NewGuid()).ToList();
            return authors;
        }

        public List< Authors> GetAuthorById(int id)
        {
            var author = _db.Authors.Where(e => e.Id == id).ToList();
            return author;
        }

        public bool ValidateLogin(string mail, string password)
        {

            bool isExist = _db.Authors.Any(e => e.Password == password &&
                                                e.Mail == mail);
            return isExist;
        }

        public Authors GetByLogin(string mail, string password)
        {
            var authors = _db.Authors.Where(e => e.Password == password &&
                                                 e.Mail == mail).FirstOrDefault();
            return authors;
        }

        public bool IsExist(string name, string mail)
        {
            var isExist = _db.Authors.Any(e => e.Name == name && e.Mail == mail);

            return isExist;
        }
    }
}
