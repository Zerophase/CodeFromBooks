using MenuModel;
using Microsoft.Practices.Unity;

namespace UnityMenu
{
	// NOTE Unity Container Extension for registering types
	public class IngredientExtension : UnityContainerExtension
	{

		protected override void Initialize()
		{
			var a = typeof(Steak).Assembly;
			foreach (var t in a.GetExportedTypes())
			{
				// This filter clutters the sample code and is removed in the book
				if (typeof(IIngredient) == t || typeof(Breading) == t)
				{
					continue;
				}
				if (typeof(IIngredient).IsAssignableFrom(t))
				{
					this.Container.RegisterType(
						typeof(IIngredient), t, t.FullName);
				}
			}
		}
	}
}