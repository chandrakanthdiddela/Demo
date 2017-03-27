__author__ = 'Varnith'
import urllib.request as urr
import re
def  validateurl(uristring,x):
     validurl = uristring[7:len(uristring)]
     if not validurl.__contains__("//"):
         if not validurl.endswith("/"):
          print(x)
     else :
        return validurl.__contains__("//")

def printsitemap(lstruri):
 if lstruri.endswith("icons/"):
     print(lstruri+" deadlink")
     return None
 elif  lstruri.endswith("/"):
        print(lstruri)

 else:
    return None
 page1=urr.urlopen(lstruri)
 if page1.getcode()==200 :
    sourcepage1 = page1.read()
    source1 = sourcepage1.decode("utf-8")

    regexp = re.compile(r'HREF="([-A-Za-z0-9/_.]+)"')
    lobjurl = regexp.findall(source1)
    regexp1= re.compile(r'HREF="mailto')
    lobjmailid = regexp1.findall(source1)
    if len(lobjmailid)==0:

        if len(lobjurl)>0:
            for x in lobjurl :
             if len(x)>1:

                uristring=lstruri+x
                Isvalid=  validateurl(uristring,x)

                if not Isvalid:

                    printsitemap(lstruri+x)


    elif len(lobjmailid)>0:
        print("outsidelink")
 elif page1.getcode()==404:
    print("deadlink")
 else :
    print("Error in retrieving web page: ", page1.getcode())


searchurl="http://vision.newhaven.edu"
page = urr.urlopen(searchurl)
if page.getcode() == 200 :

   sourcepage = page.read()
   source = sourcepage.decode("utf-8")

   regexp = re.compile(r'HREF="([-A-Za-z0-9/_.]+)"')
   urls = regexp.findall(source)

   for url in urls :
       if len(url)>1:
        globvar="/"+url
        lstruri="http://vision.newhaven.edu/"+url

        print(lstruri)
        printsitemap(lstruri)

else :
   print("Error in retrieving web page: ", page.getcode())