using Blog.DAL.ViewModels;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories;
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

        public List<Articles> GetLastArticle()
        {
            return _articlesRepository.GetLastArticle();
        }

        public Articles GetArticleById(int id)
        {
            return _articlesRepository.GetArticleById(id);
        }

        public List<Articles> GetArticleByAuthorId(int id)
        {
            return _articlesRepository.GetArticleByAuthorId(id);
        }

        public List<ArticleTags> GetArticleByTagId(int id)
        {
            return _articlesRepository.GetArticleByTagId(id);
        }

        public Articles IncreaseViewsCount(int id)
        {
            return _articlesRepository.IncreaseViewsCount(id);
        }

        public List<ArticleTags> GetTagsByArticleId(int id)
        {
            return _articlesRepository.GetTagsByArticleId(id);
        }

        public PaginationViewModel SearchResult(Articles articles, int pageIndex, int pageSize)
        {
            return _articlesRepository.SearchResult(articles, pageIndex, pageSize);
        }

       
    }
}
