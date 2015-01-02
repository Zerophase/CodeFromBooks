using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AOUT.CH7.LogAn;

namespace LogAn.UnitTests.Tests
{
	[TestFixture]
	public class LogAnalyzerTests
	{
		[Test]
		public void Analyze_EmptyFile_ThrowException()
		{
			LogAnalyzer2 la = new LogAnalyzer2();
			la.Analyze("myemptyfile.txt");
			// Rest of test
		}

		[TearDown]
		public void TearDown()
		{
			// reset static resource between tests
			LoggingFacility.Logger = null;
		}
	}
}
