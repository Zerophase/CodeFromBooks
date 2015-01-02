using System;
using System.Security.Permissions;

namespace AssortedCodeSnippets.Decorator.Security.Assertive
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

		public override void InsertProduct(Product product)
		{
			// NOTE Interception: Shorter version of implementing Security behavior
			// When Demand() Method is called it throws an exception
			// if Thread.CurrentPrinciple isn't in the correct state
			new PrincipalPermission(null, "ProductManager").Demand();

			this.innerRepository.InsertProduct(product);
		}
	}
}