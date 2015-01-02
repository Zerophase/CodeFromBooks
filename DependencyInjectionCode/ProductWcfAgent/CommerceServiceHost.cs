using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductWcfAgent
{
	public class CommerceServiceHost : ServiceHost
	{
		public CommerceServiceHost(ICommerceServiceContainer container,
			Type serviceType, params Uri[] baseAddresses)
			: base(serviceType, baseAddresses)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			// THis is a dictionary so must loop over all values to target
			// them all.
			var contracts = this.ImplementedContracts.Values;
			foreach (var c in contracts)
			{
				// NOTE Creates Instance Provider
				var instanceProvider =
					new CommerceInstanceProvider(
						container);
				// Adds instance provider behaviour
				c.Behaviors.Add(instanceProvider);
			}
		}
	}
}
