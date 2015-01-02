using System;
using Microsoft.Practices.Unity;
using CacheModel;

namespace UnityMenu
{
	// NOTE Unity implementing Cache Lifestyle
	public partial class CacheLifetimeManager :
		LifetimeManager, IDisposable
	{
		private object value;
		private readonly ILease lease;

		public CacheLifetimeManager(ILease lease)
		{
			if (lease == null)
			{
				throw new ArgumentNullException("lease");
			}

			this.lease = lease;
		}

		// Returns the value field, after
		// making sure to Remove any expired leases
		public override object GetValue()
		{
			this.RemoveValue();
			return this.value;
		}

		// if the lease has expired Dispose of it
		public override void RemoveValue()
		{
			if (this.lease.IsExpired)
			{
				this.Dispose();
			}
		}

		// Renews lease and sets the value
		// only invoked when Unity creates a new value for
		// the component used
		public override void SetValue(object newValue)
		{
			this.value = newValue;
			this.lease.Renew();
		}
	}

	public partial class CacheLifetimeManager
	{
		public ILease Lease
		{
			get { return this.lease; }
		}

		public CacheLifetimeManager Clone()
		{
			return new CacheLifetimeManager(this.Lease);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			this.Dispose(true);
		}

		// Never called unless we implement a Strategy pattern that uses it
		// when the strategy pattern is implemented it allows us to use:
		// Using() to use the instance and then dispose of it
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				var d = this.value as IDisposable;
				if (d != null)
				{
					d.Dispose();
				}
				this.value = null;
			}
		}
	}
}