namespace LoLAgencyApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public long num_invocador { get; set; }
        public string nick { get; set; }
        public bool pentakill { get; set; }
       
        public int lastindexgame { get; set; }
        //public int doblekill { get; set; }
        //public int triplekill { get; set; }
        //public int quadrakill { get; set; }
        //public int pentakill { get; set; }
        public bool doble_doble { get; set; }
        //public int asesino { get; set; }
        //public int monstruo { get; set; }
        //public int heroe { get; set; }
        //public int conquistador { get; set; }
        //public int observer { get; set; }
        //public int ward_dispenser { get; set; }
        //public int nofog { get; set; }
        //public int sauron { get; set; }
        //public int cantseeme { get; set; }
        //public int john_cena { get; set; }
        //public int piquete_ojos { get; set; }
        //public int cegador { get; set; }
        //public int bulletproof { get; set; }
        //public int die_hard { get; set; }
        //public int mc_hammer { get; set; }
        //public int intocable { get; set; }
        //public int invencible { get; set; }
        //public int indestructible { get; set; }
        //public int trasto { get; set; }
        //public int rebel { get; set; }
        //public int macarra { get; set; }
        //public int maton { get; set; }
        //public int overlord { get; set; }
        public float kda { get; set; }
        public string division { get; set; }
        public int server { get; set; }
    }
}
