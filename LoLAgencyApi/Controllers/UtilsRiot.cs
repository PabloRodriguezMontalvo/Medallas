using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;
using LoLAgencyApi.Models;
using LoLAgencyApi.Models.ViewModel;
using LoLAgencyApi.Repositorio;
using Microsoft.WindowsAzure.MobileServices;
using RiotApi.Net.RestClient;
using RiotApi.Net.RestClient.ApiCalls;
using RiotApi.Net.RestClient.Configuration;
using RiotApi.Net.RestClient.Dto.Match;
using RiotApi.Net.RestClient.Dto.Match.Generic;
using RiotApi.Net.RestClient.Dto.Summoner;
using RiotApi.Net.RestClient.Helpers;


namespace LoLAgencyApi.Controllers
{
    public class UtilsRiot
    {
        private const string Temporada = "SEASON2016";
        // public RiotSharp.RiotApi api = RiotSharp.RiotApi.GetInstance(ConfigurationManager.AppSettings["apikey"]);
       
        public IRiotClient riotClient = new RiotClient(ConfigurationManager.AppSettings["apikey"]);

       
        public IRepositorio<Usuarios, UsuarioViewModel> Repositorio { get; set; }

 

        
        
        public List<ParticipantStats> ListadePartidas(long jugador, RiotApiConfig.Regions servidor, int lastindex=0)
        {


             List<ParticipantStats> estadisticas = new List<ParticipantStats>();
        MatchListDto matchList = new MatchListDto();
            //       string ranktype=
            try
            {
                var total_games =
                    riotClient.MatchList.GetMatchListBySummonerId(servidor, jugador, null,
                        Enums.GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5.ToString(), Temporada).TotalGames;
                matchList = riotClient.MatchList.GetMatchListBySummonerId(servidor, jugador, null, Enums.GameQueueType.TEAM_BUILDER_DRAFT_RANKED_5x5.ToString(), Temporada, null, null, lastindex, total_games);
                if (total_games != 0)
                {
                    estadisticas= CargarEstadisticas(matchList, jugador, servidor);

                }
              
            }
            catch (Exception e)
            {

            }


            return estadisticas;


        }
      
    
        public List<ParticipantStats> CargarEstadisticas(MatchListDto matchList, long id, RiotApiConfig.Regions servidor)
        {
            //        RiotApiConfig.Regions.EUW
            List<ParticipantStats> estadisticas = new List<ParticipantStats>();
            foreach (var partida in matchList.Matches)
            {
                System.Threading.Thread.Sleep(1000);
                MatchDetail detalles_partida = riotClient.Match.GetMatchById(servidor, partida.MatchId, false);
                int participant_id =  GetIDParticipante(detalles_partida, id);
                estadisticas.Add(GetEstadisticasDetalladas(detalles_partida, participant_id));
            }
            return estadisticas;
        }


        public static int GetIDParticipante(MatchDetail detalles_partida, long id)
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

        public ParticipantStats GetEstadisticasDetalladas(MatchDetail detalles_partida, int participant_id)
        {
            Participant participantes =
                 detalles_partida.Participants.ToList().First(o => o.ParticipantId == participant_id);
            return participantes.Stats;
        }

       
    }
}