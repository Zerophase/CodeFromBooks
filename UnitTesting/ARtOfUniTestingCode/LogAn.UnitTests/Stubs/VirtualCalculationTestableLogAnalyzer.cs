using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.LogAn;

namespace LogAn.UnitTests
{
	public class VirtualCalculationTestableLogAnalyzer 
		: VirtualCalculationExtractAndOverride
	{
		public bool IsSupported;

		protected override bool IsValid(string fileName)
		{
			return IsSupported;
		}
	}
}
