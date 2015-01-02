using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MenuModel;

namespace AutofacMenu
{
	// NOTE Setting up modules in Autofac
    public class IngredientModule : Module
    {
		// use to register components like you would outside of a module
		protected override void Load(ContainerBuilder builder)
		{
			var a = typeof(Steak).Assembly;
			builder.RegisterAssemblyTypes(a).As<IIngredient>();
		}
    }
}
