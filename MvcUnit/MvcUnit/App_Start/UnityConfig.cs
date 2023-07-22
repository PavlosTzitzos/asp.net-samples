
//this is for MVC5
//using BAL;

using MvcUnit.Models;
using System.Web.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MvcUnit
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //registered dependency here
            container.RegisterType<IProductRepository , ProductRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}