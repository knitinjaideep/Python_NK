# -*- coding: utf-8 -*-
"""
Created on Wed Oct 04 05:06:07 2017

@author: nitin.kotcherlakota
"""

#Pandas reading csv
import pandas as pd

df = pd.read_csv('C:/Users/nitin.kotcherlakota/Downloads/GOOG.csv')
df.set_index('Date',inplace = True)
print df.head(2)
df = pd.read_csv('C:/Users/nitin.kotcherlakota/Downloads/GOOG_new.csv', index_col = 0)
df.to_csv('C:/Users/nitin.kotcherlakota/Downloads/GOOG_new.csv')
#df['Close'].to_csv('C:/Users/nitin.kotcherlakota/Downloads/GOOG_new.csv')