using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoLAgencyApi.Controllers;

namespace LoLAgencyApi.Models
{
    public class Notificacion
    {
        public int id { get; set; }
        public string texto { get; set; }
    }

    public class Notificacion_Logro
    {
        public int id { get; set; }
        public Notificacion id_notificacion { get; set; }
        public Usuario usuario { get; set; }
        public bool leido { get; set; }
    }

    public class Logro
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }


}