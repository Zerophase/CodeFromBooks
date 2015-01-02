using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ProductWcfAgent
{
	// IInstanceProvider, and IContractBehavior implement the WCF interface
	public partial class CommerceInstanceProvider :
		IInstanceProvider, IContractBehavior
	{
		private readonly ICommerceServiceContainer container;

		// NOTE injecting the Container is normally a big code smell, but
		// is neccesary here as we are implementing the Composition Root
		public CommerceInstanceProvider(ICommerceServiceContainer container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			this.container = container;
		}
	}

	public partial class CommerceInstanceProvider
	{
		public object GetInstance(InstanceContext instanceContext, Message message)
		{
			return this.GetInstance(instanceContext); // Overloads the standard GetInstance to return ours
		}

		public object GetInstance(InstanceContext instanceContext)
		{
			return this.container
				.ResolveProductManagementService(); // We use our container to resolve instances.
		}

		public void ReleaseInstance(InstanceContext instanceContext,
			object instance)
		{
			this.container.Release(instance); // Releases our container
		}
	}

	// All of the IContract methods return void, and do nothing 
	// The only reason they're used is to allow us to add the InstanceProvider to the list
	// of Behaviours in CommerceServiceHost
	public partial class CommerceInstanceProvider
	{
		#region IContractBehavior Members

		public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}

		// Need to set DispatchRumtime InstanceProvider to this class, so it's
		// used for all instances
		public void ApplyDispatchBehavior(
			ContractDescription contractDescription, ServiceEndpoint endpoint,
			DispatchRuntime dispatchRuntime)
		{
			dispatchRuntime.InstanceProvider = this;
		}

		public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
		{
		}

		#endregion
	}
}