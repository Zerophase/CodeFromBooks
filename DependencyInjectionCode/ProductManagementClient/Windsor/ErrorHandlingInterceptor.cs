using System;
using System.ServiceModel;
using System.Text;
using System.Windows;
using Castle.DynamicProxy;

namespace ProductManagementClient.Windsor
{
	// NOTE Decorator Interceptor implementation with DI Framework
	// Requires more generalized design of the aspect since
	// it may be applied to any class.
	public class ErrorHandlingInterceptor : IInterceptor
	{
		// IInvocation represents the method called
		public void Intercept(IInvocation invocation)
		{
			try
			{
				// Invokes decorated method
				invocation.Proceed();
			}
			catch (CommunicationException e)
			{
				// Adds Aspects to the Decorated class
				this.AlertUser(e.Message);
			}
			catch (InvalidOperationException e)
			{
				this.AlertUser(e.Message);
			}
		}

		private void AlertUser(string message)
		{
			var sb = new StringBuilder();
			sb.AppendLine("An error occurred.");
			sb.AppendLine("Your work is likely lost.");
			sb.AppendLine("Please try again later.");
			sb.AppendLine();
			sb.AppendLine(message);

			MessageBox.Show(sb.ToString(), "Error",
				MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}