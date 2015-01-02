using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject.Activation;
using ProfessionalTDDWithCSharp.Ninject.Interfaces;

namespace ProfessionalTDDWithCSharp.Ninject
{
	public class CoreModule : NinjectModule
	{
		public override void Load()
		{
			Bind<BussinessService>().ToSelf();
			Bind<ILoggingDataSink>().To<LoggingDataSink>();
			Bind<ILoggingComponent>().To<LoggingComponent>();
			Bind<IDataAccessComponent>().ToProvider(new DataAccessComponentProvider());
			Bind<IWebServiceProxy>().ToProvider(new WebServiceProxyComponentProvider());

			Bind<IPersonRepository>().To<PersonRepository>();
			Bind<IPersonService>().To<PersonService>();
		}
	}

	public class WebServiceProxyComponentProvider : Provider<IWebServiceProxy>
	{
		protected override IWebServiceProxy CreateInstance(IContext context)
		{
			var webServiceAddress = ConfigurationManager.AppSettings["MyWebSAerviceAddress"];
			return new WebServiceProxy(webServiceAddress);
		}
	}

	public class DataAccessComponentProvider : Provider<IDataAccessComponent>
	{
		protected override IDataAccessComponent CreateInstance(IContext context)
		{
			var databaseConnectionString =
				ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
			return new DataAccessComponent(databaseConnectionString);
		}
	}

}
