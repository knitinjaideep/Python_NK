# -*- coding: utf-8 -*-
"""
Created on Wed Jul 12 13:14:13 2017

@author: nitin.kotcherlakota
"""
import pandas as pd

df = pd.read_excel('C:/Users/nitin.kotcherlakota/Documents/From D/silk/Agent_data_Performance_test.xlsx','Wage Submission Status')
df1 = df[df['SUBMISSION_STATUS'].str.startswith("Q")]
df1['Quarter'] = df1['SUBMISSION_STATUS'].str[:2]
df1.to_excel('C:/Users/nitin.kotcherlakota/Documents/From D/silk/New_Agent_data_Performance_test.xlsx','Sheet1')


        
