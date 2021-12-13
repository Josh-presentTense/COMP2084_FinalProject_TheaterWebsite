using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterWebsiteProject.Models
{
    public class Theater
    {
        [Key]
        public int TheaterID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string TheaterName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string TheaterAddress { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string TheaterCity { get; set; }

        [Required]
        [Column(TypeName = "varchar(2)")]
        public string TheaterProvince { get; set; }

        [Required]
        [Column(TypeName = "varchar(7)")]
        public string TheaterPostalCode { get; set; }
    }
}
