import string
import operator

Listwordict = {}
RankWorddict = {}


def createDictionary(character, word):
    for k in string.ascii_uppercase:
        Listwordict[k] = set()
        Listwordict[character.upper()] = {word}
    return Listwordict


def updateWordList(character, pwordlist, index, word):
    pwordlist[index][character.upper()].add(word)


def rankTheWord(wordict, Guessset):
    for guessword in Guessset:
        occurencecount = worddict[guessword]
        RankWorddict[guessword] = occurencecount
    return RankWorddict


def getcountandwordlist(x, querywords):
    lworddict = {}
    pcount = 0
    for i in range(len(x)):
        a, b = x[i]
        if not a.find(querywords) == -1:
            lworddict[a] = b
            pcount = b + pcount
    return (lworddict, pcount)


def filterwords(x, querywords):
    lworddict = {}
    pcount = 0
    for k in x:
        a = k

        if not a.find(querywords) == -1:
            pcount = 0
            lworddict[a] = x[a];
            # pcount=b+pcount
    return lworddict


filename = input("Please enter file to search: ")
fileobj = open(filename, "r")
lines = fileobj.readlines()
fileobj.close()
worddict = {}
linenum = 1
intialcount = 1
for line in lines:
    words = line.split()

    for word in words:
        exclude = set(string.punctuation)
        pword = ''.join(ch for ch in word if ch not in exclude)
        newword = ''.join([i for i in pword if not i.isdigit()])
        # newword = word.strip(",.!'\"()-_:/;")
        newword = newword.lower()
        if len(newword) > 1:
            if newword in worddict:
                newvalue = worddict[newword] + 1
                worddict[newword] = newvalue
            else:

                worddict[newword] = 1

    linenum += 1

wordlist = []
TextFilewordDict = {}
for word in worddict:
    newword = word
    # exclude = set(string.punctuation)
    # pword = ''.join(ch for ch in word if ch not in exclude)
    # newword = ''.join([i for i in pword if not i.isdigit()])
    # word list is empty that means we are inserting for the first time
    if len(wordlist) == 0:
        # loop throughing each character building
        for character in newword:
            newdict = {}
            newdict = createDictionary(character, newword)
            wordlist.append(newdict.copy())

    elif len(newword) > len(wordlist):
        NoOFnewItems = len(newword) - len(wordlist)
        # need to append to original list frist then append remaining letter to extended list
        count = 0
        for index in range(0, len(wordlist)):
            ch = newword[count]
            updateWordList(ch, wordlist, index, newword)
            count = count + 1;
            # need to update original list, call a function pass the character and wordlist to it
        count = len(wordlist)  # get the value of
        for i in range(0, NoOFnewItems):
            character = newword[count]
            wordlist.append(createDictionary(character, newword).copy())
            count = count + 1
    elif len(newword) < len(wordlist):
        # print("less than worldlist")
        for index in range(0, len(newword)):
            ch = newword[index]
            updateWordList(ch, wordlist, index, newword)

search = "co"
index = 0
GuesswordList = []
finalset = set()
Guessset = set()
answer = "yes"
while answer == "yes":
    query = input("Enter the word: ")
    querywords = query
    for ch in querywords:
        if (wordlist[index][ch.upper()]):
            GuesswordList.append(wordlist[index][ch.upper()])
            index += 1
    if (len(GuesswordList) == 1 and len(querywords) == 1):
        Guessset = GuesswordList[0]
        RankWorddict = rankTheWord(worddict, Guessset)

    for i in range(1, len(GuesswordList)):
        if i == 1:
            Guessset = GuesswordList[0] & GuesswordList[i]
            RankWorddict = rankTheWord(worddict, Guessset)
        else:
            Guessset = Guessset & GuesswordList[i]
            RankWorddict = rankTheWord(worddict, Guessset)
    lobjRankWorddict = filterwords(RankWorddict, querywords)
    x = sorted(lobjRankWorddict.items(), key=operator.itemgetter(1), reverse=True)[:5]
    finalguesswords, count = getcountandwordlist(x, querywords)
    if len(finalguesswords) > 0:
        print("Below are the probable list of words starting with letters " + querywords)
        print(sorted(finalguesswords.items(), key=operator.itemgetter(1),reverse=True))
    else:
        print("No Match found")
        print(finalguesswords)


    for w in sorted(finalguesswords.items(), key=operator.itemgetter(1),reverse=True):
        percentage=round(w[1]/count,2)*100
        print(w[0] ,str(percentage))

    Guessset = set()
    GuesswordList = []
    RankWorddict = {}
    index = 0
    answer = input("Do you want to do it again?")
print("***End of the program")