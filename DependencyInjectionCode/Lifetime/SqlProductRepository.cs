using System;

namespace Lifetime
{
	public class SqlProductRepository : ProductRepository
	{
		private readonly string connString;

		public SqlProductRepository(string connString)
		{
			if (connString == null)
			{
				throw new ArgumentNullException("connString");
			}

			this.connString = connString;
		}

		public string ConnectionString
		{
			get { return this.connString; }
		}
	}
}