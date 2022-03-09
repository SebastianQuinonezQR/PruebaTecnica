using System;

namespace Tickets.Entities.Consult
{
    public class Lista
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Status { get; set; }
    }
}
