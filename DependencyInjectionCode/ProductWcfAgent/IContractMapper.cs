using System.Collections.Generic;
using DomainModel;
using ProductWcfAgent.WcfClient;

namespace ProductWcfAgent
{
	public interface IContractMapper
	{
		MoneyContract Map(Money money);

		Money Map(MoneyContract moneyContract);

		ProductContract Map(Product product);

		IEnumerable<ProductContract> Map(IEnumerable<Product> products);

		Product Map(ProductContract productContract);
	}
}