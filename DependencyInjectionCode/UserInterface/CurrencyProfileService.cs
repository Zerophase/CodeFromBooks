using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserInterface
{
	public abstract class CurrencyProfileService
	{
		public abstract string GetCurrencyCode();
		public abstract void UpdateCurrencyCode(string currencyCode);
	}
}