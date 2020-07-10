using ArquiteturaTeste.Business.Services;
using ArquiteturaTeste.Domain.Models;
using ArquiteturaTeste.Domain.Services;
using ArquiteturaTeste.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace ArquiteturaTeste.StartUp
{
   public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<ContextChamadosTeste1, ContextChamadosTeste1>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IChamadosService, ChamadosService>(new HierarchicalLifetimeManager());

            container.RegisterType<NovoChamado, NovoChamado>(new HierarchicalLifetimeManager());
        }

        internal static void SetResolver(UnityDependencyResolver unityDependencyResolver)
        {
            throw new NotImplementedException();
        }
    }
}
