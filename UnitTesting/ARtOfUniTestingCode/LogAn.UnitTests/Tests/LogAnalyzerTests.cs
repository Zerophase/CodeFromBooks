using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AOUT.CH2.LogAn;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
		private LogAnalyzer MakeAnalyzer()
		{
			return new LogAnalyzer();
		}

		[TestCase("filewithgoodextension.SLF")]
		[TestCase("filewithgoodextension.slf")]
		// Naming convention model [UnitOfWork]_[Scenario]_[ExpectedBehavior]
		public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
		{
			LogAnalyzer analyzer = MakeAnalyzer();

			bool result = analyzer.IsValidLogFileName(file);

			Assert.True(result);
		}

		[Test]
		public void IsValidFileName_EmptyFileName_ThrowsException()
		{
			LogAnalyzer la = MakeAnalyzer();

			var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(""));

			StringAssert.Contains("filename has to be provided", ex.Message);
		}

		[Test]
		[Ignore("there is a problem with this test")]
		public void IsValidFileName_ValidFile_ReturnsTrue()
		{
			///
		}

		[Test]
		public void IsValidFileName_EmptyFileName_ThrowsFluent()
		{
			LogAnalyzer la = MakeAnalyzer();

			var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(""));

			Assert.That(ex.Message, Is.StringContaining("filename has to be provided"));
		}

		[Test]
		[Category("Fast Tests")]
		public void IsValidFileName_ValidFile_FastTest()
		{

		}

		// State based test
		[TestCase("badfile.foo", false)]
		[TestCase("goodfile.slf", true)]
		public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
		{
			LogAnalyzer la = MakeAnalyzer();

			la.IsValidLogFileName(file);

			Assert.AreEqual(expected, la.WasLastFileNameValid);
		}
    }
}
