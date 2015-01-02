using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.CH7.LogAn;
using NUnit.Framework;
using NSubstitute;

namespace LogAn.UnitTests
{
	public abstract class FillInTheBlanksStringParserTests
	{
		// Factory method for inheriter to put their thing that inherits
		// from IStringParser
		protected abstract IStringParser GetParser(string input);
		// Hooks for inherit to override with their version of the string.
		protected abstract string HeaderVersion_SingleDigit { get; }
		protected abstract string HeaderVersion_WithMinorVersion { get; }
		protected abstract string HeaderVersion_WithRevision { get; }
		public const string EXPECTED_SINGLE_DIGIT = "1";
		public const string EXPECTED_WITH_REVISION = "1.1.1";
		public const string EXPECTED_WITH_MINORVERSION = "1.1";

		[Test]
		public void GetStringVersionFromHeader_SingleDigit_Found()
		{
			string input = HeaderVersion_SingleDigit;
			IStringParser parser = GetParser(input);

			string versionFromHeader = parser.GetVersionFromHeader();
			Assert.AreEqual(EXPECTED_SINGLE_DIGIT, versionFromHeader);
		}

		[Test]
		public void GetStringVersionFromHeader_WithMinorVersion_Found()
		{
			string input = HeaderVersion_WithMinorVersion;
			IStringParser parser = GetParser(input);

			string versionFromHeader = parser.GetVersionFromHeader();
			Assert.AreEqual(EXPECTED_WITH_MINORVERSION, versionFromHeader);
		}

		[Test]
		public void GetStringVersionFromHeader_WithRevision_Found()
		{
			string input = HeaderVersion_WithRevision;
			IStringParser parser = GetParser(input);

			string versionFromHeader = parser.GetVersionFromHeader();
			Assert.AreEqual(EXPECTED_WITH_REVISION, versionFromHeader);
		}
	}
}
