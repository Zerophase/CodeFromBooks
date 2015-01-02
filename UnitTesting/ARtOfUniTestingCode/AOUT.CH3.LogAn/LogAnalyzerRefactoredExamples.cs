using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH3.LogAn
{
	public class LogAnalyzerRefactoredExamples
	{
		private bool wasLastFileNameValid;

		public bool WasLastFileNameValid
		{
			get { return wasLastFileNameValid; }
			set { wasLastFileNameValid = value; }
		}

		public bool IsValidLogFileName(string fileName)
		{
			if (!fileName.ToLower().EndsWith(".slf"))
			{
				wasLastFileNameValid = false;
				return false;
			}

			wasLastFileNameValid = true;
			return true;
		}
	}
}
