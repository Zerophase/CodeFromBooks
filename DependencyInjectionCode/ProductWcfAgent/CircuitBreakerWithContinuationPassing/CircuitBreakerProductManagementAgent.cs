using System;
using PresentationLogic;

namespace ProductWcfAgent.CircuitBreakerWithContinuationPassing
{
	// NOTE Circuit Breaker with Continuation Passing Style
	public class CircuitBreakerProductManagementAgent : IProductManagementAgent
	{
		private readonly IProductManagementAgent innerAgent;
		private readonly ICircuitBreaker breaker;

		public CircuitBreakerProductManagementAgent(IProductManagementAgent agent, ICircuitBreaker breaker)
		{
			if (agent == null)
			{
				throw new ArgumentNullException("agent");
			}
			if (breaker == null)
			{
				throw new ArgumentNullException("breaker");
			}

			this.innerAgent = agent;
			this.breaker = breaker;
		}

		public void InsertProduct(ProductEditorViewModel product)
		{
			// This allows us to use the Circuit Breaker in a more succinct manner
			// A Method is passed to an Action or Func<T>
			this.breaker.Execute(() =>
				this.innerAgent.InsertProduct(product));
		}

		public void DeleteProduct(int productId)
		{
			throw new NotImplementedException();
		}

		public System.Collections.Generic.IEnumerable<ProductViewModel> SelectAllProducts()
		{
			throw new NotImplementedException();
		}

		public void UpdateProduct(ProductEditorViewModel product)
		{
			throw new NotImplementedException();
		}
	}
}