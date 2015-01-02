using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	public class ConfigurationManager
	{
		private bool result = false;
		public bool IsConfigured(string configName)
		{
			LoggingFacility.Log("checking " + configName);
			return result;
		}
	}
}
