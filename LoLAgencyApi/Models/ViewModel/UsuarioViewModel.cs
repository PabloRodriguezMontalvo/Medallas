using System;
using LoLAgencyApi.Repositorio.ViewModel;

namespace LoLAgencyApi.Models.ViewModel
{
    public class UsuarioViewModel : IViewModel<Usuario>
    {
        public int Id { get; set; }
        public long num_invocador { get; set; }
        public string nick { get; set; }
     
        public int lastindexgame { get; set; }

        public DateTime?  pentakill { get; set; }
        public DateTime?  doble_doble { get; set; }
        public DateTime?  doblekill { get; set; }

        public DateTime?  triplekill { get; set; }
        public DateTime?  quadrakill { get; set; }
       

        public DateTime?  asesino { get; set; }
        public DateTime?  monstruo { get; set; }
        public DateTime?  heroe { get; set; }
        public DateTime?  conquistador { get; set; }
        public DateTime?  observer { get; set; }
        public DateTime?  ward_dispenser { get; set; }
        public DateTime?  nofog { get; set; }
        public DateTime?  sauron { get; set; }
        public DateTime?  cantseeme { get; set; }
        public DateTime?  john_cena { get; set; }
        public DateTime?  piquete_ojos { get; set; }
        public DateTime?  cegador { get; set; }
        public DateTime?  bulletproof { get; set; }
        public DateTime?  die_hard { get; set; }
        public DateTime?  mc_hammer { get; set; }
        public DateTime?  intocable { get; set; }
        public DateTime?  invencible { get; set; }
        public DateTime?  indestructible { get; set; }
        public DateTime?  trasto { get; set; }
        public DateTime?  rebel { get; set; }
        public DateTime?  macarra { get; set; }
        public DateTime?  maton { get; set; }
        public DateTime?  overlord { get; set; }
        public float kda { get; set; }
        public string division { get; set; }
        public int server { get; set; }

        public Usuario ToBaseDatos()
        {
            var data = new Usuario()
            {
                Id = Id,
                doble_doble = doble_doble,
                asesino = asesino,
                bulletproof = bulletproof,
                cantseeme = cantseeme,
                cegador = cegador,
                conquistador = conquistador,
                die_hard = die_hard,
                division = division,
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
                num_invocador = (int)num_invocador,
                lastindexgame = lastindexgame,
                nick = nick,
                triplekill = triplekill,
                quadrakill = quadrakill,
                pentakill = pentakill,
                server = server

            };
            return data;
        }

        public void FromBaseDatos(Usuario modelo)
        {
            Id = modelo.Id;
            doble_doble = modelo.doble_doble;
            asesino = modelo.asesino;
            bulletproof = modelo.bulletproof;
            cantseeme = modelo.cantseeme;
            cegador = modelo.cegador;
            conquistador = modelo.conquistador;
            die_hard = modelo.die_hard;

            doblekill = modelo.doblekill;
            heroe = modelo.heroe;
            john_cena = modelo.john_cena;
            trasto = modelo.trasto;
            rebel = modelo.rebel;
            macarra = modelo.macarra;
            maton = modelo.maton;
            mc_hammer = modelo.mc_hammer;
            piquete_ojos = modelo.piquete_ojos;
            observer = modelo.observer;
            nofog = modelo.nofog;
            monstruo = modelo.monstruo;
            ward_dispenser = modelo.ward_dispenser;
            sauron = modelo.sauron;
            intocable = modelo.intocable;
            indestructible = modelo.indestructible;
            invencible = modelo.invencible;
            num_invocador = modelo.num_invocador;
            lastindexgame = modelo.lastindexgame;
            nick = modelo.nick;
            triplekill = modelo.triplekill;
            quadrakill = modelo.quadrakill;
            pentakill = modelo.pentakill;
             overlord = modelo.overlord;
            server = modelo.server;
        }

        public void UpdateBaseDatos(Usuario modelo)
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
            modelo.num_invocador = (int)num_invocador;
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
