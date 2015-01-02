using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.LogAn
{
	public class PreProccessorDirective_ProtectingObjectOrientedDesignLogAnalyzer
	{
		private IExtensionManager manager;

#if DEBUG
		public PreProccessorDirective_ProtectingObjectOrientedDesignLogAnalyzer(IExtensionManager extensionMgr)
		{
			manager = extensionMgr;
		}
#endif

		public PreProccessorDirective_ProtectingObjectOrientedDesignLogAnalyzer()
		{
			manager = new FileExtensionManager();
		}

		public bool IsValidLogFileName(string fileName)
		{
			return manager.IsValid(fileName);
		}
	}
}
