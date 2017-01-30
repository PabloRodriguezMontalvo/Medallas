

using System;

namespace LoLAgencyApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public long num_invocador { get; set; }
        public string nick { get; set; }

        public int lastindexgame { get; set; }
        public DateTime pentakill { get; set; }
        public DateTime doble_doble { get; set; }
        public DateTime doblekill { get; set; }

        public DateTime triplekill { get; set; }
        public DateTime quadrakill { get; set; }


        public DateTime asesino { get; set; }
        public DateTime monstruo { get; set; }
        public DateTime heroe { get; set; }
        public DateTime conquistador { get; set; }
        public DateTime observer { get; set; }
        public DateTime ward_dispenser { get; set; }
        public DateTime nofog { get; set; }
        public DateTime sauron { get; set; }
        public DateTime cantseeme { get; set; }
        public DateTime john_cena { get; set; }
        public DateTime piquete_ojos { get; set; }
        public DateTime cegador { get; set; }
        public DateTime bulletproof { get; set; }
        public DateTime die_hard { get; set; }
        public DateTime mc_hammer { get; set; }
        public DateTime intocable { get; set; }
        public DateTime invencible { get; set; }
        public DateTime indestructible { get; set; }
        public DateTime trasto { get; set; }
        public DateTime rebel { get; set; }
        public DateTime macarra { get; set; }
        public DateTime maton { get; set; }
        public DateTime overlord { get; set; }
        public float kda { get; set; }
        public string division { get; set; }
        public int server { get; set; }
    }
}
