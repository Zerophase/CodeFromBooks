using System;
using System.Linq;
using MenuModel;
using StructureMap;
using Xunit;

namespace StructureMapMenu
{
	public class MenuFacts
	{
		[Fact]
		public void RegisterAllIngredientsAsSingletons()
		{
			var container = new Container();
			container.Configure(r =>
				r.Scan(s =>
				{
					s.AssemblyContainingType<Steak>();
					s.AddAllTypesOf<IIngredient>();
					s.Convention<SingletonConvention>();

					s.ExcludeType<Breading>();
				}));

			var ingredients1 = container.GetAllInstances<IIngredient>();
			var ingredients2 = container.GetAllInstances<IIngredient>();

			Assert.Same(
				ingredients1.OfType<SauceBearnaise>().Single(),
				ingredients2.OfType<SauceBearnaise>().Single());
		}

		[Fact]
		public void RegisterAllIngredientsUsingRegistry()
		{
			var container = new Container();
			container.Configure(r =>
				r.AddRegistry<MenuRegistry>());

			var ingredients = container.GetAllInstances<IIngredient>();

			Assert.True(ingredients.OfType<Steak>().Any());
			Assert.True(ingredients.OfType<SauceBearnaise>().Any());
		}

		[Fact]
		public void RegistAllSaucesUsingCustomConvention()
		{
			var container = new Container();
			container.Configure(r =>
				r.Scan(s =>
				{
					s.AssemblyContainingType<Steak>();
					s.Convention<SauceConvention>();
				}));

			var sauces = container.GetAllInstances<IIngredient>();

			Assert.True(sauces.OfType<SauceBearnaise>().Any());
			Assert.True(sauces.OfType<SauceHollandaise>().Any());
			Assert.True(sauces.OfType<SauceMousseline>().Any());

			Assert.False(sauces.OfType<Steak>().Any());
		}
	}
}