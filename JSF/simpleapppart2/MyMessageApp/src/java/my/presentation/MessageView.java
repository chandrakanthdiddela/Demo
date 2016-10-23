/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.presentation;

import boundry.MessageFacade;
import entities.Message;
import entities.Messagebeancount;
import java.util.List;
import javax.ejb.EJB;
import javax.inject.Named;
import javax.enterprise.context.RequestScoped;
import javax.faces.context.FacesContext;
import javax.inject.Inject;


/**
 *
 * @author chandrakanth diddela
 */
@Named(value = "MessageView")
@RequestScoped
public class MessageView {

    @EJB
    private MessageFacade messageFacade;
    private Message message;
    
   @Inject
    private Messagebeancount mysessionbean1;

    /**
     * Creates a new instance of MessageView
     */
    public MessageView() {
        this.message = new Message();
    }
    public Message getMessage() {
       return message;
    }
    public int getNumberOfMessages(){
         
       return messageFacade.findAll().size();
    }
     public String postMessage(){
         System.out.println("in post message");
       this.messageFacade.create(message);
       return "thenext";
    }

     public String getLastMessage(){
           List<Message> mess2=messageFacade.findAll();
          return  mess2.get(mess2.size()-1).getMessage();
     }
 
     public List<Message> getAllMessages(){
         List<Message> mess2=messageFacade.findAll();
         return mess2;
     }
     

     public String sessioncounter()
     {
         int count=mysessionbean1.sessionmessagecount();
        
         String lstrcount=Integer.toString(count);
         System.out.println("current session counter value" + lstrcount);
        
         
         return lstrcount;
     }
    
}
