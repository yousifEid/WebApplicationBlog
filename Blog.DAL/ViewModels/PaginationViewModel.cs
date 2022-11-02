using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.ViewModels
{
    public class PaginationViewModel
    {
        public PaginationViewModel()
        {
            Data = new List<Articles>();
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int ItemsCount { get; set; }

        public List<Articles> Data { get; set; }
    }
}
