using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalTDDWithCSharp.Ninject.Interfaces;
using Ninject;

namespace ProfessionalTDDWithCSharp.Ninject
{
	public class BussinessService
	{
		private ILoggingComponent _loggingComponent;
		private IWebServiceProxy _webServiceProxy;
		private IDataAccessComponent _dataAccessComponent;

		public BussinessService(ILoggingComponent loggingComponent, IWebServiceProxy webServiceProxy, IDataAccessComponent dataAccessComponent)
		{
			_loggingComponent = loggingComponent;
			_webServiceProxy = webServiceProxy;
			_dataAccessComponent = dataAccessComponent;
		}
	}
}

