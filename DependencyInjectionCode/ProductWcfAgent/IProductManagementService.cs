using System.ServiceModel;
using ProductWcfAgent.WcfClient;

namespace ProductWcfAgent
{
	[ServiceContract(Namespace = "urn:productMgtSrvc")]
	public interface IProductManagementService
	{
		[OperationContract]
		void DeleteProduct(int productId);

		[OperationContract]
		void InsertProduct(ProductContract product);

		[OperationContract]
		ProductContract SelectProduct(int productId);

		[OperationContract]
		ProductContract[] SelectAllProducts();

		[OperationContract]
		void UpdateProduct(ProductContract product);
	}
}