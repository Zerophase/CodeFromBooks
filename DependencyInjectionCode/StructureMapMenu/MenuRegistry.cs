using MenuModel;
using StructureMap.Configuration.DSL;

namespace StructureMapMenu
{
	// NOTE Creating types that container uses to configure
	// classes
	public class MenuRegistry : Registry
	{
		// Add all of the types needed for a concept in the constructor
		// and just have the container register it, and all of those types
		// will be setup
		public MenuRegistry()
		{
			this.For<ICourse>().Use<Course>();
			Scan(s =>
			{
				s.AssemblyContainingType<Steak>();
				s.AddAllTypesOf<IIngredient>();
				s.ExcludeType<Breading>();
			});
		}
	}
}