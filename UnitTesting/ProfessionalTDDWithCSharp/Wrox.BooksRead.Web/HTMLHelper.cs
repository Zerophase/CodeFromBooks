using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wrox.BooksRead.Web
{
	public static class HTMLHelper
	{
		public static string Truncate(string input, int length)
		{
			if (length == 0)
				return input;

			if (string.IsNullOrEmpty(input))
				return string.Empty;

			if (input.Length <= length)
				return input;
			else
				return input.Substring(0, length) + "...";
		}
	}
}