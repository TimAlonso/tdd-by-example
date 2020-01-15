import unittest
from TestCase import TestCase
from WasRun import WasRun

class test_TestCase(unittest.TestCase):
    def setUp(self):
        self.test = WasRun("testMethod")

    def testRunning(self):
        self.test.run()
        self.assertEqual(self.test.wasRun, 1)
    
    def testSetUp(self):
        self.test.run()
        self.assertEqual(self.test.wasSetUp, 1)