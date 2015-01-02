using System;
using System.IO;

namespace AOUT.CH2.LogAn
{
    public class LogAnalyzer
    {
		public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
			WasLastFileNameValid = false;
			
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException("filename has to be provided");
			}
            //if (!File.Exists(fileName))
            //{
            //    throw new Exception("No log file with that name exists");
            //}
            if(!fileName.EndsWith(".slf", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

			WasLastFileNameValid = true;
            return true;
        }
    }
}
