using System;
using System.Collections.Generic;
using System.Text;

namespace AOUT.CH7.LogAn
{
	public interface IStringParser
	{
		string StringToParse { get; }

		bool HasCorrectHeader();
		string GetVersionFromHeader();
	}
}
