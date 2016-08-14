namespace LoLAgencyApi.Models
{
    public class Notificacion_Logro
    {
        public int id { get; set; }
        public Notificacion id_notificacion { get; set; }
        public Usuario usuario { get; set; }
        public bool leido { get; set; }
    }
}