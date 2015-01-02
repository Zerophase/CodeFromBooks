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
	public class CH7_Tests
	{
		// Avoid many many interfaces in app.  Use this when possible for classes that
		// handle controller input?
		[Test]
		public void SettingSystemTime_Always_ChangesTime()
		{
			SystemTime.Set(new DateTime(2000, 1, 1));

			string output = TimeLogger.CreateMessage("a");

			StringAssert.Contains("1/1/2000", output);
		}

		[TearDown]
		public void AfterEachTest()
		{
			SystemTime.Reset();
		}
	}
}
