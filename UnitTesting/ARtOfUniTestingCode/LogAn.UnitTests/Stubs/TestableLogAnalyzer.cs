using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.LogAn;

namespace LogAn.UnitTests
{
	// For Extract and Override
	public class TestableLogAnalyzer : FactoryMethodLogAnalyser
	{
		public IExtensionManager Manager;

		public TestableLogAnalyzer(IExtensionManager mgr)
		{
			Manager = mgr;
		}

		protected override IExtensionManager GetManager()
		{
			return Manager;
		}
	}
}
