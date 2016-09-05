using Autofac;
using Businesslogic.ServiceContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name.BusinessLogic
{
   public class AutofacBusinessRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AutofacBusinessRegister).Assembly)
                .AsImplementedInterfaces()
                .AsSelf();
            builder.RegisterType(typeof(ServiceContainer))
                .As(typeof(IServiceContainer))
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
