using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AOUT.CH7.LogAn;
using NSubstitute;

namespace LogAn.UnitTests.Tests
{
	[TestFixture]
	public class StandardStringParser_FillInTheBlanks : FillInTheBlanksStringParserTests
	{
		protected override IStringParser GetParser(string input)
		{
			return new StandardStringParser_InheritBase(input);
		}

		// Overriding hookw with this tests version
		protected override string HeaderVersion_SingleDigit
		{
			get 
			{
				return string.Format("Header\tversion={0}\t\n",
					EXPECTED_SINGLE_DIGIT);
			}
		}

		protected override string HeaderVersion_WithMinorVersion
		{
			get 
			{ 
				return string.Format("Header\tversion={0}\t\n",
					EXPECTED_WITH_MINORVERSION);
			}
		}

		protected override string HeaderVersion_WithRevision
		{
			get 
			{ 
				return string.Format("Header\tversion={0}\t\n",
					EXPECTED_WITH_REVISION);
			}
		}
	}
}
