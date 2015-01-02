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
	public class MainWindowAdapter : WindowAdapter
	{
		private readonly IMainWindowViewModelFactory vmFactory;
		private bool initialized;

		public MainWindowAdapter(Window wpfWindow, IMainWindowViewModelFactory viewModelFactory)
			: base(wpfWindow)
		{
			if (viewModelFactory == null)
			{
				throw new ArgumentNullException("viewModelFactory");
			}

			this.vmFactory = viewModelFactory;
		}

		#region IWindow Members

		public override void Close()
		{
			this.EnsureInitialized();
			base.Close();
		}

		public override IWindow CreateChild(object viewModel)
		{
			this.EnsureInitialized();
			return base.CreateChild(viewModel);
		}

		public override void Show()
		{
			this.EnsureInitialized();
			base.Show();
		}

		public override bool? ShowDialog()
		{
			this.EnsureInitialized();
			return base.ShowDialog();
		}

		#endregion

		// NOTE Breaking Cylclic dependency 2
		// This allows us to defer the initialization of IWindow
		// Until the first method is called.
		// Everything is assigned to the WpfWindow before the ViewModel gets passed to declare bindings.
		// WpfWIndow.DataContext allows us to inject the ViewModel when needed, so WpfWindow knows
		// how to behave when the model does something. 
		private void EnsureInitialized()
		{
			if (this.initialized)
			{
				return;
			}

			var vm = this.vmFactory.Create(this);
			this.WpfWindow.DataContext = vm;
			this.DeclareKeyBindings(vm);

			this.initialized = true;
		}

		private void DeclareKeyBindings(MainWindowViewModel vm)
		{
			this.WpfWindow.InputBindings.Add(new KeyBinding(vm.RefreshCommand, new KeyGesture(Key.F5)));
			this.WpfWindow.InputBindings.Add(new KeyBinding(vm.InsertProductCommand, new KeyGesture(Key.Insert)));
			this.WpfWindow.InputBindings.Add(new KeyBinding(vm.EditProductCommand, new KeyGesture(Key.Enter)));
			this.WpfWindow.InputBindings.Add(new KeyBinding(vm.DeleteProductCommand, new KeyGesture(Key.Delete)));
		}


	}
}
