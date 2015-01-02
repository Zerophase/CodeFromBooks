using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	public class StandardStringParser_InheritBase : BaseStringParser
	{
		private string input;

		public StandardStringParser_InheritBase(string input)
			: base(input)
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
