using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.CH5.LogAn;

namespace LogAn.UnitTests
{
	public class FakeWebService_CH5 : IWebService_CH5
	{
		public string MessageToWebService;
		public void Write(string message)
		{
			MessageToWebService = message;
		}
	}
}
