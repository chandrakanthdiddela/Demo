import re
import sys
import os
import operator
from _operator import itemgetter


def get_file_lines(filename):
        try:
          fileobj = open(filename, "r")  # open the file in read mode
          lines = fileobj.readlines()  # reads all the line of the program
          fileobj.close()
        except PermissionError:  # permission error
            print("Permission denied: ", filename)

        return lines



def FileCheck(CustomerDataFile):
    f1 = os.path.isfile(CustomerDataFile)  # boolean for if paths are Files on system
    # File 1 doesnt exist
    if f1 == False:
        print(VoterFile, "does not exist on this system. Exitting")
        return False
       
   
    # return true if file exist
    return True

def ExtractName(TransactionRecord,NameMatcher):    # function to extract name  of the customer from the given data
      Name=re.search(NameMatcher,TransactionRecord)
      if(Name):
        firstName=Name.group('firstName') # get the first name of the customer
        middleName=Name.group('middleName') # get the middle name of the customer
        LastName=Name.group('LastName') # get the last name of the customer
        title=Name.group('title')  # gets the title of the customer
        return (firstName,LastName,middleName,title)
      
      else:
         print('***Not Found***')
         print(Name)
         return None



def ExtractDate(TransactionRecord,TransactionDateMatcher,TransactionDateMatcher2):   # function to extract date  of the customer from the given data
    TransactionDate=re.search(TransactionDateMatcher,TransactionRecord)  
    
    if(TransactionDate):
      
       return (True,TransactionDate.group('TransactionDate'))  # get the Transaction date of the customer

    TransactionDateType2=re.search(TransactionDateMatcher2,TransactionRecord)
    if(TransactionDateType2):
     
       return (False,TransactionDateType2.group('TransactionDate'))

    else:
        print('Invalid Date')
        return None

 
def ExtractCreditCardInfo(TransactionRecord,AmericanExpressMatcher,MastercardType1Matcher,MastercardType2Matcher,VisaCardTypeMatcher):    # function to extract credit card information of the customer from the given data
     AmericanExpressCreditNumber=re.search(AmericanExpressMatcher,TransactionRecord)
     # check for American Express credit number
     if(AmericanExpressCreditNumber):
          
          return('Amexcard',AmericanExpressCreditNumber.group('AmericanExpresscard'))
          
     MastercardType1CreditNumber=re.search(MastercardType1Matcher,TransactionRecord)
     if(MastercardType1CreditNumber):
         
          return('Mastercard',MastercardType1CreditNumber.group('MastercardType1'))
          
     MastercardType2CreditNumber=re.search(MastercardType2Matcher,TransactionRecord)
     if(MastercardType2CreditNumber):
         
          return ('Mastercard',MastercardType2CreditNumber.group('MastercardType2'))
         
     VisaCardTypeCreditNumber=re.search(VisaCardTypeMatcher,TransactionRecord)
     if(VisaCardTypeCreditNumber):
          
          return ('VisaCard',VisaCardTypeCreditNumber.group('Visa'))
         



def ExtractDollarInformation(TransactionRecord,AmountMatcher):
    Amount=re.search(AmountMatcher,TransactionRecord)
    if(Amount):
          dollaramount=Amount.group('Dollar').lstrip(":").rstrip(":")
          
          return dollaramount
    else:
        print('Invalid Amount'+ TransactionRecord)
        return None


def ConvertTextToDate(transactionDate):

    datecontents=transactionDate.split(",") # first split by comma since the we know the format of date(February 13, 1990) coming
    transactionYear =  datecontents[1].strip() # removing leading and trailing spaces
    MonthDay= datecontents[0].split(" ")
    transactionMonth=MonthDay[0].strip()
    transactionDate= MonthDay[1].strip()
    Months = {'January': '01', 'February': '02' ,'March': '03', 'April': '04' ,'May': '05', 'June': '06' ,'July': '07', 'August': '08' ,'September': '09', 'October': '10', 'November':'11','December':'12' }
    #print('Convert Text To Date')
    for k, v in Months.items():
        if  transactionMonth in k:  # need to check substring also
          #print(k,v)
          #MM/DD/YYYY-format
          return v +"/"+transactionDate+"/"+transactionYear  # return the value in required format

def SortListBasedonDate(CreditcardCustomerList):
   
    sortedCustomerList=sorted(CreditcardCustomerList, key=itemgetter(4,1,5))
    return sortedCustomerList
    
    

print("""Chandrakanth Diddela
         Python Programming
         Fall 2016
       Assignment #4 - Transaction Report.py""")


