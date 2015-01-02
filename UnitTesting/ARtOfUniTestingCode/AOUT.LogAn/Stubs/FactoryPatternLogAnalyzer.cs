using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOUT.LogAn
{
	public class FactoryPatternLogAnalyzer
	{
		private IExtensionManager manager;

		public FactoryPatternLogAnalyzer()
		{
			manager = ExtensionManagerFactory.Create();
		}

		public bool IsValidLogFilename(string filename)
		{
			return manager.IsValid(filename)
				&& Path.GetFileNameWithoutExtension(filename).Length > 5;
		}
	}
}
