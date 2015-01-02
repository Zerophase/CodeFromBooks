using System.Runtime.Serialization;

namespace ProductWcfAgent
{
	[DataContract(Namespace = "urn:ploeh:productMgtSrvc")]
	public class MoneyContract
	{
		[DataMember]
		public decimal Amount { get; set; }

		[DataMember]
		public string CurrencyCode { get; set; }
	}
}