using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ArticleTags
    {
        [Key]
        public int Id { get; set; }



        [ForeignKey(nameof(Tags))]
        public int TagsId { get; set; }
        public Tags Tags { get; set; }



        [ForeignKey(nameof(Articles))]
        public int ArticlesId { get; set; }
        public Articles Articles { get; set; }
    }
}
