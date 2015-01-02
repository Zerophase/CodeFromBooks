using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MenuModel;

namespace WindsorMenu
{
    public class IngredientInstaller : IWindsorInstaller
    {
		// NOTE Installers: ideally you configure your installer
		// with a single call to the Install method.
		// This allows you to package and structure you container
		// configuration code. This has the advantage of making
		// your composition root code more readable
		public void Install(IWindsorContainer container,
			IConfigurationStore store)
		{
			container.Register(AllTypes
				.FromAssemblyContaining<Steak>()
				.BasedOn<IIngredient>());
		}
    }
}
