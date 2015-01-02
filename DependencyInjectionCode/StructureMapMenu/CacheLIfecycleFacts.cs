using System;
using CacheModel;
using MenuModel;
using StructureMap;
using Xunit;

namespace StructureMapMenu
{
	public class CacheLIfecycleFacts
	{
		[Fact]
		public void LeaseIsCorrect()
		{
			var container = new Container();
			var expectedLease = new SlidingLease(TimeSpan.FromMinutes(1));
			var cache = new CacheLifecycle(expectedLease);

			// How to configure lease for use.
			// this line isn't used in the test
			container.Configure(r => r.For<IIngredient>().LifecycleIs(cache).Use<SauceBearnaise>());

			var result = cache.Lease;

			Assert.Equal(expectedLease, result);
		}
	}
}