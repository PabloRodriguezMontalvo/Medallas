using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using LoLAgencyApi.Models;
using LoLAgencyApi.Models.ViewModel;
using LoLAgencyApi.Repositorio;
using Microsoft.Practices.ObjectBuilder2;
using RiotSharp;
using RiotSharp.GameEndpoint;
using RiotSharp.LeagueEndpoint;
using RiotSharp.MatchEndpoint;
using Season = RiotSharp.StatsEndpoint.Season;

namespace LoLAgencyApi.Controllers
{
    public class LogrosController : ApiController
    {
        private const string Temporada = "SEASON2016";
        public List<RawStat> _stats = new List<RawStat>();
        public RiotApi api = RiotApi.GetInstance(ConfigurationManager.AppSettings["apikey"]);
        public RiotApi apiriot = RiotApi.GetInstance(ConfigurationManager.AppSettings["apikey"]);

        public LogrosController()
        {
            Repositorio = new Repositorio<Usuario, UsuarioViewModel>(new ApplicationDbContext());
            Notificaciones = new Repositorio<Notificacion, NotificacionesViewModel>(new ApplicationDbContext());
        }

        //  public IRiotClient riotClient = new RiotClient(ConfigurationManager.AppSettings["apikey"]);


        public IRepositorio<Usuario, UsuarioViewModel> Repositorio { get; set; }

        public IRepositorio<Notificacion, NotificacionesViewModel> Notificaciones { get; set; }

