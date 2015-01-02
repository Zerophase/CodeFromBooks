using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
	public class DefaultTimeProvider : TimeProvider
	{
		public override DateTime UtcNow
		{
			get { return DateTime.UtcNow; }
		}
	}
}
