using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	// This allows every class to use the same instance of DateTime, making testing
	// easier without making a ton of complex interfaces.
	public class TimeLogger
	{
		public static string CreateMessage(string info)
		{
			return SystemTime.Now.ToShortDateString() + " " + info;
		}
	}
}
