using System;

namespace ProductWcfAgent.CircuitBreakerWithContinuationPassing
{
	public interface ICircuitBreaker
	{
		void Execute(Action action);
		T Execute<T>(Func<T> action);
	}
}