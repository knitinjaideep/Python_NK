# -*- coding: utf-8 -*-
"""
Created on Sun Oct 08 17:16:36 2017

@author: nitin.kotcherlakota
"""
import pygame

pygame.init()
#To set a resolution.
surface = pygame.display.set_mode((800,400))

pygame.display.set_caption('Helicopter')
#All computer games has frames per second
clock = pygame.time.Clock()

game_over = False
#display.flip will update the entire surface and display.update will update certain
#parts or surfaces. But if display.update does not have any parameters it will work similar to
#flip
while not game_over:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            game_over = True
    pygame.display.update()
    clock.tick(60)

pygame.quit()
quit()
