# -*- coding: utf-8 -*-
"""
Created on Sat Sep 23 10:38:47 2017

@author: nitin.kotcherlakota
"""

class test:
    def __init__(self):
        self.a = raw_input("enter a value")
        self.b = 'hi'
    def meth(self):
        a_new = raw_input("enter a new value")
        print a_new
        self.a = a_new
    def sum(self,a,b):
        print a+b
obj = test()
obj1 = test()
