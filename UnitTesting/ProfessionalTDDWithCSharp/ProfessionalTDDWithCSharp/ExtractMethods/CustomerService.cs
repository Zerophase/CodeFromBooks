using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalTDDWithCSharp.ExtractMethods
{
	public class CustomerService
	{
		public List<Customer> Customers = new List<Customer>();

		public Customer GetCustomer(string customerNumber)
		{
			return Customers.Find(customer => customer.CustomerNumber == customerNumber);
		}
	}
}
