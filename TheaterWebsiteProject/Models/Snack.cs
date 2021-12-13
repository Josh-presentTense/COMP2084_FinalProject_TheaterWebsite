using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterWebsiteProject.Models
{
    public class Snack
    {

        [Key]
        public int SnackID { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Food { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Drink { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Candy { get; set; }

        [ForeignKey("Tickets")]
        public int TicketID { get; set; }

        public virtual Ticket Ticket { get; set; }

    }
}
