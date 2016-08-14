﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoLAgencyApi.Controllers;
using LoLAgencyApi.Models.ViewModel;

namespace LoLAgencyApi.Models
{
    public class Notificacion
    {
        public int id { get; set; }
        public string texto { get; set; }
        public UsuarioViewModel usuario { get; set; }
        public bool leido { get; set; }
        public DateTime fecha { get; set; }

    }

    public class Logro
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }


}