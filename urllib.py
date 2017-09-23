# -*- coding: utf-8 -*-
"""
Created on Sat Sep 23 15:51:13 2017

@author: nitin.kotcherlakota
"""

#urllib request

import urllib.request
req = urllib.request.urlopen("https://www.google.com")
print req.read()