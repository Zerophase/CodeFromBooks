using System;
using Castle.DynamicProxy;
using ProductWcfAgent;

namespace ProductManagementClient.Windsor
{
	public class CircuitBreakerInterceptor : IInterceptor
	{
		private readonly ICircuitBreaker breaker;

		public CircuitBreakerInterceptor(
			ICircuitBreaker breaker)
		{
			if (breaker == null)
			{
				throw new ArgumentNullException(
					"breaker");
			}

			this.breaker = breaker;
		}

		public void Intercept(IInvocation invocation)
		{
			// implement aspect
			this.breaker.Guard();
			try
			{
				// invoke decorated method
				invocation.Proceed();
				// implement aspect
				this.breaker.Succeed();
			}
			catch (Exception e)
			{
				// implement aspect
				this.breaker.Trip(e);
				throw;
			}
		}
	}
}