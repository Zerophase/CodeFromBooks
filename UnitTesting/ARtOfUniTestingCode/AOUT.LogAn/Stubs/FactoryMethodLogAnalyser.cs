using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.LogAn
{
	// For Extract and Override
	public class FactoryMethodLogAnalyser
	{
		public bool IsValidLogFileName(string fileName)
		{
			return GetManager().IsValid(fileName);
		}

		protected virtual IExtensionManager GetManager()
		{
			return new FileExtensionManager();
		}
	}
}
