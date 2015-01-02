using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AOUT.CH7.LogAn;
using NSubstitute;

namespace LogAn.UnitTests
{
	[TestFixture]
	public abstract class TemplateStringParserTests
	{
		public abstract
			void TestGetStringVersionFromHeader_SingleDigit_Found();
		public abstract
			void TestGetStringVersionFromHeader_WithMinorVersion_Found();
		public abstract
			void TetGetStringVersionFromHeader_WithRevision_Found();

	}
}
