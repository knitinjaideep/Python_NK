# -*- coding: utf-8 -*-
"""
Created on Wed Oct 04 03:59:18 2017

@author: nitin.kotcherlakota
"""

#Pandas_list
import pandas as pd

dict = {'a':[1,2,3,3,5,4], 'b':[3,4,5,6,4,2], 'c':[3,7,6,4,2,6], 'd':[2,3,4,3,1,5], 'e':[9,2,4,8,4,5]}

print pd.DataFrame(dict)['a'].tolist()[-1]