using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ninject;
using OSIM.Core.Services;
using OSIM.Core.Persistence;

namespace OSIM.ExternalServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInventoryService" in both code and config file together.
	[ServiceContract]
	public interface IInventoryService
	{
		[OperationContract]
		string[] GetItemTypes();
	}

	
}
