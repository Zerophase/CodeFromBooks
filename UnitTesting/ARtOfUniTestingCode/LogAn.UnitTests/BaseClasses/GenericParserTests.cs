using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using AOUT.CH7.LogAn;

namespace LogAn.UnitTests
{
	// Generic Test class
	public abstract class GenericParserTests<T>
		where T : IStringParser
	{
		protected abstract string GetInputHeaderSingleDigit();

		// creates and returns intance of class inheriti3456ng from IStringParser
		protected T GetParser(string input)
		{
			return (T)Activator.CreateInstance(typeof(T), input);
		}

		[Test]
		public void GetStringVersionFromHeader_SingleDigit_Found()
		{
			string input = GetInputHeaderSingleDigit();
			T parser = GetParser(input);

			bool result = parser.HasCorrectHeader();
			Assert.IsFalse(result);
		}

		// additional tests
	}
}
