using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Articles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Topic { get; set; }

        public string Photo { get; set; }

        public string ReadTime { get; set; }

        

        [ForeignKey(nameof(Authors))]
        public int AuthorsId { get; set; }
        public Authors Authors { get; set; }



        public List<ArticleTags> ArticleTags { get; set; } 

    }
}
