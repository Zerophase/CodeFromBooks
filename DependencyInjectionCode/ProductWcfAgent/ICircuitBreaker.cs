using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductWcfAgent
{
	public interface ICircuitBreaker
	{
		void Guard();
		void Trip(Exception e);
		void Succeed();
	}
}
