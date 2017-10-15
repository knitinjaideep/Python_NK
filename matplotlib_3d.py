# -*- coding: utf-8 -*-
"""
Created on Thu Sep 28 06:54:51 2017

@author: nitin.kotcherlakota
"""

#matplotlib 3d

import mpl_toolkits.mplot3d import axes3d
import matplotlib.pyplot as plt

fig = plt.figure()
ax1 = fig.add_subplot(111,projection = '3d')
x = [1,2,3,4,5]
y = [5,6,7,8,9]
z = [3,5,7,9,1]
ax1.plot_wireframe(x,y,z)