# -*- coding: utf-8 -*-
"""
Created on Sun Sep 24 11:13:54 2017

@author: nitin.kotcherlakota
"""

#matplotlib_pie
import matplotlib.pyplot as plt
labels = ['Taxes','Overhead','Entertainment']
size = [33,44,32]
plt.pie(size,labels = labels,startangle = 90,autopct = '%1.1f%%')
plt.axis('equal')