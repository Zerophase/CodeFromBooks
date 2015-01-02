using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	// This allows every class to use the same instance of DateTime, making testing
	// easier without making a ton of complex interfaces.
	public class SystemTime
	{
		private static DateTime _date;

		public static void Set(DateTime custom)
		{
			_date = custom;
		}

		public static void Reset()
		{
			_date = DateTime.MinValue;
		}

		public static DateTime Now
		{
			get
			{
				if (_date != DateTime.MinValue)
				{
					return _date;
				}
				return DateTime.Now;
			}
		}
	}
}
