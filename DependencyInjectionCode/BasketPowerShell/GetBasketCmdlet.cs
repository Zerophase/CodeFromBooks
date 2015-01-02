using System.Management.Automation;
using BasketPowerShellLogic;

namespace BasketPowerShell
{
	[Cmdlet(VerbsCommon.Get, "Basket")]
	public class GetBasketCmdlet : Cmdlet
	{
		private readonly BasketManager basketManager;

		// NOTE Power Shell DI 
		// Use Static class to resolve the container used, by the power shell app
		public GetBasketCmdlet()
		{

			this.basketManager =
				BasketContainer.ResolveManager();
		}

		// This serves as the implementation
		protected override void ProcessRecord()
		{
			var baskets = this.basketManager.GetAllBaskets();
			this.WriteObject(baskets, true);
		}
	}
}