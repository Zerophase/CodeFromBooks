using System;
using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PresentationLogic;
using ProductWcfAgent;
using ProductWcfAgent.WcfClient;

namespace ProductManagementClient.Windsor
{
	// NOTE Benefits of Dynamic Interception
	// Allows us to Address of Cross-Cutting Concerns,
	// while following SOLID and DRY;
	// loose coupled aspects; and option to apply conventions
	// or complex heuristics to determine when and where
	// to apply which aspects.
	// Only problem with this is it can highly confuse novice developers
	public class ProductManagementClientInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component
				.For<IProductChannelFactory>()
				.ImplementedBy<ProductChannelFactory>());
			container.Register(Component
				.For<IClientContractMapper>()
				.ImplementedBy<ClientContractMapper>());
			container.Register(Component
				.For<IProductManagementAgent>()
				.ImplementedBy<WcfProductManagementAgent>());

			container.Register(Component
				.For<IMainWindowViewModelFactory>()
				.ImplementedBy<MainWindowViewModelFactory>());

			container.Register(Component
				.For<Window>()
				.ImplementedBy<MainWindow>());
			container.Register(Component
				.For<IWindow>()
				.ImplementedBy<MainWindowAdapter>()
				.LifeStyle.Transient);

			// NOTE How to Register Interceptor with Windsor
			// With Windsor every component must be explicitly registered
			// before use, not all DI Containers work this way.
			container.Register(Component.For<ErrorHandlingInterceptor>());
			container.Register(Component.For<DefaultValueInterceptor>());

			// How to register the dependency used by CircuitBreaker
			// This maps an interface used by a class to a concrete implementation
			// for all other classes using it.
			container.Register(Component
				.For<ICircuitBreaker>()
				.ImplementedBy<CircuitBreaker>()
				.DependsOn(new
				{
					timeout = TimeSpan.FromMinutes(1)
				}));

			// Instead of repeating Circuit Breaker design for every class that needs
			// it, you write it once, and then build the combined behavior of 
			// all classes involved in the composition root
			container.Register(Component.For<CircuitBreakerInterceptor>());

			// Activate the Interceptors registered, and when they activate
			container.Kernel.ProxyFactory.AddInterceptorSelector(
				new ProductManagementClientInterceptorSelector());
		}
	}
}