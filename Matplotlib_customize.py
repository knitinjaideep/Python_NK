# -*- coding: utf-8 -*-
"""
Created on Tue Sep 26 05:08:36 2017

@author: nitin.kotcherlakota
"""

#matplotlib_customization
import matplotlib.pyplot as plt
import matplotlib.dates as mdates
import numpy as np

#Function to get stock data to plot
def graph_data():
    source_code = open('C:/Users/nitin.kotcherlakota/Downloads/GOOG.csv','r')   
    date,openp,highp,lowp,closep,adj_closep,volumnep = np.loadtxt(source_code,delimiter = ',',unpack = True, converters = {0:mdates.strpdate2num('%m/%d/%Y')})
    ax1 = plt.subplot2grid((1,1),(0,0))
    ax1.fill_between(date,closep,600,where=(closep >=600),color = 'g',alpha = 0.5)
    ax1.fill_between(date,closep,600,where=(closep < 600),color = 'r',alpha = 0.5)
    plt.plot_date(date,closep,'-')
    ax1.grid(True,color = 'b',linestyle='-')
    plt.xlabel('Year',color = 'black')
    plt.ylabel('Income',color = 'black')
    
    plt.show()
graph_data()