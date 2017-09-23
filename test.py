# -*- coding: utf-8 -*-
"""
Created on Wed May 17 11:30:27 2017

@author: nitin.kotcherlakota
"""

l1 = ['SGT_ACTION_ITEMS', 'SGT_CLAIM_EMPLOYER', 'SGT_NOTES', 'SGT_EMPLOYER_ADDRESS', 'SGT_CLAIMANT_ADDRESS', 'SGT_NOTES', 'SGT_CLAIM', 'SGT_CLAIMANT', 'SGT_CLAIMANT_ADDRESS', 'SGT_EMPLOYER_ADDRESS', 'SGT_NOTES', 'SGT_NOTES', 'SGT_COR_TRACKING', 'SGT_ACTION_ITEMS', 'SGT_ACTION_ITEMS', 'SGT_ACTION_ITEMS', 'SGT_AUTHORIZED_PAYMENT', 'SGT_CLAIM', 'SGT_CLAIM', 'SGT_CLAIM', 'SGT_COR_TACKING', 'SGT_COR_TACKING', 'SGT_CLAIMANT', 'SGT_CLAIM', 'SGT_CLAIM_EMPLOYER', 'SGT_EMPLOYER_ADDRESS']
l2 = ['SGT_DETERMINATION_LINK_WEEK', 'SGT_SIDES_ERROR']
f1_output = open('D:/file1_output1.txt', 'w')
f2_output = open('D:/file2_output1.txt', 'w')
for item in set(l1):
    print item
print "\n"
for items in l2:
   
    print items
