using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext()
        : base("Data Source=.;Initial Catalog=BlogDb;Integrated Security=true")
        {
        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<ArticleTags> ArticleTags { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Tags> Tags { get; set; }
    }
}
