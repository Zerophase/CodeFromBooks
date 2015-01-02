using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Lifetime;
using Xunit;

namespace LifetimeUnitTest
{
	// NOTE AUtofac Configuration
	// You don't build a conatiner itself, a container builder is used to build the container.
	// ONce the configuration is completed the container is told to build itself
    public class AutofacScenario
    {
		[Fact]
	    public void ConfigureWithAllPerDependencyInstanceScope()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<ContractMapper>().As<IContractMapper>().
				SingleInstance();
			// This lambda expression is run when the ProductRepository type gets requeseted.
			// Need to replace the ConfigurationManager call by getting the connection string from the
			// Application Configuration
			builder.Register((c, p) =>
				new SqlProductRepository(ConfigurationManager.
					ConnectionStrings["CommerceObjectContext"].
					ConnectionString)).As<ProductRepository>();
			builder.RegisterType<ProductManagementService>().
				As<IProductManagementService>();
			var container = builder.Build();

			var service = container.Resolve<IProductManagementService>();
			var service2 = container.Resolve<IProductManagementService>();

		}
    }
}
