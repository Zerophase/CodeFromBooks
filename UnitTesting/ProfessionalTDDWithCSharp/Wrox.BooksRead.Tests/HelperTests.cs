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

namespace Wrox.BooksRead.Tests
{
	public class when_using_the_html_helper_to_truncate_test : Specifications
	{
		protected string _textToTruncate;
		protected string _expected;
		protected string _actual;
		protected int _numberToTruncate;

		protected override void Because_of()
		{
			_actual = HTMLHelper.Truncate(_textToTruncate, _numberToTruncate);
		}
	}

	public class and_passing_a_string_that_needs_to_be_truncated :
		when_using_the_html_helper_to_truncate_test
	{
		protected override void Establish_context()
		{
			_textToTruncate = "This is my test";
			_expected = "This ...";
			_numberToTruncate = 5;
		}

		[Test]
		public void TruncateWithElippses_WhenTruncateCalled_ModifyString()
		{
			_expected.ShouldEqual(_actual);
		}
	}

	public class and_passing_a_string_that_needs_not_be_truncated :
		when_using_the_html_helper_to_truncate_test
	{
		protected override void Establish_context()
		{
			_textToTruncate = "This is my text";
			_expected = "This is my text";
			_numberToTruncate = 0;
		}

		public void DonotTruncate_Truncate_LeaveStringAs()
		{
			_expected.ShouldEqual(_actual);
		}
	}

	public class and_passing_a_string_that_is_less_than_what_needs_truncated :
		when_using_the_html_helper_to_truncate_test
	{
		protected override void Establish_context()
		{
			_textToTruncate = "This is my text";
			_expected = "This is my text";
			_numberToTruncate = 50;
		}

		[Test]
		public void StringShorterThanTruncateLength_Truncate_LeaveStringAs()
		{
			_expected.ShouldEqual(_actual);
		}
	}

	public class and_pass_a_null_value : when_using_the_html_helper_to_truncate_test
	{
		protected override void Establish_context()
		{
			_textToTruncate = null;
			_expected = string.Empty;
			_numberToTruncate = 50;
		}

		[Test]
		public void NullString_Truncate_ReturnEmptyString()
		{
			_expected.ShouldEqual(_expected);
		}
	}
}
