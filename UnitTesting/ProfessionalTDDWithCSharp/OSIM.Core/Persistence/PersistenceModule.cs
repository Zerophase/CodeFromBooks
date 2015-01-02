using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject.Activation;
using Ninject.Modules;
using OSIM.Core.Persistence;
using OSIM.Core.Persistence.Mappings;
using OSIM.Core.Entities;
using System.Configuration;

namespace OSIM.Core.Persistence
{
	public class PersistenceModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IItemTypeRepository>().To<ItemTypeRepository>();
			Bind<ISessionFactory>().ToProvider(new SessionFactoryProvider());
		}
	}

	public class SessionFactoryProvider : Provider<ISessionFactory>
	{
		protected override ISessionFactory CreateInstance(IContext context)
		{
			var sessionFactory = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2008
							  .ConnectionString(c => c.Is(ConfigurationManager.AppSettings["localDb"]))
							  .ShowSql())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ItemType>()
								   .ExportTo(@"C:\Temp"))
				.BuildSessionFactory();

			return sessionFactory;

			//.ExposeConfiguration(BuildSchema)
		}
	}
}
