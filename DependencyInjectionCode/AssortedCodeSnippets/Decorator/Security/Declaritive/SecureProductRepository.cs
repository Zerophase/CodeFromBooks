using System;
using System.Security.Permissions;

namespace AssortedCodeSnippets.Decorator.Security.Declaritive
{
	public class SecureProductRepository : ProductRepository
	{
		private readonly ProductRepository innerRepository;

		public SecureProductRepository(ProductRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}

			this.innerRepository = repository;
		}

		// NOTE Interception: Use a Purely declarative style when only one role is expected
		// Works with security, and other attributes
		// Do not just apply the attribute to the class reason is on page 295
		// of Dependency Injection in .Net
		[PrincipalPermission(SecurityAction.Demand, Role = "ProductManager")]
		public override void InsertProduct(Product product)
		{
			this.innerRepository.InsertProduct(product);
		}
	}
}