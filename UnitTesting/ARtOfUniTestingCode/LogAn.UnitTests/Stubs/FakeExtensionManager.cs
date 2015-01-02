using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.LogAn;

namespace LogAn.UnitTests
{
	class FakeExtensionManager : IExtensionManager
	{
		public bool WillBeValid = false;
		public Exception WillThrow = null;

		public bool IsValid(string filename)
		{
			if (WillThrow != null)
				throw WillThrow;

			return WillBeValid;
		}
	}
}
