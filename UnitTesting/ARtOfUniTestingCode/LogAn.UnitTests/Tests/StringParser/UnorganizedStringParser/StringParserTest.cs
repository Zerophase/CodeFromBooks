using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AOUT.CH7.LogAn;
using NSubstitute;

namespace LogAn.UnitTests.Tests.StringParser.UnorganizedStringParser
{
	// Unmaintainable tests
	// the same code needs to be rewritten multiple times for different tests
	// on different schemes for storing the version number, such as XML.
	[TestFixture]
	public class StringParserTest
	{
		private StandardStringParser GetParser(string input)
		{
			return new StandardStringParser(input);
		}
		[Test]
		public void GetStringVersionFromHeader_SingleDigit_Found()
		{
			string input = "header;version=1;\n";
			StandardStringParser parser = GetParser(input);

			string versionFromHeader = parser.GetStringVersionFromHeader();
			Assert.AreEqual("1", versionFromHeader);
		}

		[Test]
		public void GetStringVersionFromHeader_WithMinorVersion_Found()
		{
			string input = "header;version=1.1;\n";
			StandardStringParser parser = GetParser(input);
			// rest of test
		}

		[Test]
		public void GetStringVersionFromHeader_WithRevision_Found()
		{
			string input = "header;version=1.1.1;\n";
			StandardStringParser parser = GetParser(input);
			// rest of test
		}
	}
}
