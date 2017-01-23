using LoLAgencyApi.Models.ViewModel;
using RiotSharp;
using RiotSharp.GameEndpoint;
using RiotSharp.MatchEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using RiotSharp.SummonerEndpoint;

namespace LoLAgencyApi.Servicios
{
  public  interface iTrophy
    {
        Summoner GetIdSummoner(string jugador, Region servidor);
        UsuarioViewModel GetUserFromBD(long num_invocador);
        RiotSharp.LeagueEndpoint.Enums.Tier GetDivision(long jugador, Region servidor);
        List<RawStat> GetGames(Summoner jugador, Region servidor, int lastindex);
        float GetKDA(List<ParticipantStats> stats);
        List<RawStat> GetStats(List<Game> matchList);
        int GetPlayerIDOnGame(MatchDetail detalles_partida, long id);
        ParticipantStats GetStatsDetails(MatchDetail detalles_partida, int participant_id);
        UsuarioViewModel CheckTrophy(UsuarioViewModel User, List<RawStat> stats);
        int TotalGames(long num_invocador, Region servidor);
    }
}
