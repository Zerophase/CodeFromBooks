using PresentationLogic;

namespace ProductManagementClient
{
	// Abstract Factory for Breaking cyclic dependency.
	public interface IMainWindowViewModelFactory
	{
		MainWindowViewModel Create(IWindow window);
	}
}