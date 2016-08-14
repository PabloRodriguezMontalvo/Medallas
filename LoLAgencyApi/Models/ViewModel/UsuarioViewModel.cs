﻿using LoLAgencyApi.Repositorio.ViewModel;

namespace LoLAgencyApi.Models.ViewModel
{
    public class UsuarioViewModel : IViewModel<Usuario>
    {
        public int Id { get; set; }
        public long num_invocador { get; set; }
        public string nick { get; set; }
        public bool pentakill { get; set; }
        public int lastindexgame { get; set; }
        public bool doble_doble { get; set; }
        public bool doblekill { get; set; }

        public bool triplekill { get; set; }
        public bool quadrakill { get; set; }
       

        public bool asesino { get; set; }
        public bool monstruo { get; set; }
        public bool heroe { get; set; }
        public bool conquistador { get; set; }
        public bool observer { get; set; }
        public bool ward_dispenser { get; set; }
        public bool nofog { get; set; }
        public bool sauron { get; set; }
        public bool cantseeme { get; set; }
        public bool john_cena { get; set; }
        public bool piquete_ojos { get; set; }
        public bool cegador { get; set; }
        public bool bulletproof { get; set; }
        public bool die_hard { get; set; }
        public bool mc_hammer { get; set; }
        public bool intocable { get; set; }
        public bool invencible { get; set; }
        public bool indestructible { get; set; }
        public bool trasto { get; set; }
        public bool rebel { get; set; }
        public bool macarra { get; set; }
        public bool maton { get; set; }
        public bool overlord { get; set; }
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
