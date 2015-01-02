using System.Windows.Interop;
using PresentationLogic;

namespace ProductManagementClient
{
	public interface IProductManagementClientContainer
	{
		IWindow ResolveWindow();
	}
}