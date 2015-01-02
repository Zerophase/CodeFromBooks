using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalTDDWithCSharp.ExtractMethods
{
	public class PlaceOrder
	{
		public float PricePerWidget;

		public CustomerService _CustomerService;
		public PaymentProcessService _PaymentPrcessService;
		public InvoiceService _InvoiceService;

		public string PlaceOrderForWidgets(int quantity, string customerNumber)
		{
			var invoice = getInvoice(quantity, customerNumber);

			calculatePrice(ref invoice);

			var paymentAuthorizationCode = paymentAuthorization(invoice);

			invoiceApproval(invoice, paymentAuthorizationCode);
			
			return invoice.InvoiceNumber;
		}

		private void invoiceApproval(Invoice invoice, string paymentAuthorizationCode)
		{
			invoice.Approved = !string.IsNullOrEmpty(paymentAuthorizationCode);

			_InvoiceService.Post(invoice);
		}

		private string paymentAuthorization(Invoice invoice)
		{
			var paymentAutorizationCode = _PaymentPrcessService.ProcessPayment
											(
												invoice.TotalPrice,
												invoice.CustomerBillingInformation
											);
			return paymentAutorizationCode;

		}

		private void calculatePrice(ref Invoice invoice)
		{
			var tax = calculateTaxForInvoice(invoice);
			var shippingPrice = calculateShippingPrice(invoice);
			invoice.TotalPrice = calculateTotatalPrice(tax, shippingPrice);
		}

		private float calculateTotatalPrice(float tax, float shippingPrice)
		{
			var totalPrice = tax + shippingPrice;
			return totalPrice;
		}

		private float calculateShippingPrice(Invoice invoice)
		{
			var shippingPrice = invoice.TotalPrice * .1f;
			return shippingPrice;
		}

		private float calculateTaxForInvoice(Invoice invoice)
		{
			float tax;
			switch (invoice.CustomerAddress.State.ToUpper())
			{
				case "OH":
					tax = invoice.TotalPrice * .15f;
					break;
				case "MI":
					tax = invoice.TotalPrice * .22f;
					break;
				case "NV":
					tax = invoice.TotalPrice * .05f;
					break;
				default:
					tax = 0f;
					break;
			}
			return tax;
		}

		private Invoice getInvoice(int quantity, string customerNumber)
		{
			var invoice = new Invoice
			{
				InvoiceNumber = Guid.NewGuid().ToString(),
				TotalPrice = PricePerWidget * quantity,
				Quantity = quantity
			};

			assignCustomerInfo(ref invoice, customerNumber);

			return invoice;
		}

		private void assignCustomerInfo(ref Invoice invoice, string customerNumber)
		{
			var customer = _CustomerService.GetCustomer(customerNumber);
			invoice.CustomerName = customer.CustomerName;
			invoice.CustomerAddress = customer.CustomerAddress;
			invoice.CustomerBillingInformation = customer.CustomerBillingInformation;
		}
	}
}
