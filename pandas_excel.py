# -*- coding: utf-8 -*-
"""
Created on Wed Oct 11 19:48:43 2017

@author: nitin.kotcherlakota
"""
import pandas as pd
df = pd.read_excel('D:/Nitin/nitin assignment/nitin/a1.xls',skiprows = 3,skip_blank_lines=True)
df = df[pd.notnull(df['Date'])]
df = df[~df['Date'].isin(['Total','Date'])]
df.to_excel('D:/Nitin/nitin assignment/nitin/a1_new.xls',sheet_name = 'Sheet1',columns = ['Date','Pennies','Nickels','Dimes','Quarters','Ones','Fives','Tens','Twenties'])
