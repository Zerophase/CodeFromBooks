using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;
using PresentationLogic;

namespace ProductManagementClient.Windsor
{
	public class DefaultValueInterceptor : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			if (typeof(IEnumerable<ProductViewModel>).IsAssignableFrom(invocation.Method.ReturnType))
			{
				invocation.ReturnValue = Enumerable.Empty<ProductViewModel>();
			}
			invocation.Proceed();
		}
	}
}