using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.LogAn
{
	class FileExtensionManager : IExtensionManager
	{
		public bool WasLastFileNameValid { get; set; }

		public bool IsValid(string filename)
		{
			WasLastFileNameValid = false;
			IExtensionManager mgr = new FileExtensionManager();

			if (string.IsNullOrEmpty(filename))
			{
				throw new ArgumentException("filename has to be provided");
			}
			//if (!File.Exists(fileName))
			//{
			//    throw new Exception("No log file with that name exists");
			//}
			if (!filename.EndsWith(".slf", StringComparison.CurrentCultureIgnoreCase))
			{
				return false;
			}

			WasLastFileNameValid = true;
			return true;
		}
	}
}
