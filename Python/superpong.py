#!/usr/local/bin/python3

import tkinter
import tkinter.messagebox
import math
import PIL.Image
import PIL.ImageTk
import time
import random

i = 0
deltax = random.randint(1,3)
deltay = random.randint(-3,3)
score1=0
score2=0
GamePaddleSize="nothing"
currentGamelength="0"

def hitimage2 () :
  global tkcanvasimage,i,deltax,deltay,score1,score2,Gamesize,BallSpeed,answertext2,answertext,labelimage,tklabelimage2,rightpaddleid,tklabelimage4,GamePaddleSize,currentGamelength,tklabelimage3,leftpaddleid
  if score1<=int(currentGamelength) and score2<=int(currentGamelength):
    
    isvisible=True
    timedelay = 10
    canvasimage.seek(i)
    i = (i + 1) % 2
    tkcanvasimage = PIL.ImageTk.PhotoImage(canvasimage)
    drawarea.itemconfig(ballid, image = tkcanvasimage)
    print("Gamepaddlesize"+ GamePaddleSize)
    if GamePaddleSize=="small":
     print('small value')
     drawarea.itemconfig(rightpaddleid,image=tklabelimage2)
     drawarea.itemconfig(leftpaddleid,image=tklabelimage2)
    elif GamePaddleSize=="medium":
     print('medium value')
     drawarea.itemconfig(rightpaddleid,image=tklabelimage3)
     drawarea.itemconfig(leftpaddleid,image=tklabelimage3)
    elif GamePaddleSize=="large":
        print('large value')
        drawarea.itemconfig(rightpaddleid,image=tklabelimage4)
        drawarea.itemconfig(leftpaddleid,image=tklabelimage4)

    location = drawarea.coords(ballid)
    location2 = drawarea.coords(rightpaddleid)
    location3= drawarea.coords(leftpaddleid)
    
    
    if location[0] + 37 >= 602 :
        drawarea.coords(ballid,(300,200))
        deltax = random.randint(1,3)
        deltay = random.randint(-3,3)
        timedelay = 100
        score1 = score1 + 1
        answertext.set("Score1: " + str(score1))
        print("player 1 score " + str(score1))
        print("right side wall")



    if location[0] - 37 >= 0 and location[0]<=50:
       print("left side wall" + str(location[0]) + str(location[1]))
       drawarea.coords(ballid, (300, 200))

       deltax = random.randint(1, 3)
       deltay = random.randint(-3, 3)
       timedelay = 100
       score2=score2+1
       answertext2.set("Score1: " + str(score2))

       deltax = +deltax

    if location[0]<=location3[0]+70 and location[1]-5<=location3[1]:
        print('hit the bat1')
        deltax = -deltax

    if location[1] + 37 >= 402 :
        print('bottom wall')
        deltay = -deltay



    if location[1] - 37 <= 0 :
        print('up wall')
        deltay = -deltay

    if location[0] + 37 >= location2[0] - 5 and location[1] <= location2[1] + 20 and location[1] >= location2[1] - 20 :
        print('hit the bat')

        deltax = -deltax
    #if location[0] + 37 >= 40 and location[1] <= 400 and location[1] >= 150:


    drawarea.move(ballid,deltax,deltay)

    rootwindow.after(timedelay, hitimage2)

def hitimage () :
    global GamePaddleSize
    global currentGamelength
    print('hit image called')
    print(Gamesize.get())
    GamePaddleSize=paddlesize.get()
    print(GamePaddleSize)
    currentGamelength=Gamesize.get()

    rootwindow.after(100, hitimage2)

def hitkeyup(ev) :

    drawarea.move(rightpaddleid, 0, -5)

def hitkeydown(ev) :

    drawarea.move(rightpaddleid, 0, 5)

def hitkeyup1(ev):
        drawarea.move(leftpaddleid, 0, -5)

def hitkeydown1(ev):
        drawarea.move(leftpaddleid, 0, 5)

rootwindow = tkinter.Tk()
rootwindow.title("The Image Drawer")
rootwindow.lift()
rootwindow.config(height = 600, width = 600, bg = "yellow")

