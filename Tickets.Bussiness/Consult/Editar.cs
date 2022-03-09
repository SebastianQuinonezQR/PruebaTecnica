using Microsoft.Extensions.Configuration;
using System;
using Tickets.Entities.Consult;

namespace Tickets.Bussiness.Consult
{
    public class Editar
    {
        private readonly IConfiguration Configuration;
        public Editar(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public  Respuesta Put(Entities.Consult.Editar editar, int Id)
        {
            try
            {
                DataAccess.Consult.Editar edit = new DataAccess.Consult.Editar(Configuration);
                return edit.EditarUsu(Id, editar);
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
