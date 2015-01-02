using System;
using StructureMap.Pipeline;
using CacheModel;
using StructureMap;

namespace StructureMapMenu
{
	public partial class LeasedObjectCache : IObjectCache
	{
		private readonly IObjectCache objectCache;
		private readonly ILease lease;

		public LeasedObjectCache(ILease lease)
		{
			if (lease == null)
			{
				throw new ArgumentNullException("lease");
			}

			this.lease = lease;
			this.objectCache = new LifecycleObjectCache();
		}

		public int Count
		{
			get
			{
				this.CheckLease();
				return this.objectCache.Count;
			}
		}

		public void DisposeAndClear()
		{
			this.objectCache.DisposeAndClear();
		}

		public void Eject(Type pluginType, Instance instance)
		{
			this.ObjectCache.Eject(pluginType, instance);
			this.CheckLease();
		}

		public bool Has(Type pluginType, Instance instance)
		{
			this.CheckLease();
			return this.objectCache.Has(pluginType, instance);
		}

		public object Get(Type pluginType, Instance instance, IBuildSession session)
		{
			this.CheckLease();
			return this.objectCache.Get(pluginType, instance, session);
		}

		private void CheckLease()
		{
			if (this.lease.IsExpired)
			{
				this.objectCache.DisposeAndClear();
			}
		}
	}

	public partial class LeasedObjectCache
	{
		public LeasedObjectCache(ILease lease, IObjectCache objectCache)
		{
			if (lease == null)
			{
				throw new ArgumentNullException("lease");
			}
			if (objectCache == null)
			{
				throw new ArgumentNullException("objectCache");
			}

			this.lease = lease;
			this.objectCache = objectCache;
		}

		public IObjectCache ObjectCache
		{
			get { return this.objectCache; }
		}

		public ILease Lease
		{
			get { return this.lease; }
		}
	}
}