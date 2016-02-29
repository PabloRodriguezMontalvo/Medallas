using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoLAgencyApi.Repositorio.ViewModel
{
    public interface IViewModel<TModelo> where TModelo : class
    {
        TModelo ToBaseDatos();
        void FromBaseDatos(TModelo modelo);
        void UpdateBaseDatos(TModelo modelo);
        object[] GetKeys();
    }
}