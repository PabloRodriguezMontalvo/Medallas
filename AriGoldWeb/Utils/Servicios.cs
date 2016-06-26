using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AriGoldWeb.Utils
{
    public class Servicios<TModelo> : iServicios<TModelo>
    {
        private String _urlBase;

        public Servicios(String url)
        {
            UrlBase = url;
        }

        public string UrlBase
        {
            get { return _urlBase; }
            set { _urlBase = value; }
        }


        public async Task Add(TModelo modelo)
        {
            var serializado = Serializacion<TModelo>.Serializar(modelo);

            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    var contenido = new StringContent(serializado);
                    contenido.Headers.ContentType =
                        new MediaTypeHeaderValue("application/json");

                    await client.PostAsync(new Uri(UrlBase),
                        contenido);
                }
            }


        }

        public async Task Update(int id, TModelo modelo)
        {
            var serializado = Serializacion<TModelo>.Serializar(modelo);

            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {
                    var contenido = new StringContent(serializado);
                    contenido.Headers.ContentType =
                        new MediaTypeHeaderValue("application/json");

                    await client.PutAsync(new Uri(UrlBase),
                        contenido);
                }
            }
        }

        public async Task Delete(int id)
        {


            using (var handler = new HttpClientHandler())
            {
                using (var client = new HttpClient(handler))
                {


                    await client.DeleteAsync(new Uri(UrlBase + "/" + id));
                }
            }
        }

        public List<TModelo> Get()
        {
            List<TModelo> lista;
            var cl = WebRequest.Create(UrlBase + "/get");
            cl.Method = "GET";
            var res = cl.GetResponse();
            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var resultado = reader.ReadToEnd();
                    lista = Serializacion<List<TModelo>>.
                        Deserializar(resultado);

                }
            }

            return lista;
        }

        public List<TModelo> Get(string metodo, string param)
        {
            List<TModelo> lista;
            var cl = WebRequest.Create(UrlBase + "/" + metodo + "/" + param);
            cl.Method = "GET";
            var res = cl.GetResponse();
            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var resultado = reader.ReadToEnd();
                    lista = Serializacion<List<TModelo>>.
                        Deserializar(resultado);

                }
            }

            return lista;
        }

        public TModelo Get(int id)
        {
            TModelo lista;
            var cl = WebRequest.Create(UrlBase + "/porid/" + id);
            cl.Method = "GET";
            var res = cl.GetResponse();
            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var resultado = reader.ReadToEnd();
                    lista = Serializacion<TModelo>.
                        Deserializar(resultado);

                }
            }

            return lista;
        }
        public TModelo Logros(string jugador, string servidor)
        {
            TModelo lista;
            var cl = WebRequest.Create(UrlBase + "/DameTodo/" +jugador+ "/" + servidor);
            cl.Method = "GET";
            HttpWebResponse res;
            try
            {
                 res = (HttpWebResponse)cl.GetResponse();
            }
            catch (WebException ex)
            {

                res = ex.Response as HttpWebResponse;
            }
           
            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var resultado = reader.ReadToEnd();
                    lista = Serializacion<TModelo>.
                        Deserializar(resultado);

                }
            }

            return lista;
        }
        public TModelo GetAll()
        {
            TModelo lista;
            var cl = WebRequest.Create(UrlBase + "/GetAll/");
            cl.Method = "GET";
            var res = cl.GetResponse();
            using (var stream = res.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var resultado = reader.ReadToEnd();
                    lista = Serializacion<TModelo>.
                        Deserializar(resultado);

                }
            }

            return lista;
        }
    }
}