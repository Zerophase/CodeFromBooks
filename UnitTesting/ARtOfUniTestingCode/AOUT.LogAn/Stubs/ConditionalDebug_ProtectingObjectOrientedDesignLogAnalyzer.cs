using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AOUT.LogAn
{
	public class ConditionalDebug_ProtectingObjectOrientedDesignLogAnalyzer
	{
		private IExtensionManager manager;

		public ConditionalDebug_ProtectingObjectOrientedDesignLogAnalyzer()
		{
			manager = new FileExtensionManager();
		}

		[Conditional("DEBUG")]
		public void ExtensionManager(IExtensionManager mgr)
		{
			manager = mgr;
		}

		public bool IsValidLogFileName(string fileName)
		{
			return manager.IsValid(fileName);
		}
	}
}
