using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Tickets.DataAccess.EntityFramework;
using Tickets.DataAccess.Models;
using Tickets.Entities.Consult;

namespace Tickets.DataAccess.Consult
{
    public class Crear
    {
        private readonly string Configuration;
        public Crear(IConfiguration configuration)
        {
            Configuration = configuration["ConnectionStrings:Connection"].ToString();
        }
        public  Respuesta CrearUsu(string usuario)
        {
            Respuesta respuesta;
            using (ModDbContext db = new ModDbContext(Configuration))
            {
                try
                {
                    if(db.Ticket.Where( x => x.Usuario == usuario).Count() < 1)
                    {
                        Ticket ticket = new Ticket
                        {
                            Usuario = usuario,
                            Status = true,
                            FechaCreacion = DateTime.Now,
                            FechaActualizacion = DateTime.Now
                        };
                        db.Ticket.Add(ticket);
                        db.SaveChanges();

                        respuesta = new Respuesta
                        {
                            Codigo = 1,
                            Mensaje = "Se registro correctamente usuario"
                        };
                    }
                    else
                    {
                        respuesta = new Respuesta
                        {
                            Codigo = 0,
                            Mensaje = "Usuario ya se encuentra registrado"
                        };
                    }
                }
                catch(Exception ex )
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
