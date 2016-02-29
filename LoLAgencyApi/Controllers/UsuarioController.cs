using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoLAgencyApi.Models;
using LoLAgencyApi.Models.ViewModel;
using LoLAgencyApi.Repositorio;

namespace LoLAgencyApi.Controllers
{
    public class UsuarioController : ApiController
    {

        public IRepositorio<Usuarios, UsuarioViewModel> Repositorio { get; set; }

        public UsuarioController()
        {


        }

        [HttpGet]
        public UsuarioViewModel DameUser(string jugador)
        {

            UsuarioViewModel user = Repositorio.Get(jugador);
            return user;
        }
    }
}