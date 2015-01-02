using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	public abstract class BaseStringParser : IStringParser
	{
		private string stringToParse;
		public string StringToParse
		{
			get { throw new NotImplementedException(); }
		}

		protected BaseStringParser(string fileName)
		{
			this.stringToParse = fileName;
		}
		public abstract bool HasCorrectHeader();
		public abstract string GetVersionFromHeader();
	}
}
