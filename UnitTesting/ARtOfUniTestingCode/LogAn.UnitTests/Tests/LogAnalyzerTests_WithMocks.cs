using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AOUT.CH4.LogAn;

namespace LogAn.UnitTests
{
	[TestFixture]
	public class LogAnalyzerTests_WithMocks
	{
		[Test]
		public void Analyze_TooShortFileName_CallWebService()
		{
			FakeWebService mockService = new FakeWebService();
			LogAnalyzer log = new LogAnalyzer(mockService);
			string tooShortFileName = "abc.ext";

			log.Analyze(tooShortFileName);

			StringAssert.Contains("Filename too short:abc.ext",
				mockService.LastError);
		}

		[Test]
		public void Analyze_WebServiceThrow_SendsEmail()
		{
			FakeWebService stubService = new FakeWebService();
			stubService.ToThrow = new Exception("fake exception");

			FakeEmailService mockEmail = new FakeEmailService();

			LogAnalyzer2_FromBook log = new LogAnalyzer2_FromBook(stubService, mockEmail);

			string tooShortFileName = "abc.ext";
			log.Analyze(tooShortFileName);

			StringAssert.Contains("someone@somewhere.com", mockEmail.To);
			StringAssert.Contains("fake exception", mockEmail.Body);
			StringAssert.Contains("can't log", mockEmail.Subject);
		}

		// How to run previous test with one Assert
		[Test]
		public void Analyze_WebServiceThrow_EmailInfo_SendsEmail()
		{
			FakeWebService stubService = new FakeWebService();
			stubService.ToThrow = new Exception("fake exception");

			FakeEmailService_WithProperties mockEmail =
				new FakeEmailService_WithProperties();

			LogAnalyzer2_FromBook_2dExample log =
				new LogAnalyzer2_FromBook_2dExample(stubService, mockEmail);

			string tooShortFileName = "abc.ext";
			log.Analyze(tooShortFileName);

			EmailInfo expectedEmail = new EmailInfo
			{
				Body = "fake exception",
				To = "someone@somewhere.com",
				Subject = "can't log"
			};

			Assert.AreEqual(expectedEmail, mockEmail.email);
		}
	}
}
