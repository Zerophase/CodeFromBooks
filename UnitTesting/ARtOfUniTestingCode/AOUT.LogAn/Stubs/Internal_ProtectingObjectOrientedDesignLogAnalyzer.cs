using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("LogAn.UnitTests")]

namespace AOUT.LogAn
{
	public class Internal_ProtectingObjectOrientedDesignLogAnalyzer
	{
		private IExtensionManager manager;

		internal Internal_ProtectingObjectOrientedDesignLogAnalyzer(
			IExtensionManager extensionMgr)
		{
			manager = extensionMgr;
		}

		public bool IsValidLogFileName(string fileName)
		{
			return manager.IsValid(fileName);
		}
	}
}


