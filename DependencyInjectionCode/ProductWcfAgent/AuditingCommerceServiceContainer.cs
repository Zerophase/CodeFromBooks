using System.Configuration;
using CommerceSqlDataAccess;
using DomainModel;

namespace ProductWcfAgent
{
	// NOTE Composing Decorator with DI
	// This is a simplified example, how SqlProductRepository and SqlAuditor are
	// handled ignores the resource leaks they cause.
	// A more correct implementation interpolates listing 9.3 with 8.4 and 8.5
	// TODO Correct Resource Leak
	// The Decorator design allows us to add behavior to ProductRepository without
	// having change the source code implementation
	// NOTE this follows the Open / Closed Principle {Software Entities (Classes, Moduels, Functions)
  	// Should be open for extension, but closed for modification.}
	public class AuditingCommerceServiceContainer : ICommerceServiceContainer
	{
		public void Release(object instance)
		{
		
		}

		public IProductManagementService ResolveProductManagementService()
		{
			string connectionString =
				ConfigurationManager.ConnectionStrings
				["CommerceObjectContext"].ConnectionString;

			// Inner Product Repository
			ProductRepository sqlRepository =
				new SqlProductRepository(connectionString);

			IAuditor sqlAuditor =
				new SqlAuditor(connectionString);

			// Decorator class
			ProductRepository auditingRepository =
				new AuditingProductRepository(
					sqlRepository, sqlAuditor);

			IContractMapper mapper = new ContractMapper();

			// Injection of Decorator to use it as an interceptor of
			// the inner class functionality
			return new ProductManagementService(
				auditingRepository, mapper);
		}
	}
}