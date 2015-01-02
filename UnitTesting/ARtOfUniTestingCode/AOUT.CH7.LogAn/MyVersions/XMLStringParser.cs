using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	public class XMLStringParser : BaseStringParser
	{
		private string input;

		public XMLStringParser(string toParse)
			:base(toParse)
		{

		}

		public override bool HasCorrectHeader()
		{
			return false;
		}

		public override string GetVersionFromHeader()
		{
			return string.Empty;
		}
	}
}
