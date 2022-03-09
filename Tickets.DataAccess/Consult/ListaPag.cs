using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Tickets.DataAccess.EntityFramework;
using Tickets.DataAccess.Models;
using Tickets.Entities.Consult;

namespace Tickets.DataAccess.Consult
{
    public class ListaPag
    {
        private readonly string Configuration;
        public ListaPag(IConfiguration configuration)
        {
            Configuration = configuration["ConnectionStrings:Connection"].ToString();
        }
        public  Paginador Lista(int Registros, int Paginas, string BuscarUsu)
        {
            try
            {
                using (ModDbContext db = new ModDbContext(Configuration))
                {
                    List<Ticket> lista =  db.Ticket.ToList();
                    if(!string.IsNullOrEmpty(BuscarUsu))
                    {
                        foreach(var data in BuscarUsu.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            lista = lista.Where(x => x.Usuario.Contains(data)).ToList();
                        }
                    }
                    int TotalRegistros = 1;
                    int TotalPag = 1;
                    int PagActual = 1;

                    TotalRegistros = lista.Count();
                    if(Paginas != 0 ||Registros != 0 )
                    {
                        lista = lista.Skip((Paginas - 1) * Registros).Take(Registros).ToList();
                        TotalPag = (int)Math.Ceiling((double)TotalRegistros / Registros);
                        PagActual = Paginas;
                    }
                    else
                    {
                        lista.ToList();
                    }
                    List<Lista> ListaBl = new List<Lista>();
                    foreach(var listas in lista )
                    {
                        Lista Listas = new Lista
                        {
                            Id = listas.Id,
                            Usuario = listas.Usuario,
                            FechaCreacion = listas.FechaCreacion,
                            FechaActualizacion = listas.FechaActualizacion,
                            Status = listas.Status
                        };
                        ListaBl.Add(Listas);
                    }
                    return new Paginador
                    {
                        RegistrosPorPagina = Registros,
                        TotalRegistros = TotalRegistros,
                        TotalPaginas = TotalPag,
                        PaginaActual = PagActual,
                        Lista = ListaBl
                    };
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
