using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Domain;

namespace STRoadMap
{
    public static class IoCSingleton
    {
        private static UnityContainer container;

        public static UnityContainer GetContainer()
        {
            if (container == null)
            {
                container = new UnityContainer();
                DependencyResolver.SetResolver(new UnityDependencyResolver(container));
                ContainerInitializer(container);
            }
            return container;
        }

        private static void ContainerInitializer(UnityContainer freshContainer)
        {
            freshContainer.RegisterType<STRoadMap.ITest, STRoadMap.Test>();
            freshContainer.RegisterType<Extensibility.IEmployeeLogic, Service.EmployeeLogic>();
            freshContainer.RegisterType<Extensibility.IMentorLogic, Service.MentorLogic>();
            freshContainer.RegisterType<Extensibility.IHRLogic, Service.HRLogic>();
            freshContainer.RegisterType<Domain.IUnitOfWork, Domain.EntityUnitOfWork>();
        }
    }
}