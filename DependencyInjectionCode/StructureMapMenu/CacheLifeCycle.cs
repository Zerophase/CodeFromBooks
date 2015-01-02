using System;
using CacheModel;
using StructureMap.Pipeline;

namespace StructureMapMenu
{
	// NOTE StructureMap: CacheLifecyle
	public partial class CacheLifecycle : ILifecycle
	{
		 private readonly LeasedObjectCache cache;

        public CacheLifecycle(ILease lease)
        {
            if (lease == null)
            {
                throw new ArgumentNullException("lease");
            }

			// important to automatically wrap Ilease in 
			// an implementation of the IobjectCache
            this.cache = new LeasedObjectCache(lease);
        }

		public string Description
		{
			get { return "Cache"; }
		}

		public void EjectAll(StructureMap.ILifecycleContext context)
		{
			FindCache(context).DisposeAndClear();
		}

		public IObjectCache FindCache(StructureMap.ILifecycleContext context)
		{
			return cache;
		}
	}

	public partial class CacheLifecycle
	{
		 public ILease Lease
        {
            get { return this.cache.Lease; }
        }
	}
}