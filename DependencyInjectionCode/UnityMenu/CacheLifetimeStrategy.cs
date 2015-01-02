using System;
using Microsoft.Practices.ObjectBuilder2;

namespace UnityMenu
{
	// NOTE Unity: Wiring up CacheLifetime to be disposable in 
	// Using statement
	public class CacheLifetimeStrategy : BuilderStrategy
	{
		public override void PreBuildUp(
		   IBuilderContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			// Gets the Current Lifetime policy for the component
			IPolicyList policySource;
			var lifetimePolicy = context
				.PersistentPolicies
				.Get<ILifetimePolicy>(context.BuildKey,
					out policySource);

			// return prematurely if Child and Parent container have
			// the same source
			if (object.ReferenceEquals(policySource,
				context.PersistentPolicies))
			{
				return;
			}

			var cacheLifetime =
				lifetimePolicy as CacheLifetimeManager;
			// this implementation only cares about CacheLiftimeManager
			// so return if Lifetime is something else.
			if (cacheLifetime == null)
			{
				return;
			}

			// if it is a CacheLifetimeManager make a copy to use
 			// with child container
			var childLifetime = cacheLifetime.Clone();

			// now overwrite the inherited lifetime from the parent
			// with a seperate lifetime on the child
			context
				.PersistentPolicies
				.Set<ILifetimePolicy>(childLifetime,
					context.BuildKey);
			context.Lifetime.Add(childLifetime);
		}
	}
}