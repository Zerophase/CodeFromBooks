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
	public class LogAnalyzerTest_Refactored : BaseTestsClass
	{
		[Test]
		public void Analyze_EmptyFile_ThrowsException()
		{
			FakeTheLogger();

			LogAnalyzer2 la = new LogAnalyzer2();
			la.Analyze("myemptyfile.txt");
			// rest of test
		}
	}
}
