using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.LogAn
{
	public class LogAnalyzerCH3
	{
		public bool WasLastFileNameValid { get; set; }

		public bool IsValidLogFileName(string fileName)
		{
			WasLastFileNameValid = false;
			IExtensionManager mgr = new FileExtensionManager();

			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException("filename has to be provided");
			}
			//if (!File.Exists(fileName))
			//{
			//    throw new Exception("No log file with that name exists");
			//}
			if (!fileName.EndsWith(".slf", StringComparison.CurrentCultureIgnoreCase))
			{
				return mgr.IsValid(fileName);
			}

			WasLastFileNameValid = true;
			return mgr.IsValid(fileName);
		}
	}
}
