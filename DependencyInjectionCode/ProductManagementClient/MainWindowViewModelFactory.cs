using System;
using PresentationLogic;

namespace ProductManagementClient
{
	public class MainWindowViewModelFactory : IMainWindowViewModelFactory
	{
		private readonly IProductManagementAgent agent;

		public MainWindowViewModelFactory(IProductManagementAgent agent)
		{
			if (agent == null)
			{
				throw new ArgumentNullException("agent");
			}

			this.agent = agent;	
		}

		public MainWindowViewModel Create(IWindow window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}

			return new MainWindowViewModel(this.agent, window);
		}
	}
}