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
	public class ConfigurationManagerTests
	{
		[Test]
		public void Analyze_EmptyFile_ThrowsException()
		{
			LoggingFacility.Logger = Substitute.For<ILogger>();
			ConfigurationManager cm = new ConfigurationManager();
			bool configured = cm.IsConfigured("something");
			// rest of test
		}

		[TearDown]
		public void TearDown()
		{
			// need to reset static attributes before next test
			LoggingFacility.Logger = null;
		}
	}
}
