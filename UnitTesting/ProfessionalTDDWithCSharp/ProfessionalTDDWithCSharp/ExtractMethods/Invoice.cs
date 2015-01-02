using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalTDDWithCSharp.ExtractMethods
{
	public class Invoice
	{
		public string InvoiceNumber;
		public string CustomerName;
		public CustomerAddress CustomerAddress;
		public string CustomerBillingInformation;

		public bool Approved;

		public float TotalPrice;

		public int Quantity;

		public Invoice()
		{

		}

		public Invoice(string invoiceNumber, float totalPrice, int quantity)
		{
			InvoiceNumber = invoiceNumber;
			TotalPrice = totalPrice;
			Quantity = quantity;
		}
	}
}
