using System;
using System.Collections.Generic;
using DomainModel;
using PresentationLogic;
using WPFInjection = ProductWcfAgent.WcfClient;

namespace ProductWcfAgent
{
	public class ClientContractMapper : IClientContractMapper
	{

		public MoneyViewModel Map(WPFInjection.MoneyContract contract)
		{
			if (contract == null)
			{
				throw new ArgumentNullException("contract");
			}

			var vm = new MoneyViewModel();
			vm.Amount = contract.Amount;
			vm.CurrencyCode = contract.CurrencyCode;
			return vm;
		}

		public ProductViewModel Map(WPFInjection.ProductContract contract)
		{
			if (contract == null)
			{
				throw new ArgumentNullException("contract");
			}

			var vm = new ProductViewModel();
			vm.Id = contract.Id;
			vm.Name = contract.Name;
			vm.UnitPrice = this.Map(contract.UnitPrice);
			return vm;
		}

		public IEnumerable<ProductViewModel> Map(IEnumerable<WPFInjection.ProductContract> contracts)
		{
			if (contracts == null)
			{
				throw new ArgumentNullException("contracts");
			}

			foreach (var contract in contracts)
			{
				yield return this.Map(contract);
			}
		}

		public WPFInjection.ProductContract Map(ProductEditorViewModel productEditorViewModel)
		{
			if (productEditorViewModel == null)
			{
				throw new ArgumentNullException("productEditorViewModel");
			}

			var pc = new WPFInjection.ProductContract();
			pc.Id = productEditorViewModel.Id;
			pc.Name = productEditorViewModel.Name;
			pc.UnitPrice = new WPFInjection.MoneyContract
			{
				Amount = decimal.Parse(productEditorViewModel.Price),
				CurrencyCode = productEditorViewModel.Currency
			};
			return pc;
		}
	}
}