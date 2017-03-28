/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.Bean;

import javax.inject.Named;
import javax.enterprise.context.SessionScoped;
import java.io.Serializable;
import javax.faces.context.FacesContext;
import jpa.entities.Users;

/**
 *
 * @author chandrakanth
 */
@Named(value = "userManager")
@SessionScoped
public class UserManager implements Serializable {

     private Users selected;
    /**
     * Creates a new instance of UserManager
     */
    public UserManager() {
    }
    
    
    public String logout() {
       // FacesContext.getCurrentInstance().getExternalContext().invalidateSession();
        return "/login.xhtml";
    }
}
