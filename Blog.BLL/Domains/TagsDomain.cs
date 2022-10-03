using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    
    public class TagsDomain
    {
        public readonly TagsRepository _tagsRepository;

        public TagsDomain(TagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public Tags Insert(Tags tags)
        {
            return _tagsRepository.Insert(tags);
        }

        public Tags Update(Tags tags)
        {
            return _tagsRepository.Update(tags);
        }

        public Tags Delete(int id)
        {
            return _tagsRepository.Delete(id);
        }

        public List<Tags> GetAll()
        {
            return _tagsRepository.GetAll();
        }

        public Tags GetById(int id)
        {
            return _tagsRepository.GetById(id);
        }

        public List<Tags> GetRandomTag()
        {
            return _tagsRepository.GetRandomTag();
        }

        public Tags GetTagById(int id)
        {
            return _tagsRepository.GetTagById(id);
        }
    }
}
