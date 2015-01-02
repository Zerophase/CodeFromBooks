using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.LogAn
{
	public class PropertyLogAnalyzer
	{
		private IExtensionManager manager;

		public PropertyLogAnalyzer()
		{
			manager = new FileExtensionManager();
		}

		public IExtensionManager ExtensionManager
		{
			get { return manager; }
			set { manager = value; }
		}

		public bool IsValidLogFileName(string fileName)
		{
			return manager.IsValid(fileName);
		}
	}
}
