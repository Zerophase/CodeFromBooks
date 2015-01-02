from TestCaseTest import TestCaseTest
from TestSuite import TestSuite
from TestResult import TestResult

if __name__ == "__main__":
    suite = TestSuite()
    suite.add(TestCaseTest("testTemplateMethod"))
    suite.add(TestCaseTest("testResult"))
    suite.add(TestCaseTest("testFailedResultFormatting"))
    suite.add(TestCaseTest("testFailedResult"))
    suite.add(TestCaseTest("testSuite"))
    suite.add(TestCaseTest("testFailedSetUp"))
    suite.add(TestCaseTest("testSetUp"))
    result = TestResult()
    suite.run(result)
    print (result.summary())
