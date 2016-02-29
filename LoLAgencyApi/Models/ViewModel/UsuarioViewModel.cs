using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoLAgencyApi.Repositorio.ViewModel;

namespace LoLAgencyApi.Models.ViewModel
{
  public  class UsuarioViewModel:IViewModel<Usuarios>
    {
        public int Id { get; set; }
        public long num_invocador { get; set; }
        public string nick { get; set; }
        public int lastindexgame { get; set; }
        public int doblekill { get; set; }
        public int triplekill { get; set; }
        public int quadrakill { get; set; }
        public int pentakill { get; set; }
        public int doble_doble { get; set; }
        public int asesino { get; set; }
        public int monstruo { get; set; }
        public int heroe { get; set; }
        public int conquistador { get; set; }
        public int observer { get; set; }
        public int ward_dispenser { get; set; }
        public int nofog { get; set; }
        public int sauron { get; set; }
        public int cantseeme { get; set; }
        public int john_cena { get; set; }
        public int piquete_ojos { get; set; }
        public int cegador { get; set; }
        public int bulletproof { get; set; }
        public int die_hard { get; set; }
        public int mc_hammer { get; set; }
        public int intocable { get; set; }
        public int invencible { get; set; }
        public int indestructible { get; set; }
        public int trasto { get; set; }
        public int rebel { get; set; }
        public int macarra { get; set; }
        public int maton { get; set; }
      public int overlord { get; set; }
        public double kda { get; set; }
      public string division { get; set; }
        public int server { get; set; }

        public Usuarios ToBaseDatos()
        {
            var data = new Usuarios()
            {
                Id=Id,
               
                asesino = asesino,
                bulletproof = bulletproof,
                cantseeme = cantseeme,
                cegador = cegador,
                conquistador = conquistador,
                die_hard = die_hard,
                doble_doble = doble_doble,
                doblekill = doblekill,
                heroe = heroe,
                john_cena = john_cena,
                trasto = trasto,
                rebel = rebel,
                macarra = macarra,
                maton = maton,
                mc_hammer = mc_hammer,
                piquete_ojos = piquete_ojos,
                observer = observer,
                nofog = nofog,
                monstruo = monstruo,
                ward_dispenser = ward_dispenser,
                sauron = sauron,
                intocable = intocable,
                indestructible = indestructible,
                invencible = invencible,
                overlord = overlord,
                num_invocador = (int) num_invocador,
                lastindexgame = lastindexgame,
                nick = nick,
                triplekill = triplekill,
                quadrakill = quadrakill,
                pentakill = pentakill,
                server=server

            };
            return data;
        }

        public void FromBaseDatos(Usuarios modelo)
        {
            Id = modelo.Id;
                asesino =modelo.asesino;
                bulletproof =modelo.bulletproof;
                cantseeme =modelo.cantseeme;
                cegador =modelo.cegador;
                conquistador =modelo.conquistador;
                die_hard =modelo.die_hard;
                doble_doble =modelo.doble_doble;
                doblekill =modelo.doblekill;
                heroe =modelo.heroe;
                john_cena =modelo.john_cena;
                trasto =modelo.trasto;
                rebel =modelo.rebel;
                macarra =modelo.macarra;
                maton =modelo.maton;
                mc_hammer =modelo.mc_hammer;
                piquete_ojos =modelo.piquete_ojos;
                observer =modelo.observer;
                nofog =modelo.nofog;
                monstruo =modelo.monstruo;
                ward_dispenser =modelo.ward_dispenser;
                sauron =modelo.sauron;
                intocable =modelo.intocable;
                indestructible =modelo.indestructible;
                invencible =modelo.invencible;
                num_invocador =modelo.num_invocador;
                lastindexgame =modelo.lastindexgame;
                nick =modelo.nick;
                triplekill =modelo.triplekill;
                quadrakill =modelo.quadrakill;
            pentakill = modelo.pentakill;
            overlord = modelo.overlord;
            server = modelo.server;
        }

        public void UpdateBaseDatos(Usuarios modelo)
        {
            modelo.Id = Id;
            modelo.asesino = asesino;
            modelo.bulletproof = bulletproof;
            modelo.cantseeme = cantseeme;
            modelo.cegador = cegador;
            modelo.conquistador = conquistador;
            modelo.die_hard = die_hard;
            modelo.doble_doble = doble_doble;
            modelo.doblekill = doblekill;
            modelo.heroe = heroe;
            modelo.john_cena = john_cena;
            modelo.trasto = trasto;
            modelo.rebel = rebel;
            modelo.macarra = macarra;
            modelo.maton = maton;
            modelo.mc_hammer = mc_hammer;
            modelo.piquete_ojos = piquete_ojos;
            modelo.observer = observer;
            modelo.nofog = nofog;
            modelo.monstruo = monstruo;
            modelo.ward_dispenser = ward_dispenser;
            modelo.sauron = sauron;
            modelo.intocable = intocable;
            modelo.indestructible = indestructible;
            modelo.invencible = invencible;
            modelo.num_invocador = (int) num_invocador;
            modelo.lastindexgame = lastindexgame;
            modelo.nick = nick;
            modelo.triplekill = triplekill;
            modelo.quadrakill = quadrakill;
            modelo.pentakill = pentakill;
            modelo.overlord = overlord;
            modelo.server = server;
        }

        public object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
}
