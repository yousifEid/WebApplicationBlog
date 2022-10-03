using Blog.DAL.Models;
using Blog.DAL.Repositories;
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
    }
}
