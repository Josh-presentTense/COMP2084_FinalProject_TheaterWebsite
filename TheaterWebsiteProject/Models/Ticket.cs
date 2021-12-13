using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterWebsiteProject.Models
{
    public class Ticket
    {

        [Key]
        public int TicketID { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime TicketDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Category { get; set; }

        [ForeignKey("Movies")]
        public int MovieID { get; set; }

        [ForeignKey("Theaters")]
        public int TheaterID { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Theater Theater { get; set; }

    }
}
