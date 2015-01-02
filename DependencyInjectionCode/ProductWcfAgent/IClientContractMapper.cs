using System.Collections;
using System.Collections.Generic;
using DomainModel;
using PresentationLogic;
using WPFInjection = ProductWcfAgent.WcfClient;

namespace ProductWcfAgent
{
	public interface IClientContractMapper
	{
		MoneyViewModel Map(WPFInjection.MoneyContract money);

		ProductViewModel Map(WPFInjection.ProductContract moneyContract);

		IEnumerable<ProductViewModel> Map(IEnumerable<WPFInjection.ProductContract> products);

		WPFInjection.ProductContract Map(ProductEditorViewModel productContract);
	}
}