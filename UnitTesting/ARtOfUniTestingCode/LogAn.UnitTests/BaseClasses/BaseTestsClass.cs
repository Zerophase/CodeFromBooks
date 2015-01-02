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
	public class BaseTestsClass
	{
		public ILogger FakeTheLogger()
		{
			LoggingFacility.Logger = Substitute.For<ILogger>();
			return LoggingFacility.Logger;
		}

		[TearDown]
		public void TearDown()
		{
			LoggingFacility.Logger = null;
		}
	}
}
