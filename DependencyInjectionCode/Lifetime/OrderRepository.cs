using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifetime
{
    public class OrderRepository : IDisposable
    {
	    public virtual void Dispose()
	    {
		    this.Dispose(true);
			GC.SuppressFinalize(this);
	    }

	    protected virtual void Dispose(bool disposing)
	    {
		    
	    }
    }
}
