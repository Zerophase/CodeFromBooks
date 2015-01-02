using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOUT.CH5.LogAn;
using NUnit.Framework;
using NSubstitute;

namespace LogAn.UnitTests
{
	[TestFixture]
	public class TestsWithIsolationFrameworks
	{
		[Test]
		public void Analyze_TooShortFileName_CallLogger()
		{
			ILogger logger = Substitute.For<ILogger>();
			LogAnalyzer_ILogger analyzer = new LogAnalyzer_ILogger(logger);

			analyzer.MinNameLength = 6;
			analyzer.Analyze("a.txt");

			logger.Received().LogError("Filename too short: a.txt");
		}

		// Forces method call to return a fake value
		[Test]
		public void Returns_byDefault_WorksForHardCodedArgument()
		{
			IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

			fakeRules.IsValidLogFileName("strict.txt").Returns(true);

			Assert.IsTrue(fakeRules.IsValidLogFileName("strict.txt"));
		}

		[Test]
		public void Returns_MyDefault_WorksForHardCodeArguement2()
		{
			IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

			fakeRules.IsValidLogFileName(Arg.Any<String>())
				.Returns(true);

			Assert.IsTrue(fakeRules.IsValidLogFileName("anything.txt"));
		}

		// How to simulate an exception
		[Test]
		public void Returns_ArgAny_Throws()
		{
			IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

			fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>())) // x signifies fake object behaviour is changed on
				.Do(context => // context is callinfo property from NSub holding argument values at runtime.
							  // allows cool things to be done in more advanced scenarios
					{ throw new Exception("fake exception"); });

			Assert.Throws<Exception>(() =>
				fakeRules.IsValidLogFileName("anything"));
		}

		[Test]
		public void Analyze_LoggerThrows_CallsWebService()
		{
			FakeWebService_CH5 mockWebService = new FakeWebService_CH5();

			FakeLogger2 stubLogger = new FakeLogger2();
			stubLogger.WillThrow = new Exception("fake exception");

			var analyzer2 = new LogAnalyzer2_IMulti(stubLogger, mockWebService);
			analyzer2.MinNameLength = 8;

			string tooShortFileName = "abc.ext";
			analyzer2.Analyze(tooShortFileName);
			
			Assert.That(mockWebService.MessageToWebService,
				Is.StringContaining("fake exception"));
		}

		[Test]
		public void Analyze_LoggerThrows_IsolationFramework_CallsWebService()
		{
			var mockWebService = Substitute.For<IWebService_CH5>();
			var stubLogger = Substitute.For<ILogger>();

			stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
				.Do(info =>{ throw new Exception("fake exception");});

			var analyzer = new LogAnalyzer2_IMulti(stubLogger, mockWebService);

			analyzer.MinNameLength = 10;
			analyzer.Analyze("Short.txt");

			mockWebService.Received()
				.Write(Arg.Is<string>(s => s.Contains("fake exception")));
		}

		[Test]
		public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject()
		{
			var mockWebService = Substitute.For<IWebService_ErrorInfo>();
			var stubLogger = Substitute.For<ILogger>();
			stubLogger.When(
				logger => logger.LogError(Arg.Any<string>()))
				.Do(info => { throw new Exception("fake exception"); });

			var analyzer =
				new LogAnalyzer3(stubLogger, mockWebService);

			analyzer.MinNameLength = 10;
			analyzer.Analyze("Short.txt");

			mockWebService.Received()
				.Write(Arg.Is<ErrorInfo>(info => info.Severity == 1000 &&
				info.Message.Contains("fake exception")));
		}

		[Test]
		public void Analyze_LoggerThrows_CallsWebServiceWithNSubObjectCompare()
		{
			var mockWeService = Substitute.For<IWebService_ErrorInfo>();
			var stubLogger = Substitute.For<ILogger>();
			stubLogger.When(
				logger => logger.LogError(Arg.Any<string>()))
				.Do(info => { throw new Exception("fake exception"); });

			var analyzer = new LogAnalyzer3(stubLogger, mockWeService);

			analyzer.MinNameLength = 10;
			analyzer.Analyze("Short.txt");

			var expected = new ErrorInfo(1000, "fake exception");
			mockWeService.Received().Write(expected);
		}

		// How to write Event related code. In application of this see if eventhandler can be used in place of Action
		[Test]
		public void ctor_WhenViewIsLoaded_CallsViewRender()
		{
			var mockView = Substitute.For<IView_CH5>();

			Presenter_CH5 p = new Presenter_CH5(mockView);
			mockView.Loaded += Raise.Event<Action>();

			mockView.Received()
				.Render(Arg.Is<string>(s => s.Contains("Hello World")));
		}

		// Testing the listener for response from the event
		[Test]
		public void ctor_WhenViewHasError_CallsLogger()
		{
			var stubView = Substitute.For<IView_CH5>();
			var mockLogger = Substitute.For<ILogger>();

			Presenter_CH5 p = new Presenter_CH5(stubView, mockLogger);
			stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");

			mockLogger.Received()
				.LogError(Arg.Is<string>(s => s.Contains("fake error")));
		}

		// Believe this is correct
		[Test]
		public void DelegateFires_OnMethodCall_EventFiringManual()
		{
			bool loadFired = false;
			SomeView_CH5 view = new SomeView_CH5();
			view.Load += delegate
			{
				loadFired = true;
			};

			view.DoSomethinThatEventuallyFiresThisEvent();

			Assert.IsTrue(loadFired);
		}
	}
}
