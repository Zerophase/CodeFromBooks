using System.Linq;
using Castle.Core;
using Castle.MicroKernel.Proxy;
using PresentationLogic;

namespace ProductManagementClient.Windsor
{
	// NOTE Composition of interceptors with Interface that uses them
	public class ProductManagementClientInterceptorSelector :
		IModelInterceptorsSelector
	{
		// Calls HasInterceptors to see whether given component
		// has any interceptors
		public bool HasInterceptors(ComponentModel model)
		{
			// Applies Interceptors to IProductManagementAgent
			// In case this implementation doesn't work write it like this:
			// return model.Services.Any(x => { return typeof (IProductManagementAgent).IsAssignableFrom(x); });
			return model.Services.Any(x => typeof (IProductManagementAgent).IsAssignableFrom(x));
		}

		// When Has Interceptors returns true SelectInterceptors is called
		public InterceptorReference[]
			SelectInterceptors(ComponentModel model,
				InterceptorReference[] interceptors)
		{
			// returns references to the interceptors registered
			// This allows Windsor to auto wire any interceptors that have
			// their own dependencies
			return new[] 
            {
				// Returns interceptors
                InterceptorReference
                    .ForType<DefaultValueInterceptor>(),
                InterceptorReference
                    .ForType<ErrorHandlingInterceptor>(),
                InterceptorReference
                    .ForType<CircuitBreakerInterceptor>()
            };
		}
	}
}