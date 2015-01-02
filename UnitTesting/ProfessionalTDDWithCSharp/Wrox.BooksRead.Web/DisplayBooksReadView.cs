using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wrox.BooksRead.Web
{
	public interface IDisplayBooksReadView
	{
		event EventHandler DataRequested;
		List<BookRead> Data { get; set; }
		void Bind();
	}

	public class DisplayBooksReadView
	{
	}
}