using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using LoLAgencyApi.Models;
using LoLAgencyApi.Models.ViewModel;
using LoLAgencyApi.Repositorio;
using Newtonsoft.Json;
using RiotApi.Net.RestClient;
using RiotApi.Net.RestClient.Configuration;

namespace LoLAgencyApi.Controllers
{
    public class LogrosController : ApiController
    {
        private readonly UtilsRiot _utilsRiot;
        public IRiotClient riotClient = new RiotClient(ConfigurationManager.AppSettings["apikey"]);
        public IRepositorio<Usuarios, UsuarioViewModel> Repositorio { get; set; }

        public LogrosController()
        {
            var db = new MedallasEntities();
            Repositorio = new Repositorio<Usuarios, UsuarioViewModel>(db);
            _utilsRiot = new UtilsRiot(this);
        }

     

        [HttpGet]
        [ResponseType(typeof (string))]
        public IHttpActionResult DameDivision(long jugador, RiotApiConfig.Regions servidor)
        {
           
            try
            {
                var summoner = riotClient.League.GetSummonerLeaguesByIds(servidor, jugador).FirstOrDefault().Value;
                var division = summoner;

                return Ok(division.First().Tier.ToString());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult Existe(long num_invocador)
        {
            var data = Repositorio.Get(o => o.num_invocador == num_invocador).FirstOrDefault();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
          
        }


        [HttpGet]
        [ResponseType(typeof (int))]
        public IHttpActionResult DameIdInvocador(string jugador, RiotApiConfig.Regions servidor)
        {
            try
            {
                var summoner = riotClient.Summoner.GetSummonersByName(servidor, jugador).FirstOrDefault().Value;

                return Ok(summoner.Id);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult DameTodo(string jugador, string servidor)
        {
            var id_server = 0;
            var region = RiotApiConfig.Regions.EUW;
            long num_invocador = 0;
            switch (servidor)
            {
                case "euw":
                    region = RiotApiConfig.Regions.EUW;
                    id_server = 1;
                    break;
            }
            var id = 10;

            var response = DameIdInvocador(jugador, region).ExecuteAsync(CancellationToken.None).Result;

            num_invocador = response.Content.ReadAsAsync<int>().Result;



            var division = "";
           
            var divi = DameDivision(num_invocador, region);
            if (divi.ExecuteAsync(CancellationToken.None).Result.StatusCode == HttpStatusCode.NotFound)
            {
                division = "Unranked";
            }
            else
            {
                division =
             DameDivision(num_invocador, region)
                 .ExecuteAsync(CancellationToken.None)
                 .Result.Content.ReadAsStringAsync()
                 .Result;
            }

            var data = Existe(num_invocador);

            var model = new UsuarioViewModel();


            if (data.ExecuteAsync(CancellationToken.None).Result.StatusCode == HttpStatusCode.NotFound)
            {
            
                var nuevoInvocador = new UsuarioViewModel
                {
                    num_invocador = num_invocador,
                    nick = jugador,
                    lastindexgame = 0,
                    server = id_server,
                    Id=0
                };
                Repositorio.Add(nuevoInvocador);
            }
            else
            {

                var jssonstring = data.ExecuteAsync(CancellationToken.None).Result.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<UsuarioViewModel>(jssonstring);
                id = model.Id;
                num_invocador = model.num_invocador;
            }
           
           

            var Logros = new UsuarioViewModel();


            var lastindex = 0;


            var stats = _utilsRiot.ListadePartidas(num_invocador, region);
            Logros.doblekill += stats.Count(o => o.DoubleKills > 0);
            Logros.triplekill += stats.Count(o => o.TripleKills > 0);
            Logros.quadrakill += stats.Count(o => o.QuadraKills > 0);
            Logros.pentakill += stats.Count(o => o.PentaKills > 0);
            Logros.doble_doble += stats.Count(o => o.Kills > 9 && o.Assists > 9);
            Logros.asesino += stats.Count(o => o.Kills > 2 && o.Kills < 6);
            Logros.monstruo += stats.Count(o => o.Kills > 5 && o.Kills < 10);
            Logros.heroe += stats.Count(o => o.Kills > 9 && o.Kills < 12);
            Logros.conquistador += stats.Count(o => o.Kills > 11);
            Logros.observer += stats.Count(o => o.WardsPlaced > 9 && o.WardsPlaced < 15);
            Logros.ward_dispenser += stats.Count(o => o.WardsPlaced > 14 && o.WardsPlaced < 20);
            Logros.nofog += stats.Count(o => o.WardsPlaced > 19 && o.WardsPlaced < 25);
            Logros.sauron += stats.Count(o => o.WardsKilled > 24);
            Logros.cantseeme += stats.Count(o => o.WardsKilled > 4 && o.WardsKilled < 10);
            Logros.john_cena += stats.Count(o => o.WardsKilled > 9 && o.WardsKilled < 15);
            Logros.piquete_ojos += stats.Count(o => o.WardsKilled > 14 && o.WardsKilled < 20);
            Logros.cegador += stats.Count(o => o.WardsKilled > 19);
            Logros.bulletproof += stats.Count(o => o.Deaths == 3);
            Logros.die_hard += stats.Count(o => o.Deaths == 5);
            Logros.mc_hammer += stats.Count(o => o.Deaths == 4);
            Logros.intocable += stats.Count(o => o.Deaths == 2);
            Logros.invencible += stats.Count(o => o.Deaths == 1);
            Logros.indestructible += stats.Count(o => o.Deaths == 0);
            Logros.trasto +=
                stats.Count(o => o.TotalDamageDealtToChampions >= 3000 && o.TotalDamageDealtToChampions < 5000);
            Logros.rebel +=
                stats.Count(o => o.TotalDamageDealtToChampions >= 5000 && o.TotalDamageDealtToChampions < 10000);
            Logros.macarra +=
                stats.Count(o => o.TotalDamageDealtToChampions >= 10000 && o.TotalDamageDealtToChampions < 15000);
            Logros.maton +=
                stats.Count(o => o.TotalDamageDealtToChampions >= 15000 && o.TotalDamageDealtToChampions < 20000);
            Logros.overlord += stats.Count(o => o.TotalDamageDealtToChampions >= 20000);
            Logros.lastindexgame = stats.Count();
            Logros.nick = jugador;
           
            Logros.server = id_server;
            Logros.num_invocador = num_invocador;
            Logros.division = division;
           var existe= Repositorio.Get(o => o.num_invocador == Logros.num_invocador);
            if(existe!=null)

            {
                Logros.Id = existe.FirstOrDefault().Id;
                Repositorio.Actualizar(Logros);
            }
            else
            {
                Repositorio.Add(Logros);
            }
          
            return Ok(Logros);
        }
    }
}