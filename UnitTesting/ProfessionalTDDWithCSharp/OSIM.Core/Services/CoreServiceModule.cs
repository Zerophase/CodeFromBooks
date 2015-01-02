using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace OSIM.Core.Services
{
	public class CoreServiceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IItemTypeService>().To<ItemTypeService>();
		}
	}
}
