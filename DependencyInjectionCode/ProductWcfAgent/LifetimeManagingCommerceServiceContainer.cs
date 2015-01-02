using System.Configuration;
using CommerceSqlDataAccess;
using DomainModel;

namespace ProductWcfAgent
{
	// NOTE Managing Lifetime
	public partial class LifetimeManagingCommerceServiceContainer : 
		ICommerceServiceContainer
	{
		// insures only one of these classes exists
		private readonly string connectionString;
		private readonly IContractMapper mapper;

		// Constructs Singleton lifetimes in Constructor
		public LifetimeManagingCommerceServiceContainer()
		{
			this.connectionString =
				ConfigurationManager.ConnectionStrings
				["CommerceObjectContext"].ConnectionString;

			this.mapper = new ContractMapper();
		}

		public IProductManagementService
			ResolveProductManagementService()
		{
			ProductRepository repository =
				new SqlProductRepository(
					this.connectionString);
			return new ProductManagementService(
				repository, this.mapper);
		}
	}

	public partial class LifetimeManagingCommerceServiceContainer
	{
		public void Release(object instance)
		{
		}
	}
}