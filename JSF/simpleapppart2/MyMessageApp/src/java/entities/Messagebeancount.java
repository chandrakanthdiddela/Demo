/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entities;

import javax.inject.Named;
import javax.enterprise.context.SessionScoped;
import java.io.Serializable;
import java.util.Arrays;
import java.util.List;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.validator.ValidatorException;

/**
 *
 * @author chandrakanth diddela
 */
@ManagedBean(name = "messagebeancount")
@SessionScoped
public class Messagebeancount implements Serializable {

    /**
     * Creates a new instance of Messagebeancount
     */
    private int count=0;
    private int naughtycount=0;
    public Messagebeancount() {
    }
    public int sessionmessagecount()
    {
        count=count+1;
        //NaughtyMe
        return count;
    }
    
    public int Naughtymessagecount(String lstrmessage)
    {
        List<String> listbadwords = Arrays.asList("darn","dart","heck","fudge","point");
        for (String element : listbadwords) {
     
         String el = lstrmessage.toLowerCase();
        CharSequence cs = el;
         if(element.contains(cs) )
         {
             System.out.println(element);
            naughtycount=naughtycount+1;
          }
    }
        
        //naughtycount=naughtycount+1;
        return naughtycount;
    }
}
