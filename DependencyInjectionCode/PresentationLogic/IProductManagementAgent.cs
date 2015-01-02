using System.Collections;
using System.Collections.Generic;

namespace PresentationLogic
{
	public interface IProductManagementAgent
	{
		void DeleteProduct(int productId);
		void InsertProduct(ProductEditorViewModel product);
		IEnumerable<ProductViewModel> SelectAllProducts();
		void UpdateProduct(ProductEditorViewModel product);
	}
}