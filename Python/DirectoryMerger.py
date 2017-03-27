import sys
import os
import shutil


# this function check whether given directory 1 and directory path exist or not 
def directoryCheck(directory1,directory2):
   Isdirectory1= os.path.isdir(directory1) 
   Isdirectory2=os.path.isdir(directory2)
    
   if Isdirectory1==False and Isdirectory2==False:
        print("Neither Directories",directory1,",",directory2,"exist on this system, exitting")
        return False
    
   elif Isdirectory1==False:
        print(directory1,"does not exist on this system. Exitting")
        return False
   
   elif Isdirectory2==False:
        print(directory2,"does not exist on this system. Exitting")
        return False
    
   return True



def dirSearch(directory):
    try:
        lis = os.listdir(directory)     
    except FileNotFoundError:
        print("Error, file not found")
        return
    lis2=[]                              
    lis3=[]   
    lis4=[]                           
    i=0                                
    for item in lis:                    
        if os.path.isfile(directory+"/"+item):
            lis4.append(item)
                                            
        elif os.path.isdir(directory+"/"+item):
            lis2.append(directory+"/"+item)
            lis3.append(item)
    
    for item in lis2:   
        try:               
            dirSearch(item)
        except PermissionError:
            print( "Permission denied: ",item)



# search both the directory1 and directory2 and store information about the common file which are latest file
def Search(directory1,directory2):
   fileList1=[]                          
   fileList2=[]   
   directorycontent1 = os.listdir(directory1)   
   directorycontent2 = os.listdir(directory2)   
                            
   
   for item in directorycontent1:                       
        if os.path.isfile(os.path.join(directory1,item)):
            fileList1.append(item)
   for item in fileList1:              
        directorycontent1.remove(item)
        
   for item in directorycontent2:                       
        if os.path.isfile(os.path.join(directory2,item)):
            fileList2.append(item)
   for item in fileList2:
        directorycontent2.remove(item)
      



   for item in fileList2:              #lists the files in both directories
        if item in fileList1:
           try:                                #creates a stat object for each file to see which is newer
                 file1 =  os.stat(os.path.join(directory1,item))
                 file2 = os.stat(os.path.join(directory2,item))
           except FileNotFoundError:
                print("Something went Wrong")   
           if file1.st_mtime > file2.st_mtime:  # file in directory 1 is newer
                commonfile.append(directory1+"//"+item)

           if file1.st_mtime < file2.st_mtime:   # file in directory 2 is newer
                commonfile.append(directory2+"//"+item)
               


    #recursively search the subdirectories that are unique to directory1
   for item in directorycontent1:
        if item not in directorycontent2:     
            dirSearch(directory1+"/"+item)

    #recursively search the subdirectories that are unique to directory2
   for item in directorycontent2:
        if item not in directorycontent1:
            dirSearch(directory2+"/"+item)
 #recursively search the subdirectories that are common
   for item in directorycontent1:
        if item in directorycontent2:
            Search(directory1+"/"+item,directory2+"/"+item)




def mycopytree(src, dst, symlinks=True):
    names = os.listdir(src)
    
    if not  os.path.exists(dst):
       os.makedirs(dst)

    errors = []
    for name in names:
        srcname = os.path.join(src, name)
        dstname = os.path.join(dst, name)
        try:
            if symlinks and os.path.islink(srcname):
                linkto = os.readlink(srcname)
                os.symlink(linkto, dstname)
            elif os.path.isdir(srcname):
                mycopytree(srcname, dstname, symlinks)
            else:
                shutil.copy2(srcname, dstname)
          
        except OSError as why:
            errors.append((srcname, dstname, str(why)))
        except Error as err:
            errors.extend(err.args[0])
   

commonfile=[]
#source1=r'C:\Users\cdidd1\Desktop\Test\chandu'
#source2=r'C:\Users\cdidd1\Desktop\Test\diddela'
#destination=r'C:\Users\cdidd1\Downloads\p3'

if len(sys.argv)>4:
    print("extra command line arguments, ignoring the rest")
    source1=sys.argv[1]
    source2 = sys.argv[2]
    destination=sys.argv[3]

if len(sys.argv)<4:
    print("not enough command line arguments, exitting")
    sys.exit(1)

else :
    source1=sys.argv[1]
    source2 = sys.argv[2]
    if(source1==source2):
     print("Source1 and source2 are same")
     sys.exit(1)
    destination=sys.argv[3]
#checks that the directories exist, if they dont program exits
if not directoryCheck(source1,source2):
    sys.exit(1)

newpath = r'C:\Program Files\arbitrary' 
if  os.path.exists(destination):
    print("Destination already exist")
    sys.exit(1)
os.makedirs(destination)



mycopytree(source1, destination, symlinks=True)
mycopytree(source2, destination, symlinks=True)
print("*****Folder Merge applicatoin*****")
Search(source1,source2)
#print(commonfile)
for item in commonfile:
   if source1 in item :
      dstpath=destination+item[len(source1):]
      #print(destination+item[len(source1):])
      shutil.copy2(item,dstpath)
      

   if source2 in item:
      dstpath=destination+item[len(source2):]
      #print(destination+item[len(source2):])
      shutil.copy2(item,dstpath)
      

print("*****end of the program*****")