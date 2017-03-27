__author__ = 'Varnith'
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
  #SourceCommand=sys.argv[1]
  #Sourcequery=SourceCommand.replace(" ","+")
  #Source="John+F.+Kennedy+International+Airport,+New+York,+NY+11430"
  Source="30%20Alling%20St,%20West%20Haven,%20CT%2006516"
  destination="John%20F.%20Kennedy%20International%20Airport,%20New%20York,%20NY%2011430"
  #DestinationCommand=sys.argv[2]
  #Destinationquery=DestinationCommand.replace( " ","+")
except ValueError:
    print("Error in command line arguments")
apicode = "AIzaSyD5Fqole2qOY6R9j5vJ-shLZY2ZYAlvAEE"
urlmapquery="http://www.mapquestapi.com/directions/v2/route?key="+"MsPvwGQAM1GUE80IzZwrkT6sPVBLkxfA"+"&from="+Source +"&to="+destination
#urlquery="http://maps.googleapis.com/maps/api/directions/json?origin="+Sourcequery+"&destination="+Destinationquery+"&APPID="+apicode
page = url.urlopen(urlmapquery)


if page.getcode() == 200 :

    DirectionString =page.read()
    DirectionString = DirectionString.decode("utf-8")
    Directiondata = json.loads(DirectionString)
    #print(Directiondata)
    for item in Directiondata['route']['legs'][0]['maneuvers']:
        print(item['narrative'])
        #print(i(['narrative']))
           # j = Directiondata['route'][0]['legs'][0]['steps'][i]['html_instructions']
            #strip_tags[j]
            #print(strip_tags(j))
else:
    print("Page not found")