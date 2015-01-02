using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Features.ResolveAnything;
using MenuModel;
using Xunit;

namespace AutofacMenu
{
	public class MenuFacts
	{
		[Fact]
		public void RegisterAllIngredientsUsingModule()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule<IngredientModule>();
			builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

			var ingredients = builder.Build().Resolve<IEnumerable<IIngredient>>();

			Assert.True(ingredients.OfType<Steak>().Any());
			Assert.True(ingredients.OfType<SauceBearnaise>().Any());
		}

		// NOTE Autofac Wiring decorators
		// This is how to register the dependencies by refering to it by a name
		[Fact]
		public void ExplicitlyConfigureCotoletta()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<VealCutlet>().Named<IIngredient>("cutlet");
			builder.RegisterType<Breading>()
				.As<IIngredient>()
				.WithParameter(
					(p, c) => p.ParameterType == typeof(IIngredient),
					(p, c) => c.ResolveNamed<IIngredient>("cutlet"));

			var cotoletta = builder.Build().Resolve<IIngredient>();

			var breading = Assert.IsAssignableFrom<Breading>(cotoletta);
			Assert.IsAssignableFrom<VealCutlet>(breading.Ingredient);
		}

		// THis allows us to resolve the dependency without explicitly naming it
		[Fact]
		public void RegisterCotolettaUsingDelegate()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<VealCutlet>()
				.As<IIngredient, VealCutlet>();
			builder.Register(c => new Breading(c.Resolve<VealCutlet>()))
				.As<IIngredient>();

			var cotoletta = builder.Build().Resolve<IIngredient>();

			var breading = Assert.IsAssignableFrom<Breading>(cotoletta);
			Assert.IsAssignableFrom<VealCutlet>(breading.Ingredient);
		}
	}
}