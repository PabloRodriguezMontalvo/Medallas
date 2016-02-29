using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LoLAgencyApi.Servicios
{
    public interface iServicios<TModelo>
    {
        Task<TModelo> Add(TModelo model);
        Task Update(TModelo model);
        Task Delete(int id);

        List<TModelo> Get(String paramUrl = null);
        List<TModelo> Get(Dictionary<String, String> param);
        TModelo Get(int id);
    }
}