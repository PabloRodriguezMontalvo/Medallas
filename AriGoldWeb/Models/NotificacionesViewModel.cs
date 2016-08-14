using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AriGoldWeb.Models
{
    public class NotificacionesViewModel
    {
        public int id { get; set; }
        public string texto { get; set; }
        public UsuarioViewModel usuario { get; set; }
        public bool leido { get; set; }
        public DateTime fecha { get; set; }

    }
}