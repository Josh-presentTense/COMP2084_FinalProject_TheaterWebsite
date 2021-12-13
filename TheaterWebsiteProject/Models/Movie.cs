using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterWebsiteProject.Models
{
    public class Movie
    {

        [Key]
        public int MovieID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RunTime { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Genre { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Rating { get; set; }

        [ForeignKey("Theaters")]
        public int TheaterID { get; set; }

        public virtual Theater Theater { get; set; }

    }
}
