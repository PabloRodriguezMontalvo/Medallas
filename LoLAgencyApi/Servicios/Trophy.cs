using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoLAgencyApi.Models.ViewModel;
using RiotSharp;
using RiotSharp.GameEndpoint;
using RiotSharp.LeagueEndpoint.Enums;
using RiotSharp.MatchEndpoint;
using System.Configuration;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using LoLAgencyApi.Repositorio;
using LoLAgencyApi.Models;
using RiotSharp.CurrentGameEndpoint.Enums;
using RiotSharp.StatsEndpoint;
using RiotSharp.SummonerEndpoint;
using Season = RiotSharp.MatchEndpoint.Enums.Season;

namespace LoLAgencyApi.Servicios
{
    public class Trophy : iTrophy
    {
        public RiotApi api;

        public IRepositorio<Usuario, UsuarioViewModel> Repositorio { get; set; }
        private Summoner _jugador;
        public Trophy(Summoner jugador)
        {
            Repositorio = new Repositorio<Usuario, UsuarioViewModel>(new ApplicationDbContext());
            api = RiotApi.GetInstance(ConfigurationManager.AppSettings["apikey"]);
            _jugador = jugador;
        }
        //public Trophy()
        //{
        //    Repositorio = new Repositorio<Usuario, UsuarioViewModel>(new ApplicationDbContext());
        //    api =   RiotApi.GetInstance(ConfigurationManager.AppSettings["apikey"]);
        // }

        public UsuarioViewModel CheckTrophy(UsuarioViewModel User, List<RawStat> stats)
        {
            if (User.doblekill == false)
                User.doblekill = stats.Exists(o => o.DoubleKills > 0);
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
          
        


            //User.nick = jugador;

            //User.server = id_server;
            //User.num_invocador = num_invocador;


            float sum = 1;
            float kills = 0;
            float assist = 0;
            foreach (var o in stats)
            {
                assist += o.Assists;
                kills += o.ChampionsKilled;

                sum += o.NumDeaths;
            }
            User.kda += (assist + kills) / sum;
            return User;
        }

        public string GetDivision()
        {
            try
            {
             
                var liga = _jugador.GetLeagues().First().Tier;


                return liga.ToString();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public List<RawStat> GetGames()
        {

            List<RawStat> estadisticas = new List<RawStat>();
           
            try
            {


                var matchList = SoloLasDiezUltimas(_jugador);
             
              estadisticas = GetStats(matchList);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }


            return estadisticas;
        }

        public int TotalGames()
        {
            List<Season> seasons = new List<Season>();
            seasons.Add(Season.Season2017);
            List<Queue> cola = new List<Queue>();
            cola.Add(Queue.RankedSolo5x5);
            return _jugador.GetStatsSummaries().Count;
        }
        private List<Game> SoloLasDiezUltimas(Summoner jugador)
        {

            var a= jugador.GetRecentGames();
            return a;
            //var total_games = api.GetMatchList(servidor, jugador, null, Queue.RankedSolo5x5, seasons).TotalGames;
            //var matchList = api.GetMatchList(servidor, jugador, null, Queue.RankedSolo5x5, seasons, null, null, lastindex, total_games);
        }

        private MatchList Todas(Region servidor, long jugador)
        {
            List<Queue> cola = new List<Queue>();
            cola.Add(Queue.TeamBuilderDraftRanked5x5);
            List<Season> seasons= new List<Season>();
            seasons.Add(Season.Season2017);
            return api.GetMatchList(servidor, jugador, null, cola, seasons , null, null, null, null);

        }

        public Summoner GetIdSummoner(string jugador, Region servidor)
        {   
            try
            {
                var summoner = api.GetSummoner(servidor, jugador);
                return summoner;
            }
            catch (RiotSharpException ex)
            {
                return null;
                // Handle the exception however you want.
            }
            //  var summoner = riotClient.Summoner.GetSummonersByName(servidor, jugador).FirstOrDefault().Value;
        }

        public float GetKDA(List<ParticipantStats> stats)
        {
            float sum = 0;
            float kills = 0;
            float assist = 0;
            foreach (var o in stats)
            {
                assist += o.Assists;
                kills += o.Kills;

                sum += o.Deaths;
            }
            var kda = (assist + kills) / sum;

            return kda;
        }

        public int GetPlayerIDOnGame(MatchDetail detalles_partida, long id)
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

        public List<RawStat> GetStats(List<Game> matchList)
        {
            //        RiotApiConfig.Regions.EUW
            List<RawStat> estadisticas = new List<RawStat>();

            foreach (var partida in matchList)
            {
                try
                {
                 

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

        public ParticipantStats GetStatsDetails(MatchDetail detalles_partida, int participant_id)
        {
            Participant participantes =
                    detalles_partida.Participants.ToList().First(o => o.ParticipantId == participant_id);
            return participantes.Stats;
        }

        public UsuarioViewModel GetUserFromBD(long num_invocador)
        {
            var data = Repositorio.Get(o => o.num_invocador == num_invocador).FirstOrDefault();

            if (data == null)
            {
                return new UsuarioViewModel();
            }
            else
            {
                return data;
            }
         
        }
    }
}