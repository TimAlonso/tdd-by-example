import unittest
from TestCase import TestCase
from WasRun import WasRun

class test_TestCase(unittest.TestCase):
    def testRunning(self):
        test = WasRun("testMethod")
        self.assertEqual(test.wasRun, None)
        test.run()
        self.assertEqual(test.wasRun, 1)
    
    def testSetUp(self):
        test = WasRun("testMethod")
        test.run()
        self.assertEqual(test.wasSetUp, 1)