using System.Management.Automation;
using BasketPowerShellLogic;

namespace BasketPowerShell
{
	[Cmdlet(VerbsCommon.Remove, "Basket")]
	public class RemoveBasketCmdlet : Cmdlet
	{
		private readonly BasketManager basketManager;

		public RemoveBasketCmdlet()
		{
			this.basketManager = BasketContainer.ResolveManager();
		}

		[Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
		public string Owner { get; set; }

		protected override void ProcessRecord()
		{
			this.basketManager.RemoveBasket(this.Owner);
		}
	}
}