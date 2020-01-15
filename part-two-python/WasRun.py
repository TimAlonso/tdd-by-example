from TestCase import TestCase

class WasRun(TestCase):
    def __init__(self, name):
        TestCase.__init__(self, name)
    
    def setUp(self):
        self.wasRun = None
        self.wasSetUp = 1