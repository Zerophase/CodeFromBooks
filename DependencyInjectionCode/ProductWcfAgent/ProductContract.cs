using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProductWcfAgent.WcfClient;

namespace ProductWcfAgent
{
	[DataContract(Namespace = "urn:productMgtSrvc")]
    public class ProductContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public MoneyContract UnitPrice { get; set; }
    }
}
