using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Entities.Consult;

namespace Tickets.Bussiness.Consult
{
    public class ListaPag
    {
        private readonly IConfiguration Configuration;
        public ListaPag(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Paginador Get(int Registros, int Paginas, string BuscarUsu)
        {
            try
            {
                DataAccess.Consult.ListaPag lista = new DataAccess.Consult.ListaPag(Configuration);
                return lista.Lista(Registros, Paginas, BuscarUsu);
            }
            catch
            {
                throw;
            }
        }
    }
}
