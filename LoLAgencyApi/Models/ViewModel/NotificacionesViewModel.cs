using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoLAgencyApi.Repositorio.ViewModel;

namespace LoLAgencyApi.Models.ViewModel
{
    public class NotificacionesViewModel : IViewModel<Notificacion>
    {
        public int id { get; set; }
        public string texto { get; set; }
        public UsuarioViewModel usuario { get; set; }
        public bool leido { get; set; }
        public DateTime fecha { get; set; }
        public Notificacion ToBaseDatos()
        {
            throw new NotImplementedException();
        }

        public void FromBaseDatos(Notificacion modelo)
        {
            throw new NotImplementedException();
        }

        public void UpdateBaseDatos(Notificacion modelo)
        {
            throw new NotImplementedException();
        }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}