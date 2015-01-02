using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductWcfAgent
{
	public interface ICircuitState
	{
		void Guard();
		ICircuitState NextState();
		void Succeed();
		void Trip(Exception e);
	}
}
