using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoLAgencyApi.Models;
using LoLAgencyApi.Models.ViewModel;
using LoLAgencyApi.Repositorio;

namespace LoLAgencyApi.Controllers
{
    public class NotificacionesController : ApiController
    {
        public IRepositorio<Notificacion, NotificacionesViewModel> Notificaciones { get; set; }

        // GET: api/Notificaciones
        public NotificacionesController()
        {
          
            Notificaciones = new Repositorio<Notificacion, NotificacionesViewModel>(new ApplicationDbContext());
        }
        [HttpGet]
        public IHttpActionResult DameNotificaciones(long num_invocador)
        {

            var data = Notificaciones.Get(o => o.leido == false && o.usuario.num_invocador == num_invocador).ToList();
            if (data != null)
            {
                data.ForEach(o => o.leido = true);
                return Ok(data);
            }

            else
                return NotFound();
        }


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Notificaciones/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Notificaciones
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Notificaciones/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Notificaciones/5
        public void Delete(int id)
        {
        }
    }
}
