using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tickets.DataAccess.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tic_Id")]
        public int Id { get; set; }
        [Column("tic_Usuario")]
        public string Usuario { get; set; }
        [Column("tic_FechaCreacion")]
        public DateTime FechaCreacion { get; set; }
        [Column("tic_FechaActualizacion")]
        public DateTime FechaActualizacion { get; set; }
        [Column("tic_Status")]
        public bool Status { get; set; }
    }
}
