# -*- coding: utf-8 -*-
"""
Created on Tue Jun 06 16:41:28 2017

@author: nitin.kotcherlakota
"""

#import urllib
#
#f = urllib.urlopen("http://mwc-tfsbuild-03.mwc.local/CodeAnalysis/Ncover/Reports/WVMAIN/NCoverReport_Current.NEW.html")
#s = f.read()

import urllib2

page = urllib2.urlopen('http://mwc-tfsbuild-03.mwc.local/CodeAnalysis/Ncover/Reports/WVMAIN/NCoverReport_Current.NEW.html')
#page = urllib2.urlopen('http://mwc-tfsbuild-02.mwc.local/CodeAnalysis/Ncover/Reports/MDMAIN/NCoverReport_Current.NEW.html')

page_content = page.read()

with open('D:/pyt/pyt data/NCoverReportWV.html', 'w') as fid:
#with open('D:/pyt/pyt data/NCoverReportMD.html', 'w') as fid:
    fid.write(page_content)