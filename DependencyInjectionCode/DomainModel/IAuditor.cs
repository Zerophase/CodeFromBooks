using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel
{
	public interface IAuditor
	{
		void Record(AuditEvent @event);
	}
}
