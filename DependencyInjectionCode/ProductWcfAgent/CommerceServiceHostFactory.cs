using System;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace ProductWcfAgent
{
	public class CommerceServiceHostFactory : ServiceHostFactory
	{
		 private readonly ICommerceServiceContainer container;

		// NOTE Creates Container
		public CommerceServiceHostFactory()
		{
			this.container =
				new ReleasingCommerceServiceContainer();
		}

		// NOTE Creates Cusom Service Host
		protected override ServiceHost CreateServiceHost(
			Type serviceType, Uri[] baseAddresses)
		{
			if (serviceType == typeof(ProductManagementService))
			{
				return new CommerceServiceHost(
					this.container,
					serviceType, baseAddresses);
			}
			return base.CreateServiceHost(serviceType, baseAddresses);
		}
	}
}