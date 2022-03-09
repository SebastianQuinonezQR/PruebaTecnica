using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Tickets.DataAccess.EntityFramework;
using Tickets.DataAccess.Models;
using Tickets.Entities.Consult;

namespace Tickets.DataAccess.Consult
{
    public class Eliminar
    {
        private readonly string Configuration;
        public Eliminar(IConfiguration configuration)
        {
            Configuration = configuration["ConnectionStrings:Connection"].ToString();
        }
        public  Respuesta EliminarUsu(int Id)
        {
            Respuesta respuesta;
            using (ModDbContext db = new ModDbContext(Configuration))
            {
                try
                {
                    Ticket ticket = db.Ticket.Where(x => x.Id == Id).FirstOrDefault();
                    if (ticket.Usuario != null)
                    {
                        ticket.Status = false;
                        ticket.FechaActualizacion = DateTime.Now;
                        db.SaveChanges();

                        respuesta = new Respuesta
                        {
                            Codigo = 1,
                            Mensaje = "Se elimino correctamente"
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
                catch (Exception ex)
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
