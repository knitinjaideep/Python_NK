# -*- coding: utf-8 -*-
"""
Created on Sun Sep 24 10:28:03 2017

@author: nitin.kotcherlakota
"""

#matplotlib_histograms
import matplotlib.pyplot as plt

test_scores = [45,50,55,60,54,70,86,90,91,73,88,76,90,98,64,100]
x = [x for x in range(len(test_scores))]

bins = [10,20,30,40,50,60,70,80,90,100]
plt.hist(test_scores,bins,histtype = 'bar', rwidth = 0.8)
plt.show()