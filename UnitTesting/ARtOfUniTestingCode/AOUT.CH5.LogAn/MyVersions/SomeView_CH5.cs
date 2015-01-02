using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.CH5.LogAn
{
	public class SomeView_CH5
	{
		public delegate void Handler(bool test);
		public event Handler Load;

		public void DoSomethinThatEventuallyFiresThisEvent()
		{
			// Version in test fires this does not.
			// Just used a hacky solution to get the test version to fire.
			Load.Invoke(false);
		}
	}
}
