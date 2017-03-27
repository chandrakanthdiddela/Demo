__author__ = 'Varnith'
import re

def PrepareDictionary():
# store all the line in a List of string
    ListofLines = lobjFile.readlines()
    lobjLinecollections= []
    lobjWordcollection = {}
    for line in ListofLines:
    # loop through each line and store it in a list collection
        lobjLinecollections.append(line)
    # split each line and store strings in a collection
    counter=0
    for lobjEachLinsplit in lobjLinecollections:
        counter=counter+1
        nstr = re.sub(r'[?|$|.|!|.|@|#|%|&|*|(|)|,|:]',r'',lobjEachLinsplit)



        ArrayofStrings= nstr.split(" ")
# split individual string and store key and its value in dictionary object
        for lobjword in ArrayofStrings:
    #print(lobjword)
            lobjwordkey= lobjword.strip("\n").upper()
            if lobjwordkey in lobjWordcollection:
            #ingredientList[key].append(item)
                lobjWordcollection[lobjwordkey].append(counter)
            #lobjWordcollection[lobjword]=lobjWordcollection[lobjword]+tuple(counter)
                #print(lobjwordkey +'in')
                    #print ("blah")
            else :

                lobjWordcollection[lobjwordkey]=[counter]
                #print(lobjwordkey)
    lobjFile.close()
    return lobjWordcollection

def singleword(pobjWordcollection,lstrUserInput):
    print('singleword')
    if lstrUserInput in pobjWordcollection :
        print("Given input search keyword : " +lstrUserInput + " is found at line numbers " +str(pobjWordcollection[lstrUserInput]))
    else :
        print('given input is not found in the text file')


def  AndOperation(pobjWordcollection,lstrUserInput1,lstrUserInput2):
    if lstrUserInput1 in pobjWordcollection :
        print("Given input search keyword : " +lstrUserInput1 + " is found at line numbers " +str(pobjWordcollection[lstrUserInput1]))
    else:
        print("Given input search keyword : " +lstrUserInput1 + " is not found in text file")
    if lstrUserInput2 in pobjWordcollection :
        print("Given input search keyword : " +lstrUserInput2 + " is found at line numbers " +str(pobjWordcollection[lstrUserInput2]))
        #print('And Operation')
    else:
        print("Given input search keyword : " +lstrUserInput2 + " is not found in text file")

    list1=pobjWordcollection[lstrUserInput1]
    list2=pobjWordcollection[lstrUserInput2]

    b3 = [val for val in list1 if val in list2]
    if len(b3)>0 :
        print("Given input search words are found at" + str(b3))
    else :
        print ("given input search words don't have any common line")


def  OROperation(pobjWordcollection,lstrUserInput1,lstrUserInput2):
    print('OR Operation')
    if lstrUserInput1 in pobjWordcollection :
        print("Given input search keyword : " +lstrUserInput1 + " is found at line numbers " +str(pobjWordcollection[lstrUserInput1]))
    else:
        print("Given input search keyword : " +lstrUserInput1 + " is not found in text file")
    if lstrUserInput2 in pobjWordcollection :
        print("Given input search keyword : " +lstrUserInput2 + " is found at line numbers " +str(pobjWordcollection[lstrUserInput2]))
    else:
        print("Given input search keyword : " +lstrUserInput2 + " is not found in text file")
    list1=pobjWordcollection[lstrUserInput1]
    list2=pobjWordcollection[lstrUserInput2]
    list3=list1+list2
    print("Given input search keyword are found at following lines" + str(list3))

def  XOROperation(pobjWordcollection,lstrUserInput1,lstrUserInput2):
     print('XOR Operation')
     if lstrUserInput1 in pobjWordcollection :
        print("Given input search keyword : " +lstrUserInput1 + " is found at line numbers " +str(pobjWordcollection[lstrUserInput1]))
     else:
        print("Given input search keyword : " +lstrUserInput1 + " is not found in text file")
     if lstrUserInput2 in pobjWordcollection :
        print("Given input search keyword : " +lstrUserInput2 + " is found at line numbers " +str(pobjWordcollection[lstrUserInput2]))
     else:
      print("Given input search keyword : " +lstrUserInput2 + " is not found in text file")
     list1=pobjWordcollection[lstrUserInput1]
     list2=pobjWordcollection[lstrUserInput2]
     outputlist = [value for value in list1+list2 if (value not in list1) or (value not in list2)]
     print(outputlist)

loop = True
# outer query loop which ask user what action to perform
while loop:
        print('********search queries*****************')
        print('Press 1 to perform search for single word ')
        print('Press 2 to perform search for two words in a sentence (AND operation)')
        print('Press 3 to perform search for either of the two words in a sentence (OR operation)')
        print('Press 4 to perform search for either of the two words in a sentence (XOR operation)')
        print('Type quit  to exit')
        lintUserChoice = input('Enter a number 1 or 2 or 3 or 4 continue ')
        print('you have entered option Number %s \n' % (lintUserChoice))
        if(lintUserChoice.upper()=='QUIT'):
            print("***Thankyou User***")
            break
        lstrFilepath = input('Enter the file path ')
        lobjFile = open(lstrFilepath)
        #lobjFile = open("D:\\UNH\Fall2015\\Python Programming\\osmoduleclassfile\\test.txt")
        if (lintUserChoice == '1'):
            pobjWordcollection =PrepareDictionary()
            lstrUserInput = input('please enter a word to search ')
            lstrUserInput=lstrUserInput.strip(' ')
            singleword(pobjWordcollection ,lstrUserInput.upper())
        elif (lintUserChoice == '2'):
             pobjWordcollection =PrepareDictionary()
             lstrUserInput1 = input('please enter a word1 to search ')
             lstrUserInput2 = input('please enter a word2 to search ')
             AndOperation(pobjWordcollection,lstrUserInput1.upper(),lstrUserInput2.upper())
        elif (lintUserChoice == '3'):
             pobjWordcollection =PrepareDictionary()
             lstrUserInput1 = input('please enter a word1 to search ')
             lstrUserInput2 = input('please enter a word2 to search ')
             OROperation(pobjWordcollection,lstrUserInput1.upper(),lstrUserInput2.upper())

        elif (lintUserChoice == '4'):
             pobjWordcollection =PrepareDictionary()
             lstrUserInput1 = input('please enter a word1 to search ')
             lstrUserInput2 = input('please enter a word2 to search ')
             XOROperation(pobjWordcollection,lstrUserInput1.upper(),lstrUserInput2.upper())
        #elif(lintUserChoice=='Quit'):
           # print("***Thankyou User***")
            #loop=False



