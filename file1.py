# -*- coding: utf-8 -*-
"""
Created on Wed May 17 11:07:24 2017

@author: nitin.kotcherlakota
"""
f1_o = open('D:/file1.txt','r')
f1 = f1_o.read().split()
f2_o = open('D:/datatablelist.txt','r')
f2 = f2_o.read().split()
l1 = list()
l2 = list()

for i in f1:
    l1.append(i)

for j in f2:
    l2.append(j)

f1_output = open('D:/file1_output.txt', 'w')
f2_output = open('D:/file2_output.txt', 'w')

for item in set([x for x in l2 if x not in l1]):
    f1_output.write("%s"%item+"\n")
print "\n"
for items in set([y for y in l1 if y not in l2]):
    f2_output.write("%s"%items+"\n")
