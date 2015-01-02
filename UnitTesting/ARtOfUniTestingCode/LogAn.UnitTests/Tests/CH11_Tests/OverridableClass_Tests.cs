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
	public class OverridableClass_Tests
	{
		// after this test runs the NUnit expects an exception.
		// No need for asserting on the exception
		[Test]
		[ExpectedException(typeof(Exception))]
		public void DoSomething_GivenInvalidInput_ThrowsException()
		{
			MyOverridableClass myOverridableClass = 
				new MyOverridableClass();
			int SOME_NUMBER = 1;
			
			// stub like calculation method to return invalid;
			myOverridableClass.CalculateMethod = delegate(int i) { return -1; };

			myOverridableClass.DoSomeAction(SOME_NUMBER);
		}
	}
}
