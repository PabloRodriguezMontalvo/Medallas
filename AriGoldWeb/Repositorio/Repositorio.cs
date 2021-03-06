﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AriGoldWeb.Models.ViewModel;


namespace AriGoldWeb.Repositorio
{
    public class Repositorio<TModelo, TViewModel> :
       IRepositorio<TModelo, TViewModel> where TModelo : class
                                where TViewModel : IViewModel<TModelo>, new()
    {
        private DbContext context;

        protected virtual DbSet<TModelo> DbSet
        {
            get
            {
                return context.Set<TModelo>();
            }
        }

        public Repositorio(DbContext context)
        {
            this.context = context;
        }


        public virtual int Actualizar(TViewModel model)
        {
            var obj = DbSet.Find(model.GetKeys());
            
            model.UpdateBaseDatos(obj);

            try
            {
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public virtual TViewModel Add(TViewModel model)
        {
            var m = model.ToBaseDatos();
            DbSet.Add(m);

            try
            {
                context.SaveChanges();
                model.FromBaseDatos(m);
                return model;
            }
            catch (Exception e)
            {

                return default(TViewModel);
            }
        }
    

        public virtual int Borrar(Expression<Func<TModelo, bool>> consulta)
        {
            var data = DbSet.Where(consulta);
            DbSet.RemoveRange(data);

            try
            {
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public virtual int Borrar(TViewModel model)
        {
            var obj = DbSet.Find(model.GetKeys());
            DbSet.Remove(obj);
            try
            {
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public virtual ICollection<TViewModel> Get()
        {
            var data = new List<TViewModel>();
            foreach (var modelo in DbSet)
            {
                TViewModel obj = new TViewModel();
                obj.FromBaseDatos(modelo);
                data.Add(obj);
            }
            return data;
        }

        public virtual ICollection<TViewModel> Get(Expression<Func<TModelo, bool>> consulta)
        {
            var datosO = DbSet.Where(consulta);
            var data = new List<TViewModel>();

            foreach (var modelo in datosO)
            {
                TViewModel obj = new TViewModel();
                obj.FromBaseDatos(modelo);
                data.Add(obj);
            }

            return data;
        }

        public virtual TViewModel Get(params object[] keys)
        {
            var dato = DbSet.Find(keys);
            var retorno = new TViewModel();
            retorno.FromBaseDatos(dato);

            return retorno;

        }
    }
}
