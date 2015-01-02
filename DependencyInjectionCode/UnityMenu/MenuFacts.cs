using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuModel;
using Microsoft.Practices.Unity;
using Xunit;

namespace UnityMenu
{
    public class MenuFacts
    {
		// NOTE Autowiring types in Unity
		[Fact]
		public void RegisterAllIngredients()
		{
			var container = new UnityContainer();

			// grabs all types in the assembly
			foreach (var t in typeof(Steak).Assembly.GetExportedTypes())
			{
				// filters out IIngredient and Breading
				if (typeof(IIngredient) == t || typeof(Breading) == t)
				{
					continue;
				}
				// maps interface to type, with t.FullName being the unique name for the mapping
				if (typeof(IIngredient).IsAssignableFrom(t))
				{
					container.RegisterType(typeof(IIngredient), t, t.FullName);
				}
			}

			var ingredients = container.ResolveAll<IIngredient>();

			Assert.True(ingredients.OfType<Steak>().Any());
			Assert.True(ingredients.OfType<SauceBearnaise>().Any());
		}

		[Fact]
		public void IngredientsCanBeRegisteredUsingExtension()
		{
			var container = new UnityContainer();
			container.AddNewExtension<IngredientExtension>();

			var ingredients = container.ResolveAll<IIngredient>();

			Assert.True(ingredients.OfType<Steak>().Any());
			Assert.True(ingredients.OfType<SauceBearnaise>().Any());
		}
    }
}
