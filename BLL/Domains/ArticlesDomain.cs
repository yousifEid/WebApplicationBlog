using Blog.DAL.Models;
using Blog.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class ArticlesDomain
    {
        public readonly ArticlesRepository _articlesRepository;

        public ArticlesDomain(ArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }
        
        public Articles Insert(Articles articles)
        {
            return _articlesRepository.Insert(articles);
        }

        public Articles Update(Articles articles)
        {
            return _articlesRepository.Update(articles);
        }


        public Articles Delete(int id)
        {
            return _articlesRepository.Delete(id);
        }

        public List<Articles> GetAll()
        {
            return _articlesRepository.GetAll();
        }

        public Articles GetById(int id)
        {
            return _articlesRepository.GetById(id); 
        }
    }
}
