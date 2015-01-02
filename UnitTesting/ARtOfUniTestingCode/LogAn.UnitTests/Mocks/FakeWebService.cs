using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.CH4.LogAn;

namespace LogAn.UnitTests
{
	public class FakeWebService : IWebService
	{
		public string LastError;
		// for example 2 in chapter 4
		public Exception ToThrow;

		public void LogError(string message)
		{
			if (ToThrow != null)
			{
				throw ToThrow;
			}
			LastError = message;
		}
	}
}
