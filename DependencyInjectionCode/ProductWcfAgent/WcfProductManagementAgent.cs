using System;
using System.ServiceModel.Channels;
using PresentationLogic;
using WPFInjection = ProductWcfAgent.WcfClient;

namespace ProductWcfAgent
{
	public class WcfProductManagementAgent : IProductManagementAgent
	{
		private readonly IProductChannelFactory factory;
		private readonly IClientContractMapper mapper;

		public WcfProductManagementAgent(IProductChannelFactory factory, IClientContractMapper mapper)
		{
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			if (mapper == null)
			{
				throw new ArgumentNullException("mapper");
			}

			this.factory = factory;
			this.mapper = mapper;
		}

		public void DeleteProduct(int productId)
		{
			// NOTE Disposable dependency
			// Uses the dependency and disposes of it once it goes out of scope, 
			// by using IDosposable in the WPF base class
			// This avoid memory leaks, and a need to explicitly manage memory.
			using (var channel = this.factory.CreateChannel())
			{
				channel.DeleteProduct(productId);
			}
		}

		public void InsertProduct(ProductEditorViewModel product)
		{
			if (product == null)
			{
				throw new ArgumentNullException("product");
			}

			using (var channel = this.factory.CreateChannel())
			{
				var pc = this.mapper.Map(product);
				channel.InsertProduct(pc);
			}
		}

		public System.Collections.Generic.IEnumerable<ProductViewModel> SelectAllProducts()
		{
			using (var channel = this.factory.CreateChannel())
			{
				var products = channel.SelectAllProducts();
				return this.mapper.Map(products);
			}
		}

		public void UpdateProduct(ProductEditorViewModel product)
		{
			if (product == null)
			{
				throw new ArgumentNullException("product");
			}

			using (var channel = this.factory.CreateChannel())
			{
				var pc = this.mapper.Map(product);
				channel.UpdateProduct(pc);
			}
		}
	}
}