using Lecture3.Controllers;
using Lecture3.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture3.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            //return NaiveDI(controllerType);
            //return ReflectionDI(controllerType);
            return NinjectDI(controllerType);
        } 


        IController NaiveDI(Type controllerType)
        {
            if (controllerType == typeof(HomeController)) return new HomeController();
            if (controllerType == typeof(BadComingSoonController)) return new BadComingSoonController();
            if (controllerType == typeof(TestableComingSoonController)) return new TestableComingSoonController(new EntityBookRepository(), new CurrentDateProvider());
            throw new NotImplementedException();
        }

        IController ReflectionDI(Type controllerType)
        {
            var ctor = controllerType.GetConstructor(new Type[0]);
            if (ctor == null) throw new NotImplementedException();
            return (IController)ctor.Invoke(new object[0]);
        }

        IController NinjectDI(Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }

        IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            kernel.Bind<ICurrentDateProvider>().ToConstant(new CurrentDateProvider());
            kernel.Bind<IBookRepository>().ToConstant(new EntityBookRepository());
        }
    }
}