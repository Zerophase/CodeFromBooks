using System.Configuration;
using CommerceSqlDataAccess;
using DomainModel;

namespace ProductWcfAgent
{
	public class CommerceServiceContainer : ICommerceServiceContainer
	{
		public IProductManagementService ResolveProductManagementService()
		{
			string connectionString =
				ConfigurationManager.ConnectionStrings
				["CommerceObjectContext"].ConnectionString;

			ProductRepository repository =
				new SqlProductRepository(connectionString);

			IContractMapper mapper = new ContractMapper();

			return new ProductManagementService(repository,
				mapper);
		}

		public void Release(object instance)
		{

		}
	}
}