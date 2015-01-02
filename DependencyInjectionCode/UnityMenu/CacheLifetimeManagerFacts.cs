using System;
using CacheModel;
using MenuModel;
using Microsoft.Practices.Unity;
using Xunit;

namespace UnityMenu
{
	public class CacheLifetimeManagerFacts
	{
		// NOTE Unity: Configures Lifetime to always return the
		// same instance for a minute after first request.
		// After that minute is up a new instance is created for another
		// minute worth of requests
		[Fact]
		public void LeaseIsCorrect()
		{
			// Fixture setup
			var container = new UnityContainer();
			var expectedLease = new SlidingLease(TimeSpan.FromMinutes(1));
			var cache = new CacheLifetimeManager(expectedLease);
			container.RegisterType<IIngredient, SauceBearnaise>(cache);
			// Exercise system
			ILease result = cache.Lease;
			// Verify outcome
			Assert.Equal(expectedLease, result);
		}

		[Fact]
		public void ExampleOfTearDown()
		{
			var container = new UnityContainer();
			var lease = new SlidingLease(TimeSpan.FromMinutes(1));
			var cache = new CacheLifetimeManager(lease);
			container.RegisterType<IIngredient, Parsley>(cache);

			var ingredient = container.Resolve<IIngredient>();

			container.Teardown(ingredient);
		}
	}
}