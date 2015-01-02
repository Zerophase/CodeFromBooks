using System;
using System.Collections.Generic;

namespace DomainModel
{
	public partial class AuditingProductRepository : ProductRepository
	{
		private readonly ProductRepository
		   innerRepository;
		private readonly IAuditor auditor;

		// NOTE Decorator Pattern
		// IAudiditor is an abstraction all the decorating class does
		// is coordinate the functionality of the decorated class (ProductRepositor)
		// with that of the decorator class (IAuditor)
		public AuditingProductRepository(
		   ProductRepository repository,
		   IAuditor auditor)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}
			if (auditor == null)
			{
				throw new ArgumentNullException("auditor");
			}

			this.innerRepository = repository;
			this.auditor = auditor;
		}
	}

	public partial class AuditingProductRepository
	{
		public override IEnumerable<Product> GetFeaturedProducts()
		{
			return this.innerRepository.GetFeaturedProducts();
		}

		public override void DeleteProduct(int id)
		{
			this.innerRepository.DeleteProduct(id);
			this.auditor.Record(new AuditEvent("ProductDeleted", id));
		}

		public override void InsertProduct(Product product)
		{
			this.innerRepository.InsertProduct(product);
			this.auditor.Record(new AuditEvent("ProductInserted", product));
		}

		// Read operations generally just fall through to the decorated class
		public override Product SelectProduct(int id)
		{
			return this.innerRepository.SelectProduct(id);
		}

		// NOTE Decorator adds extra functionality to the methods
		// in the original class it wraps.
		// It just acts as embellishment on top of the original classes functionality
		// IAuditor adds that functionality in this case
		public override void UpdateProduct(Product product)
		{
			this.innerRepository.UpdateProduct(product);
			this.auditor.Record(
				new AuditEvent("ProductUpdated", product));
		}

		public override IEnumerable<Product> SelectAllProducts()
		{
			return this.innerRepository.SelectAllProducts();
		}
	}
}