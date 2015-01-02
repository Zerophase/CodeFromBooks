using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.LogAn;

namespace LogAn.UnitTests
{
	public class AlwaysValidFakeExtensionManager : IExtensionManager
	{
		public bool IsValid(string filename)
		{
			return true;
		}
	}
}
