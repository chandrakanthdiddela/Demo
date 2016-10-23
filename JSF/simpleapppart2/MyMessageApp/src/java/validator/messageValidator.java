/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package validator;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import javax.faces.application.FacesMessage;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.validator.FacesValidator;
import javax.faces.validator.Validator;
import javax.faces.validator.ValidatorException;

/**
 *
 * @author chandrakanth diddela
 */
@FacesValidator("messageValidator")
public class messageValidator implements Validator {

List<String> listbadwords = Arrays.asList("darn","dart","heck","fudge","point");


    @Override
    public void validate(FacesContext context, UIComponent component, Object value) throws ValidatorException {
        
        String lstrmessage= (String)value;

 for (String element : listbadwords) {
     
         String el = lstrmessage.toLowerCase();
        CharSequence cs = el;
         if(element.contains(cs) )
         {
             System.out.println(element);
             throw new ValidatorException(new FacesMessage("it is naughty word..please use another word"));
          }
    }
    }
    
}
