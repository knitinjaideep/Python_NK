# -*- coding: utf-8 -*-
"""
Created on Thu Sep 28 07:00:04 2017

@author: nitin.kotcherlakota
"""

#pandas
import pandas as pd
dict = {'a':[1,2,3,3,5,4], 'b':[3,4,5,6,4,2], 'c':[3,7,6,4,2,6], 'd':[2,3,4,3,1,5], 'e':[9,2,4,8,4,5]}
df = pd.DataFrame(dict)
print df['d'][3]
print df.d[3]
print df.head()