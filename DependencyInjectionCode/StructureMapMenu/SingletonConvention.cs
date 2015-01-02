using System;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace StructureMapMenu
{
	// NOTE Convention for autowiring singletons
	// Use with Scan
	public class SingletonConvention : IRegistrationConvention
	{
		// Need to make a custom Convention to automatically,
		// set all class of a type as singleton
		public void Process(Type type, Registry registry)
        {
            registry.For(type).Singleton();
        }
	}
}