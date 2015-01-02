using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.LogAn
{
	public class ExtensionManagerFactory
	{
		private static IExtensionManager customManager = null;

		// read about #debug switch
		public static IExtensionManager Create()
		{
			if (customManager != null)
				return customManager;
			return new FileExtensionManager();
		}

		public static void SetManager(IExtensionManager mgr)
		{
			customManager = mgr;
		}
	}
}
