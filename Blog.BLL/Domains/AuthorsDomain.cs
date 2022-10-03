using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class AuthorsDomain
    {
        public readonly AuthorsRepository _authorsRepository;

        public AuthorsDomain(AuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public Authors Insert(Authors authors)
        {
            return _authorsRepository.Insert(authors);
        }

        public Authors Update(Authors authors)
        {
            return _authorsRepository.Update(authors);
        }

        public Authors Delete(int id)
        {
            return _authorsRepository.Delete(id);
        }

        public List<Authors> GetAll()
        {
            return _authorsRepository.GetAll();
        }

        public Authors GetById(int id)
        {
            return _authorsRepository.GetById(id);
        }

        public List<Authors> GetLastAuthors()
        {
            return _authorsRepository.GetLastAuthors();
        }

        public List< Authors> GetAuthorById(int id)
        {
            return _authorsRepository.GetAuthorById(id);
        }

        public bool ValidateLogin(string mail, string password)
        {
            return _authorsRepository.ValidateLogin(mail, password);
        }

        public Authors GetByLogin(string mail, string password)
        {
            return _authorsRepository.GetByLogin(mail, password);
        }

        public bool IsExist(string name, string mail)
        {
            return _authorsRepository.IsExist(name, mail);
        }
    }
}
