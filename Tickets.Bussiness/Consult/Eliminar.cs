using Microsoft.Extensions.Configuration;
using System;
using Tickets.Entities.Consult;

namespace Tickets.Bussiness.Consult
{
    public class Eliminar
    {
        private readonly IConfiguration Configuration;
        public Eliminar(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public  Respuesta Put(int Id)
        {
            try
            {
                DataAccess.Consult.Eliminar eliminar = new DataAccess.Consult.Eliminar(Configuration);
                return eliminar.EliminarUsu(Id);
            }
            catch(Exception ex)
            {
                return  new Respuesta
                {
                    Codigo = 0,
                    Mensaje = "Error: " + ex.Message
                };
            }
        }
    }
}
