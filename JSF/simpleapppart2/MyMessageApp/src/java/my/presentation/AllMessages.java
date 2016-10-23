/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package my.presentation;

import entities.Message;
import java.util.List;
import javax.inject.Named;
import javax.enterprise.context.RequestScoped;
import javax.inject.Inject;

/**
 *
 * @author chandrakanth diddela
 */
@Named(value = "allMessages")
@RequestScoped
public class AllMessages {

    /**
     * Creates a new instance of AllMessages
     */
    public AllMessages() {
    }
    
    @Inject
    private MessageView message1;
    
    public List<Message> myMessages(){
        return message1.getAllMessages();
        
    }
}
