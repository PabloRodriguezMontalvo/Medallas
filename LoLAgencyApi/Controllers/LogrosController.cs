using LoLAgencyApi.Models;
using LoLAgencyApi.Models.ViewModel;
using LoLAgencyApi.Repositorio;
using RiotSharp;
using RiotSharp.GameEndpoint;
using RiotSharp.LeagueEndpoint;
using RiotSharp.MatchEndpoint;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Season = RiotSharp.StatsEndpoint.Season;

namespace LoLAgencyApi.Controllers
{
    public class LogrosController : ApiController
    {
        private const string Temporada = "SEASON2016";
        public RiotSharp.RiotApi apiriot = RiotSharp.RiotApi.GetInstance(ConfigurationManager.AppSettings["apikey"]);

        //  public IRiotClient riotClient = new RiotClient(ConfigurationManager.AppSettings["apikey"]);


        public IRepositorio<Usuario, UsuarioViewModel> Repositorio { get; set; }
        public List<RawStat> _stats = new List<RawStat>();
        public RiotApi api = RiotSharp.RiotApi.GetInstance(ConfigurationManager.AppSettings["apikey"]);
        public LogrosController()
        {

            Repositorio = new Repositorio<Usuario, UsuarioViewModel>(new ApplicationDbContext());


        }



        [HttpGet]
        [ResponseType(typeof(string))]
        private Tier DameDivision(long jugador, RiotSharp.Region servidor)
        {

            try
            {
                var liga = api.GetSummoner(servidor, (int)jugador).GetLeagues().FirstOrDefault().Tier;



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

            return (data);


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
        private IEnumerable<RawStat> DameListaPartidas(long jugador, Region servidor, int lastindex)
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
            var kda = (assist + kills) / sum;

            return (kda);

        }






        private List<RawStat> ListadePartidas(long jugador, RiotSharp.Region servidor, int lastindex = 0)
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


        private List<RawStat> CargarEstadisticas(List<Game> matchList, long id, RiotSharp.Region servidor)
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


        private static int GetIDParticipante(RiotSharp.MatchEndpoint.MatchDetail detalles_partida, long id)
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
            if (response != null)
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
                bool existe = false;

                if (data == null)
                {
                    existe = false;

                }
                else
                {
                    existe = true;


                    Logros = data;

                }

                stats = ListadePartidas(num_invocador, region, Logros.lastindexgame);
                bool boom = stats.Exists(o => o.NexusKilled == true);
                //Logros.doblekill += stats.Count(o => o.DoubleKills > 0);
                //Logros.triplekill += stats.Count(o => o.TripleKills > 0);
                //Logros.quadrakill += stats.Count(o => o.QuadraKills > 0);
                Logros.pentakill = stats.Exists(o => o.PentaKills > 0);
                Logros.doble_doble = stats.Exists(o => o.ChampionsKilled > 9 && o.Assists > 9);
                //Logros.asesino += stats.Count(o => o.ChampionsKilled > 2 && o.ChampionsKilled < 6);
                //Logros.monstruo += stats.Count(o => o.ChampionsKilled > 5 && o.ChampionsKilled < 10);
                //Logros.heroe += stats.Count(o => o.ChampionsKilled > 9 && o.ChampionsKilled < 12);
                //Logros.conquistador += stats.Count(o => o.ChampionsKilled > 11);
                //Logros.observer += stats.Count(o => o.WardPlaced > 9 && o.WardPlaced < 15);
                //Logros.ward_dispenser += stats.Count(o => o.WardPlaced > 14 && o.WardPlaced < 20);
                //Logros.nofog += stats.Count(o => o.WardPlaced > 19 && o.WardPlaced < 25);
                //Logros.sauron += stats.Count(o => o.WardKilled > 24);
                //Logros.cantseeme += stats.Count(o => o.WardKilled > 4 && o.WardKilled < 10);
                //Logros.john_cena += stats.Count(o => o.WardKilled > 9 && o.WardKilled < 15);
                //Logros.piquete_ojos += stats.Count(o => o.WardKilled > 14 && o.WardKilled < 20);
                //Logros.cegador += stats.Count(o => o.WardKilled > 19);
                //Logros.bulletproof += stats.Count(o => o.NumDeaths == 3);
                //Logros.die_hard += stats.Count(o => o.NumDeaths == 5);
                //Logros.mc_hammer += stats.Count(o => o.NumDeaths == 4);
                //Logros.intocable += stats.Count(o => o.NumDeaths == 2);
                //Logros.invencible += stats.Count(o => o.NumDeaths == 1);
                //Logros.indestructible += stats.Count(o => o.NumDeaths == 0);
                //Logros.trasto +=
                //    stats.Count(o => o.TotalDamageDealtToChampions >= 3000 && o.TotalDamageDealtToChampions < 5000);
                //Logros.rebel +=
                //    stats.Count(o => o.TotalDamageDealtToChampions >= 5000 && o.TotalDamageDealtToChampions < 10000);
                //Logros.macarra +=
                //    stats.Count(o => o.TotalDamageDealtToChampions >= 10000 && o.TotalDamageDealtToChampions < 15000);
                //Logros.maton +=
                //    stats.Count(o => o.TotalDamageDealtToChampions >= 15000 && o.TotalDamageDealtToChampions < 20000);
                //Logros.overlord += stats.Count(o => o.TotalDamageDealtToChampions >= 20000);


                Logros.lastindexgame = stats.Count;


                Logros.nick = jugador;

                Logros.server = id_server;
                Logros.num_invocador = num_invocador;
                Logros.division = division;

                float sum = 1;
                float kills = 0;
                float assist = 0;
                foreach (var o in stats)
                {
                    assist += o.Assists;
                    kills += o.ChampionsKilled;

                    sum += o.NumDeaths;
                }
                Logros.kda += (assist + kills) / sum;



                if (existe == true)

                {

                    Repositorio.Actualizar(Logros);
                }
                else
                {

                    Repositorio.Add(Logros);
                }


                return Ok(Logros);

            }
            else
            {
                return NotFound();
            }
        }
    }
}