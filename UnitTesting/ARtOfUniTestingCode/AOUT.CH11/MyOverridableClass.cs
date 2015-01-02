using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.CH11
{
    public class MyOverridableClass
    {
		public Func<int, int> CalculateMethod = delegate(int i)
		{
			return i * 2;
		};

		public void DoSomeAction(int input)
		{
			int result = CalculateMethod(input);
			if (result == -1)
			{
				throw new Exception("input was invalid");
			}
			// do some other work
		}
    }
}
