# -*- coding: utf-8 -*-
"""
Created on Wed May 24 12:02:43 2017

@author: nitin.kotcherlakota
"""

import re 
i_o = open("D:/pyt/pyt data/Scrape_WV_sample.html", "r")
f = i_o.read()

b = re.finditer(r'mthObj\[\'stats\'\] = {(.*?)\"branchCoverage\"\: {', f, re.S)
for i in b:
    i = i.group(0)
    print re.search(r'\"coverageType\"\:(.*?) \,').group(1)


    
i_o.close()

