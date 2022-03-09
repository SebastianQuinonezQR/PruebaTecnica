using Microsoft.Extensions.Configuration;
using System;
using Tickets.Entities.Consult;

namespace Tickets.Bussiness.Consult
{
    public class Crear
    {
        private readonly IConfiguration Configuration;
        public Crear(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public  Respuesta Post(string Usuario)
        {
            try
            {
                DataAccess.Consult.Crear crear = new DataAccess.Consult.Crear(Configuration);
                return crear.CrearUsu(Usuario);
            }
            catch(Exception ex)
            {
                return new Respuesta
                {
                    Codigo = 0,
                    Mensaje = "Error: " + ex.Message
                };
            }
        }
    }
}
