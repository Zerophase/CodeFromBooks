using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOUT.CH11
{
	public class TestableSingletonHolder
	{
		private static TestableSingletonLogic instance;
		public static TestableSingletonLogic Instance
		{
			get
			{
				return Instance ?? (instance = new TestableSingletonLogic());
			}
		}
	}
}
