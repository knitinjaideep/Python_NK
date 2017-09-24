# -*- coding: utf-8 -*-
"""
Created on Sun Sep 24 08:44:36 2017

@author: nitin.kotcherlakota
"""

#matplotlib
import matplotlib.pyplot as plt

x = [1,2,3,4,5]
y = [4,5,6,7,8]
y1 = [5,6,7,8,1]
#use to create a graph in the background
plt.plot(x,y,label = 'Initial Line')
plt.plot(x,y1,label = 'New line')
plt.legend()
plt.xlabel('X axis plot number')
plt.ylabel('Y axis plot number')
plt.title('Basic graph')
#to bring the graph up with plt.show, script will pause at this point
plt.show()

