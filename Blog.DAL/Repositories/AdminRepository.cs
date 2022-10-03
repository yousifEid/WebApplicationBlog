using Blog.DAL.Models;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repositories
{
    public class AdminRepository
    {
        private BlogDbContext _db;

        public AdminRepository(BlogDbContext db)
        {
            _db = db;
        }

        public Admin Insert(Admin admin)
        {
            _db.Admins.Add(admin);
            _db.SaveChanges();
            return admin;
        }

        public Admin Update(Admin admin)
        {
            _db.Entry(admin).State = EntityState.Modified;
            _db.SaveChanges();
            return admin;
        }

        public Admin Delete(int id)
        {
            var admin = _db.Admins.Find(id);
            _db.Entry(admin).State = EntityState.Deleted;
            _db.Admins.Remove(admin);
            _db.SaveChanges();
            return admin;
        }

        public Admin GetById(int id)
        {
            var admin = _db.Admins.Find(id);
            return admin;
        }

        public List<Admin> GetAll()
        {
            var admin = _db.Admins.ToList();

            return admin;
        }

        public bool ValidateLogin(string mail, string password)
        {

            bool isExist = _db.Admins.Any(e => e.Password == password &&
                                                e.Mail == mail);
            return isExist;
        }

        public Admin GetByLogin(string mail, string password)
        {
            var admin = _db.Admins.Where(e => e.Password == password &&
                                                 e.Mail == mail).FirstOrDefault();
            return admin;
        }
    }
}
