# -*- coding: utf-8 -*-
"""
Created on Tue Jun 06 09:42:20 2017

@author: nitin.kotcherlakota
"""

# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""
import re 
count = 0
l  = list()
l2 = list()
i_o = open("D:/pyt/pyt data/NCoverReportWV.html", "r")
f = i_o.read()
f_o = open ("D:/pyt/pyt data/Scrape_WV_sample_finditer.txt", "w")
s_o = open ("D:/pyt/pyt data/WebScrape_data.txt","r")
s = s_o.read()
j = 0
#Regular expression for taking class as a subset
classes = re.finditer(r'clsObj\[\'class\'\](.*?)clsObj = {};', f, re.S)

for match in classes: 
    match = match.group(0)
#Regular expression for taking methods as a subset
    meth_matches = re.finditer(r'mthObj\[\'method\'\](.*?)mthObj = {};', match, re.S)
    #meth_matches = re.finditer(r'mthObj\[\'method\'\](.*?)\"coveragePercentString\"(.*?)((\n|\r\n).*)((\n|\n).*)',match,re.S)
#    meth_matches1 = re.finditer(r'mthObj\[\'method\'\](.*?)classObj = {};', match, re.S)
    for meth_match in meth_matches:
        meth_match = meth_match.group(1)
#Regular expression for taking the percentages
        pers = re.finditer(r'{(.*?)}\,',meth_match,re.S)     
        for per in pers:
            CType = re.search(r'\"coverageType\"\: (.*?)\,',per.group(0)).group(1)
            CPString = re.search(r'\coveragePercentString\"\:(.*)\"',per.group(0)).group(1)
            if CType == '"SP"':
                sp = CPString
            elif CType == '"BP"':
                bp = CPString
            else:
                cp = CPString
        for j in range(0,23):
            if re.search(r'\"caption\"\: (.*)\,',match).group(1).strip('"') == s.split('\n')[j]:
                l.append(re.search(r'\"caption\"\: (.*)\,',match).group(1).strip('"')+","+re.search(r'\"caption\"\: (.*)\(', meth_match).group(1).strip('"')+","+bp.strip(' ').strip('"')+","+sp.strip(' ').strip('"')+","+cp.strip(' ').strip('"'))
f_o.write(str(l).replace('[','').replace(']','').replace('\',','\n').replace('\'',''))
i_o.close()
f_o.close()