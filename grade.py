# -*- coding: utf-8 -*-
"""
Created on Thu Sep 21 20:44:49 2017

@author: nitin.kotcherlakota
"""


def Enter_grade():    
    student_name = raw_input("Enter a student name: ")
    student_grade = input("Enter the grade for the student: ")
    if student_name in student_gt:        
        student_gt[student_name].append(student_grade) 
    else:
        student_gt[student_name] = [student_grade]
    print student_gt
def Remove_grade():
    student_name = raw_input("Enter the student name you want to remove: ")
    if student_name in student_gt:        
        del student_gt[student_name]
    else:
        print 'student is not in the database'
    print student_gt
def cases():
    option = input("Grading System\nSelect an Option\n1. Enter Grade\n2. Remove Student\n3. Exit\n")
    if option == 1:     
        Enter_grade()
    elif option == 2:
        Remove_grade()
    elif option == 3:
        raise Exception("Found exit()")        
    else:
        print 'select a valid option'
student_gt = {}
while True:   
    cases()
        