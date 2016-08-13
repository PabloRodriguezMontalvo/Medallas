using GenericRepository;

namespace LoLAgencyApi.Models
{
    public class Usuario:IEntity
    {
        public int Id { get; set; }
        public long num_invocador { get; set; }
        public string nick { get; set; }
      
       
        public int lastindexgame { get; set; }
        public bool doblekill { get; set; }
        public bool triplekill { get; set; }
        public bool quadrakill { get; set; }
        public bool pentakill { get; set; }
        public bool doble_doble { get; set; }
        public bool asesino { get; set; }
        public bool monstruo { get; set; }
        public bool heroe { get; set; }
        public bool conquistador { get; set; }
        public bool observer { get; set; }
        public bool ward_dispenser { get; set; }
        public bool nofog { get; set; }
        public bool sauron { get; set; }
        public bool cantseeme { get; set; }
        public bool john_cena { get; set; }
        public bool piquete_ojos { get; set; }
        public bool cegador { get; set; }
        public bool bulletproof { get; set; }
        public bool die_hard { get; set; }
        public bool mc_hammer { get; set; }
        public bool boolocable { get; set; }
        public bool invencible { get; set; }
        public bool indestructible { get; set; }
        public bool trasto { get; set; }
        public bool rebel { get; set; }
        public bool macarra { get; set; }
        public bool maton { get; set; }
        public bool overlord { get; set; }
        public float kda { get; set; }
        public string division { get; set; }
        public int server { get; set; }
    }
}
