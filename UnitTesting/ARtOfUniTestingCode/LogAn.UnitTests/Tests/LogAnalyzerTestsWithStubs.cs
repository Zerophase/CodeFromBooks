using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AOUT.LogAn;

namespace LogAn.UnitTests
{
	[TestFixture]
	public class LogAnalyzerTestsWithStubs
	{
		[Test]
		public void IsValidFileName_NameSupportedExtension_ReturnTrue()
		{
			FakeExtensionManager myFakeExtensionManager = 
				new FakeExtensionManager();
			myFakeExtensionManager.WillBeValid = true;

			ConstructorInjectionLogAnalyzer log = 
				new ConstructorInjectionLogAnalyzer(myFakeExtensionManager);

			bool result = log.IsValidLogFileName("short.ext");
			Assert.True(result);
		}

		[Test]
		public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
		{
			bool result;
			try
			{
				FakeExtensionManager myFakeManager =
					new FakeExtensionManager();
				myFakeManager.WillThrow = new Exception("this is fake");

				ConstructorInjectionLogAnalyzer log =
					new ConstructorInjectionLogAnalyzer(myFakeManager);
				result = log.IsValidLogFileName("anything.anyextension");
			}
			catch (Exception)
			{
				result = false;
			}
			
			Assert.False(result);
		}

		[Test]
		public void IsValidFileName_SupportedExtension_ReturnsTrue()
		{
			// set up the stub to use, make sure it returns true

			FakeExtensionManager myFakeManager =
				new FakeExtensionManager();
			myFakeManager.WillBeValid = true;

			PropertyLogAnalyzer log = new PropertyLogAnalyzer();
			log.ExtensionManager = myFakeManager;

			bool result = log.IsValidLogFileName("anyfilename.anyExtension");
			Assert.True(result);
		}

		[Test]
		public void IsValidFileName_SupportedExtensionFactoryMethod_ReturnsTrue()
		{
			FakeExtensionManager myFakeManager =
				new FakeExtensionManager();
			myFakeManager.WillBeValid = true;

			ExtensionManagerFactory.SetManager(myFakeManager);
			FactoryPatternLogAnalyzer log =
				new FactoryPatternLogAnalyzer();
			bool result = log.IsValidLogFilename("anyfilename.htmlc");

			Assert.True(result);
		}

		// Known as Extract and Override
		[Test]
		public void IsValidFileName_OverrideTest_ReturnsTrue()
		{
			FakeExtensionManager stub = new FakeExtensionManager();
			stub.WillBeValid = true;

			TestableLogAnalyzer logan =
				new TestableLogAnalyzer(stub);

			bool result = logan.IsValidLogFileName("file.ext");

			Assert.True(result);
		}

		[Test]
		public void IsValidFileName_OverridTestWithoutStub_ReturnsTrue()
		{
			VirtualCalculationTestableLogAnalyzer logan =
				new VirtualCalculationTestableLogAnalyzer();
			logan.IsSupported = true;

			bool result = logan.IsValidLogFileName("file.ext");

			Assert.True(result);
		}

		[Test]
		public void IsValidFileName_UsingInternalKeyword_ReturnsTrue()
		{
			FakeExtensionManager stub = new FakeExtensionManager();
			stub.WillBeValid = true;

			Internal_ProtectingObjectOrientedDesignLogAnalyzer logan =
				new Internal_ProtectingObjectOrientedDesignLogAnalyzer(stub);

			bool result = logan.IsValidLogFileName("file.ext");

			Assert.True(result);
		}

		// Only runs test on Debug build
		[Test]
		public void IsValidFileName_UsingConditionalDebug_ReturnsFalse()
		{
			FakeExtensionManager stub = new FakeExtensionManager();
			stub.WillBeValid = false;

			ConditionalDebug_ProtectingObjectOrientedDesignLogAnalyzer logan =
				new ConditionalDebug_ProtectingObjectOrientedDesignLogAnalyzer();
			logan.ExtensionManager(stub);

			bool result = logan.IsValidLogFileName("file.slf");

			Assert.False(result);
		}

		// Only runs test on Debug build
#if DEBUG
		[Test]
		public void IsValidFileName_PreProccessorDirective_ReturnsFalse()
		{
			FakeExtensionManager stub = new FakeExtensionManager();
			stub.WillBeValid = false;

			PreProccessorDirective_ProtectingObjectOrientedDesignLogAnalyzer logan =
				new PreProccessorDirective_ProtectingObjectOrientedDesignLogAnalyzer(stub);

			bool result = logan.IsValidLogFileName("file.ext");

			Assert.False(result);
		}
#endif
		// Another way to do this is have each test set the manager
		[TearDown]
		public void TearDown()
		{
			ExtensionManagerFactory.SetManager(null);
		}
	}
}
