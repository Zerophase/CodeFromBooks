using System;
using System.Collections.Generic;
using PresentationLogic;

namespace ProductWcfAgent
{
	// NOTE Circuit Breaker Pattern
	// Uses Decorator
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

		public void DeleteProduct(int productId)
		{
			this.breaker.Guard();
			try
			{
				this.innerAgent.DeleteProduct(productId);
				this.breaker.Succeed();
			}
			catch (Exception e)
			{
				this.breaker.Trip(e);
				throw;
			}
		}

		// Wraps call to decorated agent with Circuit Breaker error handling behavior
		// NOTE Functionality of Circuit Breaker
		public void InsertProduct(ProductEditorViewModel product)
		{
			// Checks the state of the Circuit Breaker
			// Let's user through when guard is either closed or Half open
			// Throws an exception when call is open
			// This ensures fast failure when call will not succeed
			// Ensures we never move past here when in the Open State
			this.breaker.Guard();
			try
			{
				// invoke decorated agent if we make it past the guard
				// breaker trips from call block if call fails
				this.innerAgent.InsertProduct(product);

				// If Call succeeds you signal the breaker to stay in the closed state
				// or transition back to Closed from Half-Open state
				// Impossible to signal success in OPen State.
				this.breaker.Succeed();
			}
			// This is a simple implementation in a real world scenario you
			// only want to catch exceptions on specific Exception types
			// You only want exceptions that indicate intermittent errors,
 			// Exceptions like Null Reference rarely indicate this.
			catch (Exception e)
			{
				// From Closed and Half-Open States tripping the breaker
				// puts us in Open.
				// From Open State a time out determines when we move back
				// to Half-Open
				this.breaker.Trip(e);
				throw;
			}
		}

		public IEnumerable<ProductViewModel> SelectAllProducts()
		{
			this.breaker.Guard();
			try
			{
				// Have to save return value of decorated agent before returning it,
				// because you must indicate success in the Circuit Breaker
				var products = this.innerAgent.SelectAllProducts();
				this.breaker.Succeed();
				return products;
			}
			catch (Exception e)
			{
				this.breaker.Trip(e);
				throw;
			}
		}

		public void UpdateProduct(ProductEditorViewModel product)
		{
			this.breaker.Guard();
			try
			{
				this.innerAgent.UpdateProduct(product);
				this.breaker.Succeed();
			}
			catch (Exception e)
			{
				this.breaker.Trip(e);
				throw;
			}
		}
	}
}