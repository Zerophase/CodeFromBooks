using System;
using System.Web;

namespace MvcLifetime
{
	// NOTE Managing Web Request LifeStyle
	public class DiscountRepositoryLifestyleModule : IHttpModule
	{
		public void Init(HttpApplication context)
		{
			context.EndRequest += this.OnEndRequest;
		}

		public void Dispose() { }

		private void OnEndRequest(object sender, EventArgs e)
		{
			// When Web request ends the repository is attempted to be
			// looked up.
			var repository = HttpContext.Current
				.Items["DiscountRepository"];
			if (repository == null)
			{
				return;
			}

			// If found it can be disposed of if applicable
			var disposable = repository as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}

			// Removes the repository from the webrequest context
			HttpContext.Current
				.Items.Remove("DiscountRepository");
		}
	}
}