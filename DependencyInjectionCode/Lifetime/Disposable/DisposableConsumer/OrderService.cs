using System;

namespace Lifetime.Disposable.DisposableConsumer
{
	public class OrderService : IDisposable
	{
		private readonly OrderRepository repository;

		public OrderService(OrderRepository repository)
		{
			if (repository == null)
			{
				throw new ArgumentNullException("repository");
			}

			this.repository = repository;
		}

		public OrderRepository Repository
		{
			get { return this.repository; }
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.repository.Dispose();
			}
		}
	}
}