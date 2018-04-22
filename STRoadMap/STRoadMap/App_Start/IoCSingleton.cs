using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Domain;
using STRoadMap.Controllers;
using Unity.Injection;

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
            freshContainer.RegisterType<Extensibility.IAccountLogic, Service.AccountLogic>();
            freshContainer.RegisterType<Domain.IUnitOfWork, Domain.EntityUnitOfWork>();
            freshContainer.RegisterType<AccountController>(new InjectionConstructor());            
            freshContainer.RegisterType<ManageController>(new InjectionConstructor());
            
        }
    }
}