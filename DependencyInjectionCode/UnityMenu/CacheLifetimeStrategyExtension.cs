using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace UnityMenu
{
	// NOTE Implementing CacheLifetime so Unity uses it
	public class CacheLifetimeStrategyExtension : UnityContainerExtension
	{
		// Wire up all of the stretegies related to Cache lifetime,
		// and tell Unity to use them
		// container.AddNewExtension<CacheLifetimeStrategyExtension>();
		protected override void Initialize()
		{
			this.Context.Strategies
				.AddNew<CacheLifetimeStrategy>(
					UnityBuildStage.Lifetime);
			this.Context.Strategies
				.AddNew<CacheReleasingLifetimeStrategy>(
					UnityBuildStage.Lifetime);
		}
	}
}