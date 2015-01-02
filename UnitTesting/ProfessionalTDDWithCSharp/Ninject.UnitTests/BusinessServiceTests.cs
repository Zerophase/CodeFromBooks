using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProfessionalTDDWithCSharp.Ninject;
using ProfessionalTDDWithCSharp.Ninject.Interfaces;
using Ninject;

namespace Ninject.UnitTests
{
	[TestFixture]
	public class BusinessServiceTests
	{
		[Test]
		public void IsNotNull_BussinessService_ReturnsValue()
		{
			BussinessService actual;
			var kernel = new StandardKernel(new CoreModule());
			actual = kernel.Get<BussinessService>();

			Assert.IsNotNull(actual);
		}
	}
}
