using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using LoLAgencyApi.Models;
using LoLAgencyApi.Models.ViewModel;
using LoLAgencyApi.Repositorio;
using LoLAgencyApi.Servicios;
using RiotSharp;
using RiotSharp.GameEndpoint;

namespace LoLAgencyApi.Controllers
{
    public class LogrosController : ApiController
    {
        private const string Temporada = "SEASON2016";
        public List<RawStat> _stats = new List<RawStat>();

        public RiotApi apiriot = RiotApi.GetInstance(ConfigurationManager.AppSettings["apikey"]);

        public LogrosController()
        {
            Repositorio = new Repositorio<Usuario, UsuarioViewModel>(new ApplicationDbContext());
            Notificaciones = new Repositorio<Notificacion, NotificacionesViewModel>(new ApplicationDbContext());
            service = new Trophy();
        }

        public iTrophy service { get; set; }
        public IRepositorio<Usuario, UsuarioViewModel> Repositorio { get; set; }

        //  public IRiotClient riotClient = new RiotClient(ConfigurationManager.AppSettings["apikey"]);


        public IRepositorio<Notificacion, NotificacionesViewModel> Notificaciones { get; set; }


        [HttpGet]
        public IHttpActionResult DameNotificaciones(long num_invocador)
        {
            var data = Notificaciones.Get(o => o.leido == false && o.usuario.num_invocador == num_invocador).ToList();
            if (data != null)
            {
                data.ForEach(o => o.leido = true);
                return Ok(data);
            }

            return NotFound();
        }


        [HttpGet]
        public IHttpActionResult DameTodo(string jugador, Region servidor)
        {
            //TODO: ARREGLAR ESTO
            var user = new UsuarioViewModel();
        

            var IdSummoner = service.GetIdSummoner(jugador, servidor);
           
            if (IdSummoner.Id == 0)
                return NotFound();
       
            var userInDb = service.GetUserFromBD(IdSummoner.Id);
         

            var stats = service.GetGames(IdSummoner, user.lastindexgame);


            var divi = service.GetDivision(IdSummoner);
            if (divi == 0)
                userInDb.division = "Unranked";
            else

                userInDb.division = divi.ToString();
            userInDb.lastindexgame = service.TotalGames(IdSummoner);
            userInDb.num_invocador = IdSummoner.Id;
            userInDb.nick = jugador;
            userInDb.server = GetIdRegion(servidor);
            userInDb = service.CheckTrophy(userInDb, stats);
            if (userInDb!=null)
            {
                Repositorio.Actualizar(userInDb); 
            }
         
         
        

            return Ok(user);
        }

        private static int GetIdRegion(Region servidor)
        {
            switch (servidor)
            {
                case Region.euw:

                    return 1;
                    break;

                case Region.br:

                    return 2;
                    break;

                case Region.eune:

                    return 3;
                    break;
                case Region.kr:

                    return 4;
                    break;
                case Region.lan:

                    return 5;
                    break;
                case Region.global:

                    return 6;
                    break;
                case Region.las:

                    return 7;
                    break;
                case Region.na:

                    return 8;
                    break;
                case Region.oce:

                    return 9;
                    break;
                case Region.ru:

                    return 10;
                    break;
                case Region.tr:

                    return 11;
                    break;

                default:

                    return 0;
                    break;
            }
        }
    }
}