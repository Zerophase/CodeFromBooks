using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.LogAn
{
	public class VirtualCalculationExtractAndOverride
	{
		public bool IsValidLogFileName(string fileName)
		{
			return this.IsValid(fileName);
		}

		protected virtual bool IsValid(string fileName)
		{
			FileExtensionManager mgr = new FileExtensionManager();
			return mgr.IsValid(fileName);
		}
	}
}
