using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using System.Configuration;
using MY_Domain.Abstract;
using MY_Domain.Concrete;
using MY_Domain.Entities;


namespace WebExercise04.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<INewsRepository>().To<EFNewsRepository>();
            ninjectKernel.Bind<IInformRepository>().To<EFInformRepository>();
            ninjectKernel.Bind<IActivitiesRepository>().To<EFActivitiesRepository>();
            ninjectKernel.Bind<IResearchNewsRepository>().To<EFResearchNewsRepository>();
            ninjectKernel.Bind<ITeachersRepository>().To<EFTeachersRepository>();
            ninjectKernel.Bind<IAllIntroduceRepository>().To<EFAllIntroduceRepository>();
            ninjectKernel.Bind<IUsefulLinksRepository>().To<EFUsefulLinksRepository>();
        }
    }
}