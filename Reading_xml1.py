# -*- coding: utf-8 -*-
"""
Created on Thu Jul 27 13:42:18 2017

@author: nitin.kotcherlakota
"""

import xml.etree.ElementTree as ET
tree = ET.parse('D:/100012770_32017.xml')
f = open('D:/XML.txt','w');
root = tree.getroot()
num = 0
for child in root.iter('SSN'):
    f.write((child.text)+"\n")