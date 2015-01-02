using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	public class LogAnalyzer2
	{
		public void Analyze(string fileName)
		{
			if (fileName.Length < 8)
			{
				LoggingFacility.Log("Filename too short: " + fileName);
			}
			// rest of method
		}
	}
}
