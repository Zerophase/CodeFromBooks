using System.Collections.Generic;
using CommerceSqlDataAccess;
using System.Configuration;

namespace ProductWcfAgent
{
	public class ReleasingCommerceServiceContainer : ICommerceServiceContainer
	{
		private readonly string connectionString;
		private readonly IContractMapper mapper;
		private readonly Dictionary<IProductManagementService, SqlProductRepository> repositories;
		private readonly object syncRoot;

		public ReleasingCommerceServiceContainer()
		{
			this.connectionString =
				ConfigurationManager.ConnectionStrings
				["CommerceObjectContext"].ConnectionString;

			this.mapper = new ContractMapper();

			this.syncRoot = new object();
			this.repositories = new Dictionary<IProductManagementService, SqlProductRepository>();
		}

		// This allows the Container to release the dependencies
		public void Release(object instance)
		{
			// srvc acts as key to dictionary
			var srvc = instance as IProductManagementService;
			// Protects to make sure the object passed in is of the correct type
			if (srvc == null)
			{
				return;
			}

			// prevents corruption of dictionary.
			lock (this.syncRoot)
			{
				SqlProductRepository repository;
				// when key is found dispose of it
				if (this.repositories.TryGetValue(srvc, out repository))
				{
					repository.Dispose();
					// removes value at key from dictionary
					this.repositories.Remove(srvc);
				}
			}
		}

		// NOTE Allows dependencies to be released when no longer needed
		public IProductManagementService ResolveProductManagementService()
		{ 
			// Create Product Repository
			var repository = new SqlProductRepository(this.connectionString);
			var srvc = new ProductManagementService(repository, this.mapper);

			// need to lock dictionary to ensure concurrent requests don't overwrite each other
			lock (this.syncRoot)
			{
				this.repositories.Add(srvc, repository);
			}

			return srvc;
		}
	}
}