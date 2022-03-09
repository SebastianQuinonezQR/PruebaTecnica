using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Tickets.DataAccess.EntityFramework;
using Tickets.DataAccess.Models;
using Tickets.Entities.Consult;

namespace Tickets.DataAccess.Consult
{
    public class Editar
    {
        private readonly string Configuration;
        public Editar(IConfiguration configuration)
        {
            Configuration = configuration["ConnectionStrings:Connection"].ToString();
        }
        public  Respuesta EditarUsu(int Id, Entities.Consult.Editar editar)
        {
            Respuesta respuesta;
            using (ModDbContext db = new ModDbContext(Configuration))
            {
                try
                {
                    Ticket ticket = db.Ticket.Where(x => x.Id == Id).FirstOrDefault();
                    if(ticket.Usuario != null)
                    {
                        ticket.Usuario = editar.Usuario;
                        ticket.Status = editar.Stauts;
                        ticket.FechaActualizacion = DateTime.Now;
                        db.SaveChanges();

                        respuesta = new Respuesta
                        {
                            Codigo = 1,
                            Mensaje = "Se edito correctamente"
                        };
                    }
                    else
                    {
                        respuesta = new Respuesta
                        {
                            Codigo = 0,
                            Mensaje = "No se encontro usuario"
                        };
                    }
                }
                catch(Exception ex)
                {
                    respuesta = new Respuesta
                    {
                        Codigo = 0,
                        Mensaje = "Error: " + ex.Message
                    };
                }
                return respuesta;
            }
        }
    }
}
