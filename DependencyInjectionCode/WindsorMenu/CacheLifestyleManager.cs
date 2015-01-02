using System;
using CacheModel;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle;

namespace WindsorMenu
{
	// NOTE Custom Lifestyle: Cached
 	// Caches instances of classes
	// TODO make thread safe
	// Use this with .Lifestyle.Custom<>()
	public partial class CacheLifestyleManager : AbstractLifestyleManager
	{
		private ILease lease;

		// Lazy Loaded
		public ILease Lease
		{
			get
			{
				if (this.lease == null)
				{
					this.lease = this.resolveLease();
				}
				return this.lease;
			}
		}

		// Uses default Lease, but attempts to look up alternative through the kernel.
		// if anyone uses the Lease property before the Init function in AbstractLifestyleManager
		// the default lease is used. This won't happen with how Castle Windsor uses custom lifestyles
 		// in normal use.
		private ILease resolveLease()
		{
			var defaultLease = new SlidingLease(TimeSpan.FromMinutes(1));
			if (this.Kernel == null)
			{
				return defaultLease;
			}
			if (this.Kernel.HasComponent(typeof(ILease)))
			{
				return this.Kernel.Resolve<ILease>();
			}
			return defaultLease;
		}
	}

	// Caches the Resolved instance until the lease expires
	// then it resolves a new instance and renews the lease
	public partial class CacheLifestyleManager
	{
		private object obj;
		public override object Resolve(CreationContext context, IReleasePolicy releasePolicy)
		{
			// if expired makes sure to release the current implementation
			if (Lease.IsExpired)
			{
				base.Release((this.obj));
				this.obj = null;
			}
			if (obj == null)
			{
				Lease.Renew();
				obj = base.Resolve(context, releasePolicy);
			}
			return obj;
		}

		// Overwrote Release to do nothing, which is fairly common.
		// it is a hook method
		// this is part of Castle Windsor's Lifestyle seam
		public override bool Release(object instance)
		{
			return false;
		}

		public override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && obj != null)
				Release(obj);
		}
	}
}