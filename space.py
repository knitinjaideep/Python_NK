# -*- coding: utf-8 -*-
"""
Created on Wed Jun 14 15:08:39 2017

@author: nitin.kotcherlakota
"""

f = open("D:/pyt/pyt data/space.txt","r")
f_o = f.read()
for i in f_o:
    l = i.find(([0-9])(\[a-z\]))
    print replace(l," ")
    