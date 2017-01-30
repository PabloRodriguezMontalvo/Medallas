using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AriGoldWeb.Models;
using AriGoldWeb.Utils;

public class Servidores
{
    public int Id { get; set; }
    public string Name { get; set; }
}
namespace AriGoldWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var server = new List<Servidores>();
            var unserver = new Servidores();
          

            unserver.Id = 1;
            unserver.Name = "EUW";
            server.Add(unserver);
           
            
            ViewBag.server = new SelectList(server,"Id","Name");
        

            return View();
        }

        [HttpGet]
        public JsonResult GetNews(string server, string nombre)
        {
            var _servicio = DependencyResolver.Current.
           GetService<Servicios<UsuarioViewModel>>();
            var data = _servicio.Logros(nombre, server);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserInBD(long num_invocador)
        {
            var _servicio = DependencyResolver.Current.
           GetService<Servicios<UsuarioViewModel>>();
            var data = _servicio.Logros(num_invocador);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult LeerNotificaciones(long num_invocador)
        //{
        //    var notificaciones = DependencyResolver.Current.
        //    GetService<Servicios<NotificacionesViewModel>>();
        //    var data = notificaciones.DameNotificaciones(num_invocador);
        //    //data.ForEach(o => o.leido = true);
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //[HttpGet]
        //public JsonResult GetAll()
        //{
        //    var _servicio = DependencyResolver.Current.
        //   GetService<Servicios<UsuarioViewModel>>();
        //    var data = _servicio.GetAll();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

    }
}