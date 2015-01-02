using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIM.UnitTests;
using NSubstitute;
using NUnit.Framework;
using NBehave.Spec.NUnit;
using Wrox.BooksRead.Web;
using Rhino.Mocks;

namespace Wrox.BooksRead.Tests
{
    public class when_using_the_Books_read_controller : Specifications
    {

    }

	public class and_getting_a_list_of_books : when_using_the_Books_read_controller
	{

	}

	public class and_when_calling_getdata_bind_should_be_called : and_getting_a_list_of_books
	{
		IDisplayBooksReadView _view;
		DisplayBooksReadController _controller;

		protected override void Establish_context()
		{
			base.Establish_context();

			_view = Substitute.For<IDisplayBooksReadView>();
			_controller = new DisplayBooksReadController(_view);
		}

		protected override void Because_of()
		{
			_controller.GetData(this, EventArgs.Empty);
		}

		[Test]
		public void Call_BindBook_GetListOfBooks()
		{
			Assert.AreEqual(_view.Data, _controller.View.Data);
		}
	}

	public class and_wiring_the_events_by_the_constructor: and_getting_a_list_of_books
	{
		IDisplayBooksReadView _view;

		protected override void Establish_context()
		{
			base.Establish_context();

			_view = MockRepository.GenerateMock<IDisplayBooksReadView>();
			_view.Expect(v => v.DataRequested += null).IgnoreArguments();
		}

		protected override void Because_of()
		{
			new DisplayBooksReadController(_view);
		}
		
		[Test]
		public void Constructor_ViewCreation_WireUpEvents()
		{
			_view.VerifyAllExpectations();
		}
	}
}
