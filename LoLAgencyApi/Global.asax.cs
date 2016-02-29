
using System.Web.Http;

namespace LoLAgencyApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

          

        //    var cuantos_puntos= otracosa.
          
            //retrieve all current free to play champions
           
          //  var la_id = championList.First();
     
            //var una_partida = riotClient.MatchList.GetMatchListBySummonerId(RiotApiConfig.Regions.EUW, championList["nzrgonzo"].Id);
            //var partida_detalle = riotClient.Match.GetMatchById(RiotApiConfig.Regions.EUW, 1797938658, false);
            //IEnumerable<RiotApi.Net.RestClient.Dto.Match.Generic.Participant> participantes = partida_detalle.Participants;
            //foreach (var participante in participantes)
            //{
            //    if (participante.ParticipantId == championList["nzrgonzo"].Id)
            //    {

            //    }
            //}
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
        }
    }
}
