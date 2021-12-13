using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterWebsiteProject.Models
{
    public class Experience
    {

        [Key]
        public int ExperienceID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string ExperienceName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Summary { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Warning { get; set; }

        [ForeignKey("Theaters")]
        public int TheaterID { get; set; }

        public virtual Theater Theater { get; set; }

    }
}
