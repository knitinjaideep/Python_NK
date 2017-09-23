# -*- coding: utf-8 -*-
"""
Created on Thu Aug 31 11:11:30 2017

@author: nitin.kotcherlakota
"""

from geopy.geocoders import Nominatim
def latlon(state):
    geolocator = Nominatim()
    state = state.strip(',');
    location = geolocator.geocode(state)
    print (str(location.latitude)+'\t'+str(location.longitude))
