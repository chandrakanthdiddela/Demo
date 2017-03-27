#!/usr/local/bin/python3

import wsgiref.simple_server as wg
import urllib.request as url
import urllib.parse as urlp
import json

apicode = "AIzaSyD5Fqole2qOY6R9j5vJ-shLZY2ZYAlvAEE"
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
def MyWebApp(environ, start_response):
    print("In Web App")
    if environ['REQUEST_METHOD'] == "GET" :
         
         response = """
                    <html>
                    <HEAD>
                    <TITLE>My Driving Direction Server</TITLE>
                    </HEAD>
                    <BODY>
                    <h1>Welcome to the Driving Direction server</h1><br>
                    Please enter the Start and Destination location to get Direction<br>
                    <form method="POST">
                    <br><b>Start: </b><input type=text name='Start'>
                    <br><b>Destination: </b><input type=text name='Destination'>
                    <br><button type=submit>Submit
                    </form>
                    </BODY>
                    </html>"""
         response = bytes(response, 'utf-8')
         resplen = len(response)
         
         status = "200 ok"
         headers = [('Content-type', 'text/html, charset=utf-8'),('Content-length', str(resplen))]
         start_response(status, headers)
         return [response]
    elif environ['REQUEST_METHOD'] == "POST" :
         print("received a post")
         datalen = environ['CONTENT_LENGTH']
         data = environ['wsgi.input'].read(int(datalen))
         data = data.decode('utf-8')
         datadict = urlp.parse_qs(data)
         urlquery="http://maps.googleapis.com/maps/api/directions/json?origin="+datadict['Start'][0]+"&destination="+datadict['Destination'][0]+"&APPID="+apicode
         #urlquery = "http://api.openweathermap.org/data/2.5/weather?q="+datadict['Start'][0]+","+datadict['Destination'][0]+"&mode=json&units=imperial&APPID="+apicode

         urlquery = urlquery.replace(" ", "%20")

         page = url.urlopen(urlquery)

         if page.getcode() == 200 :

             DirectionString =page.read()
             DirectionString = DirectionString.decode("utf-8")
             Directiondata = json.loads(DirectionString)
             count=0
             response = """
                    <html>
                    <HEAD>
                    <TITLE>Driving Direction</TITLE>
                    </HEAD>
                    <BODY>
                    <h1>Driving Direction towards destination:</h1><br>
                    <form method="GET">
                    """
             for i in range(0, len(Directiondata['routes'][0]['legs'][0]['steps'])):
                count=count+1
                j = Directiondata['routes'][0]['legs'][0]['steps'][i]['html_instructions']
                response +=str(count) +"."+str(strip_tags(j)) + "<br>"
                print(strip_tags(j))
         #else :
         #       DirectionString = "the center of the universe"
   
        
         response += "<br><button type=submit>Back</form></BODY></html>"
         response = bytes(response, 'utf-8')
         resplen = len(response)
         
         status = "200 ok"
         headers = [('Content-type', 'text/html, charset=utf-8'),('Content-length', str(resplen))]
         start_response(status, headers)
         return [response]

            
    else:
     print("Page not found direction.please click on the back button to reenter the information")
    

srv = wg.make_server("", 1234, MyWebApp)
print("hello")
srv.serve_forever()

