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
	public class ConfigurationManagerTests_Refactored : BaseTestsClass
	{
		[Test]
		public void Analyze_EmptyFile_ThrowException()
		{
			FakeTheLogger();

			ConfigurationManager cm = new ConfigurationManager();
			bool configured = cm.IsConfigured("something");
		}
	}
}
