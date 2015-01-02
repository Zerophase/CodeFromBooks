using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PresentationLogic;

namespace ProductManagementClient
{
	public class WindowAdapter : IWindow
	{
		private readonly Window wpfWindow;

		public WindowAdapter(Window wpfWindow)
		{
			if (wpfWindow == null)
			{
				throw new ArgumentNullException("window");
			}

			this.wpfWindow = wpfWindow;
		}

		#region IWindow Members

		public virtual void Close()
		{
			this.wpfWindow.Close();
		}

		// NOTE Breaking Cyclic Dependency 1
		// WindowAdapter.ConfigureBehaviour needs a ContentWindow and wpfWindow.
		// this causes a circular dependency.
		// To break it rather than passing everything through Constructor Injection
		// A seam is made, and cw.Owner, and cw.DataContext are given an instance of
		// a wpfWindow, and viewModel, which allows WindowAdapter to use those instances.
		public virtual IWindow CreateChild(object viewModel)
		{
			var cw = new ContentWindow();
			cw.Owner = this.wpfWindow;
			cw.DataContext = viewModel;
			WindowAdapter.ConfigureBehavior(cw);

			return new WindowAdapter(cw);
		}

		public virtual void Show()
		{
			this.wpfWindow.Show();
		}

		public virtual bool? ShowDialog()
		{
			return this.wpfWindow.ShowDialog();
		}

		#endregion

		protected Window WpfWindow
		{
			get { return this.wpfWindow; }
		}

		private static void ConfigureBehavior(ContentWindow cw)
		{
			cw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			cw.CommandBindings.Add(new CommandBinding(PresentationCommands.Accept, (sender, e) => cw.DialogResult = true));
		}
	}
}
