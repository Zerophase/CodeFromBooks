using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.CH5.LogAn;

namespace LogAn.UnitTests
{
	public class FakeLogger2 : ILogger
	{
		public Exception WillThrow = null;
		public string LoggerGotMessage = null;

		public void LogError(string message)
		{
			LoggerGotMessage = message;
			if (WillThrow != null)
			{
				throw WillThrow;
			}
		}
	}
}
