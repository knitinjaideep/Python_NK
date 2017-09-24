# -*- coding: utf-8 -*-
"""
Created on Sun Sep 24 15:08:15 2017

@author: nitin.kotcherlakota
"""

#matplotlib - loading data from a csv file
import matplotlib.pyplot as plt
import csv
import numpy as np
#Two ways to read a file, read using Csv or read using numpy. Numpy reduces the number of lines of code.
#1.To read using CSV
def csv_read():
    x = []
    y = []
    with open('D:\Nitin\pyt data\CSVFileRead.txt') as csvfile:
        plots = csv.reader(csvfile,delimiter=',')
        for row in plots:
            x.append(int(row[0]))
            y.append(int(row[1]))
        return x,y
#x,y = csv_read()    

#2. Read using numpy
def numpy():
    x = []
    y = []
    x,y = np.loadtxt('D:\Nitin\pyt data\CSVFileRead.txt',delimiter = ',',unpack = True)
    return x,y
x,y = numpy()
plt.plot(x,y, label= 'label will be loaded from a file')
plt.xlabel('Plot number')
plt.ylabel('Numbers')
plt.legend()
plt.show()

