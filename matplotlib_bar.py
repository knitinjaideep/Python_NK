# -*- coding: utf-8 -*-
"""
Created on Sun Sep 24 09:46:43 2017

@author: nitin.kotcherlakota
"""

#matplotlib bar graphs
import matplotlib.pyplot as plt

x = [2,4,6,8,10]
x1 = [1,3,5,7,9]
y = [4,2,4,5,2]
y1 = [5,6,7,8,1]

plt.bar(x,y,label = 'one')
plt.bar(x1,y1,label = 'two')
plt.legend()
plt.xlabel('Bar Number')
plt.ylabel('Bar Height')
#to bring the graph up with plt.show, script will pause at this point
plt.show()

