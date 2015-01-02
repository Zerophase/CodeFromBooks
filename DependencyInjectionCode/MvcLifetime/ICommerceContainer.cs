using System.Web.Mvc;

namespace MvcLifetime
{
	public interface ICommerceContainer
	{
		IController ResolveHomeController();
	}
}