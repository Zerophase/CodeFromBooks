using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.LogAn
{
	public class ConstructorInjectionLogAnalyzer
	{
		private IExtensionManager manager;

		// If more than one stub is needed this is unmaintainable.
		public ConstructorInjectionLogAnalyzer(IExtensionManager mgr)
		{
			manager = mgr;
		}

		public bool IsValidLogFileName(string filename)
		{
			//read some file here
			return manager.IsValid(filename);
		}
	}
}
