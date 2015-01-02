using System;
using System.Security;
using System.Threading;

namespace AssortedCodeSnippets.Decorator.Security.Explicit
{
	// NOTE Interception: More General Method of implementing Cross Cutting Concerns
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
			// Guard Clause asks if current thread has the role expected
			// if not it throws an exception immediately
			// NOTE Example of ambient context pattern
			if (!Thread.CurrentPrincipal.IsInRole("ProductManager"))
			{
				throw new SecurityException();
			}

			this.innerRepository.InsertProduct(product);
		}
	}
}