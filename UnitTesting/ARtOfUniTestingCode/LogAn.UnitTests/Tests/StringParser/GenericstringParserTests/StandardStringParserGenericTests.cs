using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using AOUT.CH7.LogAn;

namespace LogAn.UnitTests.Tests.StringParser.GenericstringParserTests
{
	[TestFixture]
	public class StandardStringParserGenericTests
		: GenericParserTests<StandardStringParser_InheritBase>
	{
		protected override string GetInputHeaderSingleDigit()
		{
			return "Header;1";
		}
	}
}
