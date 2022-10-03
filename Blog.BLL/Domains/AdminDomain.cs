using Blog.DAL.Models;
using Blog.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Domains
{
    public class AdminDomain
    {
        public readonly AdminRepository _adminRepository;

        public AdminDomain(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin Insert(Admin admin)
        {
            return _adminRepository.Insert(admin);
        }

        public Admin Update(Admin admin)
        {
            return _adminRepository.Update(admin);
        }


        public Admin Delete(int id)
        {
            return _adminRepository.Delete(id);
        }

        public List<Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public Admin GetById(int id)
        {
            return _adminRepository.GetById(id);
        }

        public bool ValidateLogin(string mail, string password)
        {
            return _adminRepository.ValidateLogin(mail, password);
        }

        public Admin GetByLogin(string mail, string password)
        {
            return _adminRepository.GetByLogin(mail, password);
        }
    }
}
