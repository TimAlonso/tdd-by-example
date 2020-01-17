class TestCase:
    def __init__(self, name):
        self.name = name

    def setUp(self):
        pass

    def run(self, result):
        result.testStarted()
        try:
            self.setUp()
        except:
            result.setUpFailed()
        try:
            method = getattr(self, self.name)
            method()
        except:
            result.testFailed()
        self.tearDown()

    def tearDown(self):
        pass


class WasRun(TestCase):
    def __init__(self, name):
        TestCase.__init__(self, name)

    def setUp(self):
        self.log = "setUp "

    def testMethod(self):
        self.log = self.log + "testMethod "

    def testBrokenMethod(self):
        self.log = self.log + "testBrokenMethod "
        raise Exception

    def tearDown(self):
        self.log = self.log + "tearDown "


class WasSetUp(WasRun):
    def __init__(self, name):
        WasRun.__init__(self, name)

    def setUp(self):
        raise Exception


class TestResult:
    def __init__(self):
        self.setUpErrorCount = 0
        self.runCount = 0
        self.errorCount = 0

    def summary(self):
        if (self.setUpErrorCount > 0):
            return "setUp error"
        else:
            return "%d run, %d failed" % (self.runCount, self.errorCount)

    def setUpFailed(self):
        self.setUpErrorCount = self.setUpErrorCount + 1

    def testStarted(self):
        self.runCount = self.runCount + 1

    def testFailed(self):
        self.errorCount = self.errorCount + 1


class TestSuite:
    def __init__(self):
        self.tests = []

    def add(self, test):
        self.tests.append(test)

    def run(self, result):
        for test in self.tests:
            test.run(result)


class TestCaseTest(TestCase):
    def setUp(self):
        self.result = TestResult()

    def testFailedSetUp(self):
        self.result.setUpFailed()
        assert("setUp error" == self.result.summary())

    def testTemplateMethod(self):
        test = WasRun("testMethod")
        test.run(self.result)
        assert("setUp testMethod tearDown " == test.log)

    def testResult(self):
        test = WasRun("testMethod")
        test.run(self.result)
        assert("1 run, 0 failed" == self.result.summary())

    def testFailedResult(self):
        test = WasRun("testBrokenMethod")
        test.run(self.result)
        assert("1 run, 1 failed" == self.result.summary())

    def testTearDown(self):
        test = WasRun("testBrokenMethod")
        test.run(self.result)
        assert("setUp testBrokenMethod tearDown " == test.log)

    def testFailedResultFormatting(self):
        self.result.testStarted()
        self.result.testFailed()
        assert("1 run, 1 failed" == self.result.summary())

    def testSuite(self):
        suite = TestSuite()
        suite.add(WasRun("testMethod"))
        suite.add(WasRun("testBrokenMethod"))
        suite.run(self.result)
        assert("2 run, 1 failed" == self.result.summary())


suite = TestSuite()
suite.add(TestCaseTest("testTemplateMethod"))
suite.add(TestCaseTest("testResult"))
suite.add(TestCaseTest("testFailedResult"))
suite.add(TestCaseTest("testFailedResultFormatting"))
suite.add(TestCaseTest("testSuite"))
suite.add(TestCaseTest("testFailedSetUp"))
suite.add(TestCaseTest("testTearDown"))
result = TestResult()
suite.run(result)
print(result.summary())
