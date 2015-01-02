using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalTDDWithCSharp.Ninject.Interfaces;

namespace ProfessionalTDDWithCSharp.Ninject
{
	internal class LoggingComponent :ILoggingComponent
	{
		public LoggingComponent(ILoggingDataSink loggingDataSink)
		{

		}
	}
}
