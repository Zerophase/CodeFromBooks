using System;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;

namespace UnityMenu
{
	// NOTE: Unity enabling teardown of cached lifetimes
	public class CacheReleasingLifetimeStrategy : BuilderStrategy
	{
		public override void PostTearDown(
			IBuilderContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			// tears down Class when it goes out of scope
			var lifetimes = context
				.Lifetime.OfType<CacheLifetimeManager>();
			foreach (var lifetimePolicy in lifetimes)
			{
				lifetimePolicy.RemoveValue();
			}
		}
	}
}