        [HttpGet]
        [ResponseType(typeof(string))]
        private Tier DameDivision(long jugador, Region servidor)
        {
            try
            {
                var liga = api.GetSummoner(servidor, (int) jugador).GetLeagues().FirstOrDefault().Tier;


                return liga;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        private UsuarioViewModel Existe(long num_invocador)
        {
            var data = Repositorio.Get(o => o.num_invocador == num_invocador).FirstOrDefault();


            return data;
        }


        [HttpGet]
        [ResponseType(typeof(long))]
        private long DameIdInvocador(string jugador, Region servidor)
        {
            try
            {
                var summoner = api.GetSummoner(servidor, jugador);
                return summoner.Id;
            }
            catch (RiotSharpException ex)
            {
                throw ex;
                // Handle the exception however you want.
            }
            //  var summoner = riotClient.Summoner.GetSummonersByName(servidor, jugador).FirstOrDefault().Value;
        }

        [HttpGet]
        private List<RawStat> DameListaPartidas(long jugador, Region servidor, int lastindex)
        {
            _stats = ListadePartidas(jugador, servidor, lastindex);

            return _stats;
        }

        [HttpGet]
        private float DameKDA(List<ParticipantStats> stats)
        {
            float sum = 0;
            float kills = 0;
            float assist = 0;
            foreach (var o in _stats)
            {
                assist += o.Assists;
                kills += o.ChampionsKilled;

                sum += o.NumDeaths;
            }
            var kda = (assist + kills)/sum;

            return kda;
        }


        private List<RawStat> ListadePartidas(long jugador, Region servidor, int lastindex = 0)
        {
            List<RawStat> estadisticas = new List<RawStat>();
            List<Queue> cola = new List<Queue>();
            cola.Add(Queue.TeamBuilderDraftRanked5x5);
            List<Season> seasons = new List<Season>();
            seasons.Add(Season.Season2016);
            //     MatchListDto matchList = new MatchListDto();
            //       string ranktype=
            try
            {
                //  var total_games = riotClient.MatchList.GetMatchListBySummonerId(servidor, jugador, null, Enums.GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5.ToString(), Temporada).TotalGames;
                //    matchList = riotClient.MatchList.GetMatchListBySummonerId(servidor, jugador, null, Enums.GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5.ToString(), Temporada, null, null, lastindex, total_games);
                //     matchList = riotClient.MatchList.GetMatchListBySummonerId(servidor, jugador, null, Enums.GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5.ToString(), Temporada, null, null, null, null);
                var matchList = api.GetRecentGames(servidor, jugador);
                estadisticas = CargarEstadisticas(matchList, jugador, servidor);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }


            return estadisticas;
        }


        private List<RawStat> CargarEstadisticas(List<Game> matchList, long id, Region servidor)
        {
            //        RiotApiConfig.Regions.EUW
            List<RawStat> estadisticas = new List<RawStat>();

            foreach (var partida in matchList)
            {
                try
                {
                    System.Threading.Thread.Sleep(1200);

                    RawStat detalles_partida = partida.Statistics;
                    if (detalles_partida != null)
                    {
                        // int participant_id = GetIDParticipante(detalles_partida, id);
                        //  estadisticas.Add(GetEstadisticasDetalladas(detalles_partida, participant_id));
                        estadisticas.Add(detalles_partida);
                    }
                }
                catch (Exception e)
                {
                    throw e.InnerException;
                }
            }
            return estadisticas;
        }


        private static int GetIDParticipante(MatchDetail detalles_partida, long id)
        {
            foreach (var id_posicion in detalles_partida.ParticipantIdentities)
            {
                if (id_posicion.Player.SummonerId == id)
                {
                    return id_posicion.ParticipantId;
                }
            }
            return 0;
        }

        private ParticipantStats GetEstadisticasDetalladas(MatchDetail detalles_partida, int participant_id)
        {
            Participant participantes =
                detalles_partida.Participants.ToList().First(o => o.ParticipantId == participant_id);
            return participantes.Stats;
        }

        private void ComprobarLogros(UsuarioViewModel User, List<RawStat> stats)
        {
            if (User.doblekill == false)
            {

                var doublekill = stats.Exists(o => o.DoubleKills > 0);
                if (doublekill == true)
                {
                    var notis = new NotificacionesViewModel()
                    {
                        usuario = User,
                        texto = "Has conseguido el logro Doble Kill",
                        leido = false,
                        fecha = DateTime.Now
                    };

                    Notificaciones.Add(notis);


                }
                User.doblekill = doublekill;
            }
            if (User.triplekill == false)
                User.triplekill = stats.Exists(o => o.TripleKills > 0);
            if (User.quadrakill == false)
                User.quadrakill = stats.Exists(o => o.QuadraKills > 0);
            if (User.pentakill == false)
                User.pentakill = stats.Exists(o => o.PentaKills > 0);
            if (User.doble_doble == false)
                User.doble_doble = stats.Exists(o => o.ChampionsKilled > 9 && o.Assists > 9);
            if (User.asesino == false)
                User.asesino = stats.Exists(o => o.ChampionsKilled > 2 && o.ChampionsKilled < 6);
            if (User.monstruo == false)
                User.monstruo = stats.Exists(o => o.ChampionsKilled > 5 && o.ChampionsKilled < 10);
            if (User.heroe == false)
                User.heroe = stats.Exists(o => o.ChampionsKilled > 9 && o.ChampionsKilled < 12);
            if (User.conquistador == false)
                User.conquistador = stats.Exists(o => o.ChampionsKilled > 11);
            if (User.observer == false)
                User.observer = stats.Exists(o => o.WardPlaced > 9 && o.WardPlaced < 15);
            if (User.ward_dispenser == false)
                User.ward_dispenser = stats.Exists(o => o.WardPlaced > 14 && o.WardPlaced < 20);
            if (User.nofog == false)
                User.nofog = stats.Exists(o => o.WardPlaced > 19 && o.WardPlaced < 25);
            if (User.sauron == false)
                User.sauron = stats.Exists(o => o.WardKilled > 24);
            if (User.cantseeme == false)
                User.cantseeme = stats.Exists(o => o.WardKilled > 4 && o.WardKilled < 10);
            if (User.john_cena == false)
                User.john_cena = stats.Exists(o => o.WardKilled > 9 && o.WardKilled < 15);
            if (User.piquete_ojos == false)
                User.piquete_ojos = stats.Exists(o => o.WardKilled > 14 && o.WardKilled < 20);
            if (User.cegador == false)
                User.cegador = stats.Exists(o => o.WardKilled > 19);
            if (User.asesino == false)
                User.bulletproof = stats.Exists(o => o.NumDeaths == 3);
            if (User.asesino == false)
                User.die_hard = stats.Exists(o => o.NumDeaths == 5);
            if (User.asesino == false)
                User.mc_hammer = stats.Exists(o => o.NumDeaths == 4);
            if (User.asesino == false)
                User.intocable = stats.Exists(o => o.NumDeaths == 2);
            if (User.asesino == false)
                User.invencible = stats.Exists(o => o.NumDeaths == 1);
            if (User.asesino == false)
                User.indestructible = stats.Exists(o => o.NumDeaths == 0);
            if (User.asesino == false)
                User.trasto =
                    stats.Exists(o => o.TotalDamageDealtToChampions >= 3000 && o.TotalDamageDealtToChampions < 5000);
            if (User.asesino == false)
                User.rebel =
                    stats.Exists(o => o.TotalDamageDealtToChampions >= 5000 && o.TotalDamageDealtToChampions < 10000);
            if (User.asesino == false)
                User.macarra =
                    stats.Exists(o => o.TotalDamageDealtToChampions >= 10000 && o.TotalDamageDealtToChampions < 15000);
            if (User.asesino == false)
                User.maton =
                    stats.Exists(o => o.TotalDamageDealtToChampions >= 15000 && o.TotalDamageDealtToChampions < 20000);
            if (User.asesino == false)
                User.overlord = stats.Exists(o => o.TotalDamageDealtToChampions >= 20000);


            Repositorio.Actualizar(User);


            //User.nick = jugador;

            //User.server = id_server;
            //User.num_invocador = num_invocador;
            //User.division = division;

            float sum = 1;
            float kills = 0;
            float assist = 0;
            foreach (var o in stats)
            {
                assist += o.Assists;
                kills += o.ChampionsKilled;

                sum += o.NumDeaths;
            }
            User.kda += (assist + kills)/sum;
        }

        [HttpGet]
        public IHttpActionResult DameNotificaciones(long num_invocador)
        {

       var data=     Notificaciones.Get(o => o.leido == false && o.usuario.num_invocador == num_invocador).ToList();
            if (data != null)
            {
                data.ForEach(o => o.leido = true);
                return Ok(data);
            }

            else
                return NotFound();
        }


        [HttpGet]
        public IHttpActionResult DameTodo(string jugador, string servidor)
        {
            //TODO: ARREGLAR ESTO
            var id_server = 0;
            var region = Region.euw;
            long num_invocador = 0;
            switch (servidor)
            {
                case "euw":
                    region = Region.euw;
                    id_server = 1;
                    break;
            }
            var id = 10;

            var response = DameIdInvocador(jugador, region);
            {
                num_invocador = response;


                var division = "";

                var divi = DameDivision(num_invocador, region);
                if (divi == 0)
                {
                    division = "Unranked";
                }
                else
                {
                    division = divi.ToString();
                }

                var data = Existe(num_invocador);
                var lastindex = 0;


                var stats = new List<RawStat>();

                var Logros = new UsuarioViewModel();

                if (data == null)
                {
                    Logros.num_invocador = num_invocador;
                    Logros.division = division;
                    Logros.server = id_server;
                    Repositorio.Add(Logros);
                }
                else
                {
                    Logros = data;
                }

                stats = DameListaPartidas(num_invocador, region, Logros.lastindexgame);
                ComprobarLogros(Logros, stats);
                return Ok(Logros);
            }
        }
    }
}