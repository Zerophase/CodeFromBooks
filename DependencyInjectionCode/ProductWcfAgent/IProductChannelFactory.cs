using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWcfAgent.WcfClient;

namespace ProductWcfAgent
{
	public interface IProductChannelFactory
	{
		IProductManagementServiceChannel CreateChannel();
	}
}
