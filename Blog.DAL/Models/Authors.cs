using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Authors
    {
        public Authors()
        {
            Articles = new List<Articles>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public string? Name { get; set; }
        
        public string? Topic { get; set; }

        public string? Photo { get; set; }

        public string? Mail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        public List<Articles> Articles { get; set; }
    }
}
