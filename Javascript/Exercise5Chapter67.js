
	function Validatephonenumber()
    {
	var inputtxt = document.getElementById("phonenumber");
    var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
       
        if(inputtxt.value.length>0)
        {
             if(inputtxt.value.match(phoneno)) 
             {
                  return true;
             }
            else 
             {
               alert("Please make a Phone entry");
                return false;
              }
        }
        
        else
        {
            alert("please enter a value in provided text box");
        }
 
	}
    
    
function ValidateEmailID()
    {
        var inputtxt = document.getElementById("EmailID");
      
        var Emailpattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        
         if(inputtxt.value.length>0)
        {
             if(inputtxt.value.match(Emailpattern)) 
             {
                  return true;
             }
            else 
             {
               alert("Please make an eMail entry");
                return false;
              }
        }
        
        else
        {
            alert("please enter a value in provided text box");
        }
 
       
        //alert(" Email ID not valid");
    }

    
    function ValdiatePostalID()
    {
     var inputtxt = document.getElementById("pcode");
    var isValidZip = /(^\d{5}$)|(^\d{5}-\d{4}$)/;
          if(inputtxt.value.length>0)
        {
             if(inputtxt.value.match(isValidZip)) 
             {
                  return true;
             }
            else 
             {
               alert("Please make an Postal entry");
                return false;
              }
        }
        
        else
        {
            alert("please enter a value in provided text box");
        }
 
        
    }
