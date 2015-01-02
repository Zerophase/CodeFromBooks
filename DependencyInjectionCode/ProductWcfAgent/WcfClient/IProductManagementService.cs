using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This was used in a previous iteration
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:productMgtSrvc", ClrNamespace = "ProductWcfAgent.WcfClient")]

namespace ProductWcfAgent.WcfClient
{
	using System.Runtime.Serialization;


	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name = "ProductContract", Namespace = "urn:productMgtSrvc")]
	public partial class ProductContract : object, System.Runtime.Serialization.IExtensibleDataObject
	{

		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private int IdField;

		private string NameField;

		private ProductWcfAgent.WcfClient.MoneyContract UnitPriceField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData
		{
			get
			{
				return this.extensionDataField;
			}
			set
			{
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public int Id
		{
			get
			{
				return this.IdField;
			}
			set
			{
				this.IdField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				this.NameField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public ProductWcfAgent.WcfClient.MoneyContract UnitPrice
		{
			get
			{
				return this.UnitPriceField;
			}
			set
			{
				this.UnitPriceField = value;
			}
		}
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Name = "MoneyContract", Namespace = "urn:productMgtSrvc")]
	public partial class MoneyContract : object, System.Runtime.Serialization.IExtensibleDataObject
	{

		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private decimal AmountField;

		private string CurrencyCodeField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData
		{
			get
			{
				return this.extensionDataField;
			}
			set
			{
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public decimal Amount
		{
			get
			{
				return this.AmountField;
			}
			set
			{
				this.AmountField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute()]
		public string CurrencyCode
		{
			get
			{
				return this.CurrencyCodeField;
			}
			set
			{
				this.CurrencyCodeField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	[System.ServiceModel.ServiceContractAttribute(Namespace = "urn:productMgtSrvc", ConfigurationName = "ProductWcfAgent.WcfClient.IProductManagementService")]
	public interface IProductManagementService
	{

		[System.ServiceModel.OperationContractAttribute(Action = "urn:productMgtSrvc/IProductManagementService/DeleteProduct", ReplyAction = "urn:productMgtSrvc/IProductManagementService/DeleteProductResponse")]
		void DeleteProduct(int productId);

		[System.ServiceModel.OperationContractAttribute(Action = "urn:productMgtSrvc/IProductManagementService/InsertProduct", ReplyAction = "urn:productMgtSrvc/IProductManagementService/InsertProductResponse")]
		void InsertProduct(ProductWcfAgent.WcfClient.ProductContract product);

		[System.ServiceModel.OperationContractAttribute(Action = "urn:productMgtSrvc/IProductManagementService/SelectProduct", ReplyAction = "urn:productMgtSrvc/IProductManagementService/SelectProductResponse")]
		ProductWcfAgent.WcfClient.ProductContract SelectProduct(int productId);

		[System.ServiceModel.OperationContractAttribute(Action = "urn:productMgtSrvc/IProductManagementService/SelectAllProducts", ReplyAction = "urn:productMgtSrvc/IProductManagementService/SelectAllProductsResponse")]
		ProductWcfAgent.WcfClient.ProductContract[] SelectAllProducts();

		[System.ServiceModel.OperationContractAttribute(Action = "urn:productMgtSrvc/IProductManagementService/UpdateProduct", ReplyAction = "urn:productMgtSrvc/IProductManagementService/UpdateProductResponse")]
		void UpdateProduct(ProductWcfAgent.WcfClient.ProductContract product);
	}

	// NOTE Provides interface for Opening and Closing SHort lived dependencies
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public interface IProductManagementServiceChannel : ProductWcfAgent.WcfClient.IProductManagementService, System.ServiceModel.IClientChannel
	{
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public partial class ProductManagementServiceClient : System.ServiceModel.ClientBase<ProductWcfAgent.WcfClient.IProductManagementService>, ProductWcfAgent.WcfClient.IProductManagementService
	{

		public ProductManagementServiceClient()
		{
		}

		public ProductManagementServiceClient(string endpointConfigurationName) :
			base(endpointConfigurationName)
		{
		}

		public ProductManagementServiceClient(string endpointConfigurationName, string remoteAddress) :
			base(endpointConfigurationName, remoteAddress)
		{
		}

		public ProductManagementServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
			base(endpointConfigurationName, remoteAddress)
		{
		}

		public ProductManagementServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
			base(binding, remoteAddress)
		{
		}

		public void DeleteProduct(int productId)
		{
			base.Channel.DeleteProduct(productId);
		}

		public void InsertProduct(ProductWcfAgent.WcfClient.ProductContract product)
		{
			base.Channel.InsertProduct(product);
		}

		public ProductWcfAgent.WcfClient.ProductContract SelectProduct(int productId)
		{
			return base.Channel.SelectProduct(productId);
		}

		public ProductWcfAgent.WcfClient.ProductContract[] SelectAllProducts()
		{
			return base.Channel.SelectAllProducts();
		}

		public void UpdateProduct(ProductWcfAgent.WcfClient.ProductContract product)
		{
			base.Channel.UpdateProduct(product);
		}
	}
}
