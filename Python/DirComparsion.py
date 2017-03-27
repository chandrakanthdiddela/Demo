import os
import sys
tabspace="\t"   
def printDirectorycontents(directory1,directory2,psubdirectorypaths1,psubdirectorypath2):
        printEachDirectoryContent(directory1,list(set(directory1) -set(directory2)),psubdirectorypaths1,"Folder1")
        printEachDirectoryContent(directory2,list(set(directory2) -set(directory1)),psubdirectorypath2,"Folder2")
        printEachDirectoryContent(directory1,list(set(directory2)&set(directory1)),psubdirectorypaths1,"common1")
        printEachDirectoryContent(directory2,list(set(directory2)&set(directory1)),psubdirectorypath2,"common2")

def printEachDirectoryContent(pdirectory,psubdirectory,psubdirectorypath,pfoldername):
    print("Printing directory unique to "+ pfoldername)
    for subdir in psubdirectory:
            if subdir in psubdirectorypath.values():
                path=list(psubdirectorypath.keys())[list(psubdirectorypath.values()).index(subdir)]
                print(str(subdir)+"("+pfoldername+")")
                dirs = os.listdir(path)
               
                for file in dirs:
                    fpath=path+"\\"+file
                    if os.path.isdir(fpath):
                      print(tabspace+file +"(subdirectory)")
                      scan_dir(fpath,tabspace+"\t")
                    else:
                     print(tabspace+file)
    print("\n")
  
def scan_dir(dir,tab):
    for name in os.listdir(dir):
        path = os.path.join(dir, name)
        if os.path.isfile(path):
            print(tab+name)
        else:
            dirname=path.split("\\")
            print(tab,dirname[len(dirname)-1]+"(subdirectory)")
            scan_dir(path,tab+tabspace)

def Getallfiles(rootDirpath):
    AllFiles=[]
    AllFilesPath={}
    for dirName, subdirList, fileList in os.walk(rootDirpath):
        for fname in fileList:
            file_path = os.path.join(dirName, fname)
            AllFiles.append(fname)
            AllFilesPath[fname]=file_path
    # Remove the first entry in the list of sub-directories
    # if there are any sub-directories present
        if len(subdirList) > 0:
            del subdirList[0]
        
    return( AllFiles,AllFilesPath)
def PrintFiles(filelist,foldername):
  for fname in filelist:
       print(fname+"("+foldername+")")
def printSameFiles():
    print("Same files")

def analyzesamefileContent(filedictpath1,filedictpath2,pcommonFilelist,pfilelist):
    print(" analyzesamefileContent")
    for fname in pcommonFilelist:
            
                if (os.stat(filedictpath1[fname]).st_mtime==os.stat(filedictpath2[fname]).st_mtime):
                  filename=filedictpath1[fname].split("\\")
                  filename[len(filename)-1]
                  print(filename[len(filename)-1]+"(Same)")
                elif (os.stat(filedictpath1[fname]).st_mtime>os.stat(filedictpath2[fname]).st_mtime):
                  #print(filedictpath1[fname] + str(pfilelist[0])
                    print(filedictpath1[fname] +"("+ str(pfilelist[0])+")")
                elif (os.stat(filedictpath1[fname]).st_mtime<os.stat(filedictpath2[fname]).st_mtime):
                  print(filedictpath2[fname]+"("+ str(pfilelist[1])+")")
                  #print(filedictpath2[fname]++"(" str(pfilelist[1])+")")

# main
try:
  filelist=[]
  File_0=sys.argv[1]
  for index in range(int(File_0)):

    filelist.append(sys.argv[index+2])
except ValueError:
    print("Error in command line arguments")

subdirectory1=[]
subdirectory2=[]
subdirectorypaths1={}
subdirectorypath2={}
for root,d,f in os.walk(filelist[0]):
    for ditem in d:
        directorypath=os.path.join(root,ditem)
        subdirectory1.append(ditem)
        subdirectorypaths1[directorypath]=ditem
for root,d,f in os.walk(filelist[1]):
     for ditem in d:
            directorypath=os.path.join(root,ditem)
            subdirectory2.append(ditem)
            subdirectorypath2[directorypath]=ditem
printDirectorycontents(subdirectory1,subdirectory2,subdirectorypaths1,subdirectorypath2)

filedictpath1={}
filedictpath2={}
folder1Files,filedictpath1=Getallfiles(filelist[0])
folder2Files,filedictpath2=Getallfiles(filelist[1])
print("Files unqiue to " + filelist[0])
PrintFiles(list(set(folder1Files)-set(folder2Files)),filelist[0])
print("Files unqiue to "+filelist[1])
PrintFiles(list(set(folder2Files)-set(folder1Files)),filelist[1])
print("Files common to both folders")
analyzesamefileContent(filedictpath1,filedictpath2,list(set(folder2Files)&set(folder1Files)),filelist)



