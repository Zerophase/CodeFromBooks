using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PresentationLogic;
using ProductWcfAgent;
using ProductWcfAgent.WcfClient;

namespace ProductManagementClient
{
	public class ProductManagementClientContainer : IProductManagementClientContainer
	{
		public IWindow ResolveWindow()
		{
			IProductChannelFactory channelFactory =
				new ProductChannelFactory();
			IClientContractMapper mapper =
				new ClientContractMapper();
			IProductManagementAgent agent =
				new WcfProductManagementAgent(channelFactory, mapper);

			IMainWindowViewModelFactory vmFactory =
				new MainWindowViewModelFactory(agent);

			Window mainWindow = new MainWindow();
			IWindow w = new MainWindowAdapter(mainWindow, vmFactory);
			return w;
		}
	}
}
