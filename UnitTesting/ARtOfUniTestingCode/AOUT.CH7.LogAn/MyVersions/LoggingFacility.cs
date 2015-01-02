using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	public class LoggingFacility
	{
		private static ILogger logger;
		public static ILogger Logger
		{
			get { return logger; }
			set { logger = value; }
		}
		public static void Log(string text)
		{
			logger.Log(text);
		}
	}
}
