using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using LoLAgencyApi.Models;
using LoLAgencyApi.Repositorio;
using Unity.WebApi;

namespace LoLAgencyApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

        


            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}