using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wrox.BooksRead.Web
{
	public partial class _Default : System.Web.UI.Page, IDisplayBooksReadView
	{
		private DisplayBooksReadController controller;
		public event EventHandler DataRequested;
		public List<BookRead> Data { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			controller = new DisplayBooksReadController(this);
			DataRequested(sender, e);
		}

		public void Bind()
		{
			rptBooksRead.DataSource = Data;
			rptBooksRead.DataBind();
		}
	}
}