# Checks the command line arguement
print(sys.version, "\n")
if len(sys.argv) > 2:
    print("Extra command line arguements, ignoring the rest")
    CustomerDataFile= sys.argv[1]
   
if len(sys.argv) < 2:
    print("Not enough command line arguements, Exitting")
    sys.exit(1)
else:
    CustomerDataFile = sys.argv[1]
   
# checks that the Fiels exist, if they dont program exits
if not FileCheck(CustomerDataFile):
    sys.exit(1)



print('***welcome to Credit card***')
Records=get_file_lines(CustomerDataFile)
#Records=get_file_lines(r'c:\users\cdidd1\documents\visual studio 2015\Projects\TransactionReport\TransactionReport\SampleCreditCardholderData.txt')



# AmericanExpress card holder List
AmexcardCustomerList=[]
# Mastercard holder List
MastercardCustomerList=[]
# Visacard holder List
VisaCardCustomerList=[]


for TransactionRecord in Records:
    #print(r)

 TransactionRecord=TransactionRecord.strip()
 NameMatcher =re.compile(r'^((?P<firstName>[A-Za-z]+)+\s+(?P<middleName>[A-Za-z]?)(\.)?\s+(?P<LastName>[A-Za-z]+)+\s?(?P<title>Sr(.)|Jr(.)|III|IV)?)')  # name regex
 AmericanExpressMatcher=re.compile(r'(?P<AmericanExpresscard>(34|37)\d{2}(\s|-)?\d{6}(\s|-)?\d{5}$)') # American express card matcher
 MastercardType1Matcher=re.compile(r'(?P<MastercardType1>(222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)\d{12}$)')  # Master card type1 matcher
 MastercardType2Matcher=re.compile(r'(?P<MastercardType2>5[1-5][0-9]{14})')  # Master card type2 matcher
#AmountMatcher=re.compile(r'(?P<Dollar>(\$)?(\d+)(\.\d\d)?$)') 
 AmountMatcher =re.compile(r'(?P<Dollar>(^|:)(\$)?(\d+)(\.\d\d)?(:|$))')   # dollar amount matcher                    
 VisaCardTypeMatcher= re.compile(r'(?P<Visa>(4[0-9]{3}((\s|-)?)[0-9]{4}((\s|-)?[0-9]{4})((\s|-))?[0-9]{4}$))')  # visa card matcher
 TransactionDateMatcher=re.compile(r'(?P<TransactionDate>(Jan(uary)?|Feb(ruary)?|Mar(ch)?|Apr(il)?|May|Jun(e)?|Jul(y)?|Aug(ust)?|Sep(tember)?|Oct(ober)?|Nov(ember)?|Dec(ember)?)+(\s)+(\d{1,2})\,\s(\d{4}))')  # Transaction date
 TransactionDateMatcher2=re.compile( r'(?P<TransactionDate>(0[1-9]|1[012])[- \/.](0[1-9]|[12][0-9]|3[01])[- \/.](16|17|18|19|20)\d\d)')
 CustomerName=ExtractName(TransactionRecord,NameMatcher)   # function to extract name  of the customer from the given data
 NeedsConversion=False
 transactionDate=ExtractDate(TransactionRecord,TransactionDateMatcher,TransactionDateMatcher2) # function to extract name  of the customer from the given data
 TransactonAmount=ExtractDollarInformation(TransactionRecord,AmountMatcher) # function to extract dollar amount information of the customer from the given data
 #print(TransactonAmount)
 CardDetails=ExtractCreditCardInfo(TransactionRecord,AmericanExpressMatcher,MastercardType1Matcher,MastercardType2Matcher,VisaCardTypeMatcher)   # function to extract credit card information of the customer from the given data
 #  check none option
 
 if(CardDetails==None):
    print('Ignoring transaction since the card details are not valid for the record : '+ TransactionRecord)
    continue

 if(CardDetails[0]=='Amexcard'):
     Amexcustomer=[]
     AmexcustomerFName=CustomerName[0]   # customer fname 
     AmexcustomerLName=CustomerName[1]   # customer lname
     # check length of middle name or otherwise put empty string in to list
     AmexcustomerMName=CustomerName[2] # customer optional middle name
    # check length of title or otherwise put empty string in to list
     AmexcustomerTitle=CustomerName[3]  # customer title
     #AmexcustomerTransactiondate=ConvertTextToDate(transactionDate); 

     if(transactionDate[0]):
         AmexcustomerTransactiondate=ConvertTextToDate(transactionDate[1]); #  calling function to convert text date to digital date format -transaction date
    
     else:
         AmexcustomerTransactiondate=transactionDate[1]; 
     AmexcustomerTransactionAmount=TransactonAmount; # transaction amount
     AmexcustomerCardNumber=CardDetails[1] # card details
     Amexcustomer=[AmexcustomerFName,AmexcustomerLName,AmexcustomerMName,AmexcustomerTitle,AmexcustomerTransactiondate,AmexcustomerTransactionAmount,AmexcustomerCardNumber]
     AmexcardCustomerList.append(Amexcustomer) # add customer details to holder list which nothing but list of list
     #print(CardDetails)

 elif(CardDetails[0]=='Mastercard'):
     Mastercardcustomer=[]
     MastercardcustomerFName=CustomerName[0] # customer fname 
     MastercardcustomerLName=CustomerName[1] # customer lname
     MastercardcustomerMName=CustomerName[2] # customer optional middle name
     MastercardcustomerTitle=CustomerName[3] # customer title
     if(transactionDate[0]):
      MastercardcustomerTransactiondate=ConvertTextToDate(transactionDate[1]); #  calling function to convert text date to digital date format -transaction date
     else:
      MastercardcustomerTransactiondate=transactionDate[1]; 
     MastercardcustomerTransactionAmount=TransactonAmount; # transaction amount
     MastercardcustomerCardNumber=CardDetails[1] # card details
     Mastercardcustomer=[MastercardcustomerFName,MastercardcustomerLName,MastercardcustomerMName,MastercardcustomerTitle,MastercardcustomerTransactiondate,MastercardcustomerTransactionAmount,MastercardcustomerCardNumber]
     MastercardCustomerList.append(Mastercardcustomer)  # add customer details to holder list which nothing but list of list
     #print(CardDetails)

 elif(CardDetails[0]=='VisaCard'):
    VisaCardcustomer=[]
    VisaCardcustomerFName=CustomerName[0] # customer fname 
    VisaCardcustomerLName=CustomerName[1] # customer lname
    VisaCardcustomerMName=CustomerName[2] # customer optional middle name
    VisaCardcustomerTitle=CustomerName[3] # customer title
    if(transactionDate[0]):
     VisaCardcustomerTransactiondate=ConvertTextToDate(transactionDate[1]); #  calling function to convert text date to digital date format -transaction date
    else:
      VisaCardcustomerTransactiondate=transactionDate[1]; 
    VisaCardcustomerTransactionAmount=TransactonAmount; # transaction amount
    VisaCardcustomerCardNumber=CardDetails[1] # card details
    VisaCardcustomer=[VisaCardcustomerFName,VisaCardcustomerLName,VisaCardcustomerMName,VisaCardcustomerTitle, VisaCardcustomerTransactiondate,VisaCardcustomerTransactionAmount,VisaCardcustomerCardNumber]
    VisaCardCustomerList.append(VisaCardcustomer) # add customer details to holder list which nothing but list of list

 #else:
     #print('Invalid Record',TransactionRecord)


