using System;

namespace ProductWcfAgent
{
	public class CircuitBreaker : ICircuitBreaker
	{
		private ICircuitState state;

		public CircuitBreaker(TimeSpan timeout)
		{
			this.state = new ClosedCircuitState(timeout);
		}

		public ICircuitState State
		{
			get { return this.state; }
		}


		public void Guard()
		{
			this.state = this.state.NextState();
			this.state.Guard();
			this.state = this.state.NextState();
		}

		public void Trip(Exception e)
		{
			this.state = this.state.NextState();
			this.state.Trip(e);
			this.state = this.state.NextState();
		}

		public void Succeed()
		{
			this.state = this.state.NextState();
			this.state.Succeed();
			this.state = this.state.NextState();
		}
	}
}