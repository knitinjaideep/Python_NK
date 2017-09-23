# -*- coding: utf-8 -*-
"""
Created on Mon Jul 31 13:50:22 2017

@author: nitin.kotcherlakota
"""

import pypyodbc
#import pandas as pd
cur = pypyodbc.connect('"Data Source=UIMMD-NP-SQL02.uimmdtest.local;User ID=devuser;password=devuser123;Initial Catalog=UIM-MD-PERFTEST-DB;TimeOut=90;Persist Security Info=True;Asynchronous Processing=True;"')
c = cur.cursor()
c.execute("select top 10 * from sgt_employer")
data = []
for rows in c:
    for row in rows:
        data.append(row)

print data
c.close()
cur.close()