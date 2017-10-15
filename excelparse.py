# -*- coding: utf-8 -*-
"""
Created on Tue Oct 10 19:58:40 2017

@author: nitin.kotcherlakota
"""

#Excel file parsing
import xlrd
import xlwt
workbook = xlrd.open_workbook('D:/Nitin/nitin assignment/nitin/a1.xls')
worksheet = workbook.sheet_by_name('Sheet1')
count = 0
wkbook = xlwt.Workbook()
sheet1 = wkbook.add_sheet('New Sheet')
for i in range(4,13):
    count = count + 1
    for j in range(0,10):
        if worksheet.cell_value(i,j) == 'Total':
            i = i+1
            break
        elif worksheet. == ' ':
            i = i+1
            break
        sheet1.write(i,j,worksheet.cell(i,j).value)
        print worksheet.cell(i,j).value
            
    wkbook.save('D:/Nitin/nitin assignment/nitin/a1_ans.xls')       
