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
  DestinationCommand=sys.argv[2]
  SourceGooglequery=SourceCommand.replace(" ","+")
  DestinationGooglequery=DestinationCommand.replace( " ","+")
  SourceMapquery=SourceCommand.replace(" ","%20")
  DestinationMapquery=DestinationCommand.replace( " ","%20")
  
except ValueError:
    print("Error in command line arguments")
# googlemap api key
apicode = "AIzaSyD5Fqole2qOY6R9j5vJ-shLZY2ZYAlvAEE"
mapapicode="MsPvwGQAM1GUE80IzZwrkT6sPVBLkxfA"
GoogleMapurlquery="http://maps.googleapis.com/maps/api/directions/json?origin="+SourceGooglequery+"&destination="+DestinationGooglequery+"&APPID="+apicode
MapQuesturlmapquery="http://www.mapquestapi.com/directions/v2/route?key="+mapapicode+"&from="+SourceMapquery +"&to="+DestinationMapquery
pageGoogleMapServiceWebContent= url.urlopen(GoogleMapurlquery)
pageMapquestServiceWebCotent=url.urlopen(MapQuesturlmapquery)
GoogleFilelist=[]
MapquestFilelist=[]
# print contents of Google map service result
print("**Google map Webservice Result**")
if pageGoogleMapServiceWebContent.getcode() == 200 :

    DirectionString =pageGoogleMapServiceWebContent.read()
    DirectionString = DirectionString.decode("utf-8")
    Directiondata = json.loads(DirectionString)
    for i in range(0, len(Directiondata['routes'][0]['legs'][0]['steps'])):
            j = Directiondata['routes'][0]['legs'][0]['steps'][i]['html_instructions']
            GoogleFilelist.append(strip_tags(j))
            print(strip_tags(j))
else:
    print("Page not found")
# print contents of MapQuest web ServiceResult
print("**MapQuest Webservice Result**")
if pageMapquestServiceWebCotent.getcode() == 200 :
    DirectionString =pageMapquestServiceWebCotent.read()
    DirectionString = DirectionString.decode("utf-8")
    Directiondata = json.loads(DirectionString)
    for item in Directiondata['route']['legs'][0]['maneuvers']:
        print(item['narrative'])
        MapquestFilelist.append(item['narrative'])
else:
    print("Page not found")
print(len(GoogleFilelist))
print(len(MapquestFilelist))