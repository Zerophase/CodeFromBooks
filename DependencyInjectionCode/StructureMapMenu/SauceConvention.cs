using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuModel;
using StructureMap.Graph;
using StructureMap.Configuration.DSL;

namespace StructureMapMenu
{
	// NOTE Structure Map Custom Creation Convention
    public class SauceConvention : IRegistrationConvention
    {
		// applies to each type in the assembly defined in 
		// a scan clause
		// We still define the assembly outside of the convention
		// allowing us to vary the source of the types independent of the convention
		public void Process(Type type, Registry registry)
		{
			var interfaceType = typeof(IIngredient);
			// need guard clauses for each type not cared for
			if (!interfaceType.IsAssignableFrom(type))
			{
				return;
			}
			if (!type.Name.StartsWith("Sauce"))
			{
				return;
			}

			registry.For(interfaceType).Use(type);
		}
	}
}