print('********American Express card holder details******')
print('{0}  {1}  {2}  {3}  {4}  {5} {6}'.format('FName', 'LName','MName','Title','TDate','TAmount','CreditCardNumber'))

SortedAmexCardCustomerList=SortListBasedonDate(AmexcardCustomerList)   # sorting AMEX customer based on  last name , transaction amount ,transaction date 
for customer in SortedAmexCardCustomerList:
 print('{0}  {1}  {2}  {3}  {4}  {5} {6}'.format(customer[0], customer[1],customer[2],customer[3],customer[4],customer[5],customer[6]))

 
SortedMasterCardCustomerList=SortListBasedonDate(MastercardCustomerList)   # sorting Master card customer based on  last name , transaction amount ,transaction date 
print("\n")
print('********Master card holder details******')
print('{0}  {1}  {2}  {3}  {4}  {5} {6}'.format('FName', 'LName','MName','Title','TDate','TAmount','CreditCardNumber'))
for customer in SortedMasterCardCustomerList:
 print('{0}  {1}  {2}  {3}  {4}  {5} {6}'.format(customer[0], customer[1],customer[2],customer[3],customer[4],customer[5],customer[6]))

SortedVisaCardCustomerList=SortListBasedonDate(VisaCardCustomerList)   # sorting Visa customer based on  last name , transaction amount ,transaction date 
print("\n")
print('********Visa card holder details******')
print('{0}  {1}  {2}  {3}  {4}  {5} {6}'.format('FName', 'LName','MName','Title','TDate','TAmount','CreditCardNumber'))
for customer in SortedVisaCardCustomerList:
 print('{0}  {1}  {2}  {3}  {4}  {5} {6}'.format(customer[0], customer[1],customer[2],customer[3],customer[4],customer[5],customer[6]))
