namespace ProductWcfAgent
{
	public interface ICommerceServiceContainer
	{
		void Release(object instance);
		IProductManagementService ResolveProductManagementService();
	}
}