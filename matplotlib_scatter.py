# -*- coding: utf-8 -*-
"""
Created on Sun Sep 24 10:55:05 2017

@author: nitin.kotcherlakota
"""

#matplotlib_scatter
import matplotlib.pyplot as plt
test_scores = [45,50,55,60,54,70,86,90,91,73,88,76,90,98,64,100]
time_spent = [15,15,20,21,40,40,51,52,53,41,50,48,55,54,39,57]
plt.scatter(time_spent,test_scores,marker = 'o')
plt.xlabel('Time Spent')
plt.ylabel('Scores')