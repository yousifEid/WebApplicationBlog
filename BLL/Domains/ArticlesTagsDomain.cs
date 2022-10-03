using Blog.DAL.Models;
using Blog.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class ArticlesTagsDomain
    {
        public readonly ArticlesTagsRepository _articlesTagsRepository;

        public ArticlesTagsDomain(ArticlesTagsRepository articlesTagsRepository)
        {
            _articlesTagsRepository = articlesTagsRepository;
        }

        public ArticleTags Insert(ArticleTags articleTags)
        {
            return _articlesTagsRepository.Insert(articleTags);
        }

        public ArticleTags Update(ArticleTags articleTags)
        {
            return _articlesTagsRepository.Update(articleTags);
        }


        public ArticleTags Delete(int id)
        {
            return _articlesTagsRepository.Delete(id);
        }

        public List<ArticleTags> GetAll()
        {
            return _articlesTagsRepository.GetAll();
        }

        public ArticleTags GetById(int id)
        {
            return _articlesTagsRepository.GetById(id);
        }
    }
}
