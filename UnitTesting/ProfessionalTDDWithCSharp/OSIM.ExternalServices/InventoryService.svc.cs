using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ninject;
using OSIM.Core.Services;
using OSIM.Core.Persistence;
using Ninject.Extensions.Wcf;

namespace OSIM.ExternalServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoryService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select InventoryService.svc or InventoryService.svc.cs at the Solution Explorer and start debugging.
	public class InvetoryService : IInventoryService
	{
		public string[] GetItemTypes()
		{
			var kernel = new StandardKernel(new PersistenceModule(), new CoreServiceModule());
			var itemTypeService = kernel.Get<IItemTypeService>();

			var itemTypeList = itemTypeService.GetItemTypes().Select(itemType => itemType.Name).ToArray();
			return itemTypeList;
		}
	}
}