labelimage = PIL.Image.open("Paddle2.jpg")
labelimage.thumbnail((20, 40))
tklabelimage2 = PIL.ImageTk.PhotoImage(labelimage)
speedlabel = tkinter.Label(rootwindow, text = "Speed: ", fg = "red")
speedlabel.grid(row = 0, column = 0, sticky = "wens")
BallSpeed = tkinter.StringVar()
BallSpeed.set("small")
BallSpeeds = [ "small", "medium", "fast"]
BallSpeedmenu = tkinter.OptionMenu(rootwindow, BallSpeed, *BallSpeeds)
BallSpeedmenu.grid(row = 0, column = 1, sticky = "wens")
paddlelabel = tkinter.Label(rootwindow, text = "Paddlesize: ", fg = "red")
paddlelabel.grid(row = 0, column = 2, sticky = "wens")
paddlesize = tkinter.StringVar()
paddlesize.set("small")
paddlesizes = [ "small", "medium", "large"]
paddlesizemenu = tkinter.OptionMenu(rootwindow, paddlesize, *paddlesizes)
paddlesizemenu.grid(row = 0, column = 3, sticky = "wens")
Gamelengthlabel = tkinter.Label(rootwindow, text = "GameLength: ", fg = "red")
Gamelengthlabel.grid(row = 0, column = 4, sticky = "wens")
Gamesize = tkinter.StringVar()
Gamesize.set("7")
Gamesizes = [ "7", "15", "21"]
Gamesizemenu = tkinter.OptionMenu(rootwindow, Gamesize, *Gamesizes)
Gamesizemenu.grid(row = 0, column = 5, sticky = "wens")
opponentlabel = tkinter.Label(rootwindow, text = "opponent: ", fg = "red")
opponentlabel.grid(row = 1, column = 4, sticky = "wens")
opponentsize = tkinter.StringVar()
opponentsize.set("2")
opponentsizes = [ "2", "1", "Automtated"]
opponentsizemenu = tkinter.OptionMenu(rootwindow, opponentsize, *opponentsizes)
opponentsizemenu.grid(row = 1, column = 5, sticky = "wens")
buttonimage = PIL.Image.open("dummy.png")
buttonimage.thumbnail((30,30))
tkbuttonimage = PIL.ImageTk.PhotoImage(buttonimage)
imagebutton = tkinter.Button(rootwindow, image = tkbuttonimage, command = hitimage)
imagebutton.grid(row = 1, column = 0, sticky = "wens")

answertext=tkinter.StringVar()
answertext.set("Score 1: " + str(score1))

scoreboard = tkinter.Label(rootwindow, textvariable=answertext, font="Calibre 52", foreground="red", background="green")
scoreboard.grid(row=1, column=2)


answertext2=tkinter.StringVar()
answertext2.set("Score 2: " + str(score2))

scoreboard1 = tkinter.Label(rootwindow, textvariable=answertext2, font="Calibre 52", foreground="red", background="green")
scoreboard1.grid(row=1, column=3)

drawarea = tkinter.Canvas(rootwindow, height = 400, width = 600, bg = "pink")
drawarea.grid(row = 2, column = 0, columnspan = 2, sticky = "wens")

canvasimage = PIL.Image.open("animated-ball-image-0046.gif")
tkcanvasimage = PIL.ImageTk.PhotoImage(canvasimage)
ballid = drawarea.create_image(300, 200, image = tkcanvasimage)
labelimage1 = PIL.Image.open("Paddlelarge.jpg")
labelimage1.thumbnail((40, 80))
tklabelimage4 = PIL.ImageTk.PhotoImage(labelimage1)
labelimage3 = PIL.Image.open("Paddle2.jpg")
labelimage3.thumbnail((30, 50))
tklabelimage3 = PIL.ImageTk.PhotoImage(labelimage3)

rightpaddleid = drawarea.create_image(550, 200, image = tklabelimage2)
leftpaddleid = drawarea.create_image(30, 200, image = tklabelimage2)


drawarea.bind("<Up>", hitkeyup)
drawarea.bind("<Down>", hitkeydown)
drawarea.bind("o", hitkeyup1)
drawarea.bind("l", hitkeydown1)
drawarea.focus_set()
#
rootwindow.rowconfigure(0, weight = 1)
rootwindow.rowconfigure(1, weight = 1)
rootwindow.columnconfigure(0, weight = 1)
rootwindow.columnconfigure(1, weight = 1)
rootwindow.mainloop()

