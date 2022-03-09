using System.Collections.Generic;

namespace Tickets.Entities.Consult
{
    public class Paginador
    {
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaActual { get; set; }
        public List<Lista> Lista { get; set; }
    }
}
