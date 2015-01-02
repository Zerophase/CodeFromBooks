using System;
using System.Collections.Generic;

namespace Lifetime.Pooled
{
	// NOTE Pooled Container
	// Make thread safe as an exercise
	public partial class PooledContainer : ICommerceServiceContainer
	{
		private readonly IContractMapper mapper;
		private readonly List<XferProductRepository> free;
		private readonly List<XferProductRepository> used;
		private readonly object syncRoot;

		public PooledContainer()
		{
			// Configured as singleton, since the same mapper is used for all
			// XferProductRepositories involved
			this.mapper = new ContractMapper();
			this.free = new List<XferProductRepository>();
			this.used = new List<XferProductRepository>();
			syncRoot = new object();
		}

		public int MaxSize { get; set; }

		public bool HasExcessCapacity
		{
			get
			{
				return this.free.Count + this.used.Count < this.MaxSize;
			}
		}
	}

	public partial class PooledContainer
	{
		public void Release(object instance)
		{
			var service = instance as ProductManagementService;
			if (service == null)
			{
				return;
			}
			var repository = service.Repository
				as XferProductRepository;
			if (repository == null)
			{
				return;
			}
			// Keeps thread safe, so when multiple threads are attempting
			// to modify the dictionary the data contained isn't corrupted in the process
			lock(syncRoot)
			{
				// Returns repository to pool
				this.used.Remove(repository);
				this.free.Add(repository);
			}
		}

		public IProductManagementService ResolveProductManagementService()
		{
			XferProductRepository repository = null;

			// Keeps thread safe, so when multiple threads are attempting
			// to modify the dictionary the data contained isn't corrupted in the process
			lock(syncRoot)
			{
				if (this.free.Count > 0)
				{
					// pick from pool if available
					repository = this.free[0];
					this.used.Add(repository);
					this.free.Remove(repository);
				}

				if (repository != null)
				{
					// return from pool
					return this.ResolveWith(repository);
				}

				if (!this.HasExcessCapacity)
				{
					throw new InvalidOperationException(
						"The pool is full.");
				}

				// add new repository, if pool has no free instances
				repository = new XferProductRepository();
				this.used.Add(repository);

				return this.ResolveWith(repository);
			}
			
		}

		private IProductManagementService ResolveWith(
			ProductRepository repository)
		{
			return new ProductManagementService(repository,
				this.mapper);
		}
	}
}