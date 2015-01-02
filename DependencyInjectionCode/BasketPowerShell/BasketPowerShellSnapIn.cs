using System.ComponentModel;
using System.Management.Automation;

namespace BasketPowerShell
{
	[RunInstaller(true)]
	public class BasketPowerShellSnapIn : PSSnapIn
	{
		public override string Description
		{
			get { return "Sample snap-in for the Dependency Injection in .NET sample commerce application offering basket management functionality."; }
		}

		public override string Name
		{
			get { return "SampleCommerceBasketSnapIn"; }
		}

		public override string Vendor
		{
			get { return "Ploeh"; }
		}
	}
}