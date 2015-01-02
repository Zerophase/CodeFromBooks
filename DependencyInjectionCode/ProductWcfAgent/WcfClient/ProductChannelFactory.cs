using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductWcfAgent.WcfClient
{
	public class ProductChannelFactory : IProductChannelFactory
	{
		private readonly ChannelFactory<IProductManagementServiceChannel> channelFactory;

		public ProductChannelFactory()
		{
			channelFactory = new ChannelFactory<IProductManagementServiceChannel>(string.Empty);
		}

		// NOTE Instance of abstract Factory pattern
		public IProductManagementServiceChannel CreateChannel()
		{
			return channelFactory.CreateChannel();
		}
	}
}
