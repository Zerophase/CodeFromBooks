using System;

namespace Lifetime.Singleton
{
	// NOTE Singleton Lifetime
	public class SingletonContainer : ICommerceServiceContainer
	{
		// keep reference to each dependency for the duration of the 
		// containers lifetime
		private readonly ProductRepository repository;
		private readonly IContractMapper mapper;

		public SingletonContainer()
		{
			// creates singletons
			repository = new InMemoryProductRepository();
			mapper = new ContractMapper();
		}


		public void Release(object instance)
		{
			// Nothing has been implemented for this
		}

		// whenever asked to resolve an IProductManagementService
		// a transient instance is created with the Singletons injected into it
		public IProductManagementService ResolveProductManagementService()
		{
			return new ProductManagementService(repository, mapper);
		}
	}
}