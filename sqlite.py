# -*- coding: utf-8 -*-
"""
Created on Sat Sep 23 13:58:21 2017

@author: nitin.kotcherlakota
"""
#database connection and creating a database and a table
import sqlite3
#Connect to the database. If exists it will connect to it or if not it will just create it.
conn = sqlite3.connect('dbname')
#like a mouse tell it what to do. 
c = conn.cursor()

#create a table
def create_table():
    c.execute("create table tablename (columnname1 datatype columnname2 datatype...columnnamen datatype)")

def insert_data():
    c.execute("insert into tablename values('a','b',...,'z')")
    conn.commit()

def enter_dynamically():
    var1 = input("what language")
    var2 = input("what version")
    
    c.execute("insert into tablename (columnname1,columnname2) values (?,?)",var1,var2)
    conn.commit()

def reading():
    var1 = input()
    var2 = input()
    sql = "select * from tablename where columnname1 = ? and columnname2 = ?"
    for row in c.execute(sql,[(var1,var2)]):
        print row
#close the connection
conn.close()