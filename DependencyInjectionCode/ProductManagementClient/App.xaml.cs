using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProductManagementClient
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		// need to override OnStartup for DI Container use
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var container = new ProductManagementClientContainer();
			container.ResolveWindow().Show();
		}
	}
}
