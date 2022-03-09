using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Tickets.Entities.Consult;

namespace Tickets.Controllers
{
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public TicketController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Post para crear un ticket
        /// </summary>
        /// <param name="Usuario">Parametro de tipo string, nombre de usuario</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/crear")]
        public IActionResult Create (string Usuario)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Bussiness.Consult.Crear crear = new Bussiness.Consult.Crear(Configuration);
                    Respuesta respuesta = crear.Post(Usuario);
                    if(respuesta.Codigo == 1)
                    {
                        return Ok(respuesta);
                    }
                    else
                    {
                        return BadRequest(respuesta);
                    }
                }
                catch(Exception ex)
                {
                    return BadRequest(new Respuesta
                    {
                        Codigo = 0,
                        Mensaje = "Error: " + ex.Message
                    });
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(message);
            }
        }

        /// <summary>
        /// Put para editar ticket
        /// </summary>
        /// <param name="editar">Parametros del ticket a editar</param>
        /// <param name="Id">Parametros tipo int, id del ticket a editar</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Editar/{Id}")]
        public IActionResult Editar(Editar editar, int Id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Bussiness.Consult.Editar edit = new Bussiness.Consult.Editar(Configuration);
                    Respuesta respuesta = edit.Put(editar, Id);
                    if (respuesta.Codigo == 1)
                    {
                        return Ok(respuesta);
                    }
                    else
                    {
                        return BadRequest(respuesta);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(new Respuesta
                    {
                        Codigo = 0,
                        Mensaje = "Error: " + ex.Message
                    });
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(message);
            }
        }

        /// <summary>
        /// Put para eliminar ticket
        /// </summary>
        /// <param name="Id">Parametros tipo int, id del ticket a eliminar</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/eliminar/{Id}")]
        public IActionResult Eliminar(int Id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Bussiness.Consult.Eliminar eliminar = new Bussiness.Consult.Eliminar(Configuration);
                    Respuesta respuesta = eliminar.Put(Id);
                    if (respuesta.Codigo == 1)
                    {
                        return Ok(respuesta);
                    }
                    else
                    {
                        return BadRequest(respuesta);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(new Respuesta
                    {
                        Codigo = 0,
                        Mensaje = "Error: " + ex.Message
                    });
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(message);
            }
        }

        /// <summary>
        /// Get. Lista los tickets Creados, ya sea uno en especifico o todos 
        /// </summary>
        /// <param name="RegistrosPorPagina">Numero de cantidad de registros por pagina</param>
        /// <param name="Pagina">Numero de pagina</param>
        /// /// <param name="BuscarUsu">Buscar usuario especifico</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/lista")]
        public IActionResult Lista(int RegistrosPorPagina, int Pagina, string BuscarUsu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Bussiness.Consult.ListaPag lista = new Bussiness.Consult.ListaPag(Configuration);
                    return Ok(lista.Get(RegistrosPorPagina,Pagina,BuscarUsu));
                }
                catch (Exception ex)
                {
                    return BadRequest(new Respuesta
                    {
                        Codigo = 0,
                        Mensaje = String.Format("Error: {0}  Descripcion: {1}", ex.Message,ex.StackTrace)
                    });
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(message);
            }
        }
    }
}
