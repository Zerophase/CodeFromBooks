from TestCase import TestCase
from WasRun import WasRun
from TestResult import TestResult
from TestSuite import TestSuite 

class TestCaseTest(TestCase):
    def setUp(self):
        self.result = TestResult()

    def testFailedSetUp(self):
        test = WasRun("testBrokenMethod")

        test.run(self.result)

        assert("1 run, 1 failed" == result.summary())

    def testSetUp(self):
        test = WasRun("testMethod")

        test.run(self.result)

        assert("setUp testMethod " == test.log)

    def testFailedResultFormatting(self):
        self.result.testStarted()
        self.result.testFailed()

        assert("1 run, 1 failed" == result.summary())
    def testFailedResult(self):
        test = WasRun("testBrokenMethod")
        
        test.run(self.result)

        assert("1 run, 1 failed", result.summary())

    def testResult(self):
        test = WasRun("testMethod")

        test.run(self.result)

        assert("1 run, 0 failed" == result.summary())

    def testTemplateMethod(self):
        test = WasRun("testMethod")
        
        test.run(self.result)

        assert("setUp testMethod tearDown " == test.log)

    def testSuite(self):
        suite = TestSuite()
        suite.add(WasRun("testMethod"))
        suite.add(WasRun("testBrokenMethod"))

        suite.run(self.result)

        assert("2 run, 1 failed" == result.summary())