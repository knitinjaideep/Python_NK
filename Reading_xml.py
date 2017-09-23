# -*- coding: utf-8 -*-
"""
Created on Tue Jun 13 11:01:23 2017

@author: nitin.kotcherlakota
"""
import xml.etree.ElementTree as ET
tree = ET.parse('D:/96590343_10000.xml')
root = tree.getroot()
num = 0
for child in root.iter('StateGrossWages'):
    num = num + int(child.text)
print num


