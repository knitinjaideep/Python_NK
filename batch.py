# -*- coding: utf-8 -*-
"""
Created on Thu Jun 08 10:17:00 2017

@author: nitin.kotcherlakota
"""
#import os
#fopen = os.system('"C:/Users/nitin.kotcherlakota/Desktop/UITaxWageFileGenerator.exe"')

f = open('C:/Users/nitin.kotcherlakota/Desktop/UITaxWageFileGenerator.exe','r+b')

for i in enumerate(f):
    print bin(ord(i))
    