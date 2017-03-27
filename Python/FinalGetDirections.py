import json
import sys, urllib.request as url

from html.parser import HTMLParser
#https://www.youtube.com/watch?v=ulzlXMZa8ak
#http://stackoverflow.com/questions/753052/strip-html-from-strings-in-python
#answer submitted by stackoverflow user eloff
class MLStripper(HTMLParser):
    def __init__(self):
        self.reset()
        self.strict = False
        self.convert_charrefs= True
        self.fed = []
    def handle_data(self, d):
        self.fed.append(d)
    def get_data(self):
        return ''.join(self.fed)

def strip_tags(html):
    s = MLStripper()
    s.feed(html)
    return s.get_data()
try:
  SourceCommand=sys.argv[1]
  Sourcequery=SourceCommand.replace(" ","+")
  DestinationCommand=sys.argv[2]
  Destinationquery=DestinationCommand.replace( " ","+")
except ValueError:
    print("Error in command line arguments")
apicode = "AIzaSyD5Fqole2qOY6R9j5vJ-shLZY2ZYAlvAEE"
urlquery="http://maps.googleapis.com/maps/api/directions/json?origin="+Sourcequery+"&destination="+Destinationquery+"&APPID="+apicode
page = url.urlopen(urlquery)


if page.getcode() == 200 :

    DirectionString =page.read()
    DirectionString = DirectionString.decode("utf-8")
    Directiondata = json.loads(DirectionString)
    for i in range(0, len(Directiondata['routes'][0]['legs'][0]['steps'])):
            j = Directiondata['routes'][0]['legs'][0]['steps'][i]['html_instructions']
            #strip_tags[j]
            print(strip_tags(j))
else:
    print("Page not found")