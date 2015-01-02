namespace Lifetime
{
	public interface ICommerceServiceContainer
	{
		void Release(object instance);

		IProductManagementService ResolveProductManagementService();
	}
}