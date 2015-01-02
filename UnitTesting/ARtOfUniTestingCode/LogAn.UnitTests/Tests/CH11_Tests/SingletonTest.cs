using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AOUT.CH11;
using NSubstitute;

namespace LogAn.UnitTests.CH11_Tests
{
	[TestFixture]
	public class SingletonTest
	{
		[Test]
		public void FOO_DoesSomeCalculations_ReturnsTrue()
		{
			TestableSingletonLogic logic = new TestableSingletonLogic();

			bool result = logic.Foo(-1);

			Assert.IsTrue(result);
		}
	}
}
