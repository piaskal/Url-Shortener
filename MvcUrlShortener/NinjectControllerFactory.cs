using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using Ninject.Modules;
using UrlShortener.Domain.Service;
using UrlShortener.Domain;
using System.Configuration;

namespace MvcUrlShortener
{
    class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel = new StandardKernel(new UrlShortenerModule());

        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return (IController)kernel.Get(controllerType);
        }


        private class UrlShortenerModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IRepository>()
                    .To<SqlRepository>()
                    .WithConstructorArgument("connectionString",
                                             ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString
                    );

                Bind<IShortenerService>().To<ShortenerService>();
            }
        }



    }
}
