/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.Bean;


import java.io.Serializable;
import java.util.List;
import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedProperty;
import javax.inject.Named;
import javax.faces.view.ViewScoped;
import javax.persistence.PersistenceContext;
import jpa.entities.Venue;
import jsf.VenueController;

/**
 *
 * @author Lamya
 */
@Named(value = "dtFilterView")
@ViewScoped
public class dtFilterView implements Serializable{

    /**
     * Creates a new instance of dtFilterView
     */
    private List<Venue> venues;
     
    private List<Venue> filteredvenues;
    public dtFilterView() {
    }
    @ManagedProperty("#{VenueController}")
    private VenueController service;
 
    @PersistenceContext
    public void init() {
        venues = service.getItems();
    }
    
     public List getName() {
         List name=null;
         for(int i= 0; i<=service.getItems().size() ; i++){
             name.add(service.getItems().get(i).getName());
         }
        return name;
    }
      public List getId() {
         List id=null;
         for(int i= 0; i<=service.getItems().size() ; i++){
             id.add(service.getItems().get(i).getVenueID());
         }
        return id;
    }
       public List getAddress() {
         List address=null;
         for(int i= 0; i<=service.getItems().size() ; i++){
             address.add(service.getItems().get(i).getStreetAddress());
         }
        return address;
    }
        public List getPhoneNumber() {
         List phone=null;
         for(int i= 0; i<=service.getItems().size() ; i++){
             phone.add(service.getItems().get(i).getPhoneNumber());
         }
        return phone;
        }

    public List<Venue> getVenues() {
        return venues;
    }

    public void setVenues(List<Venue> venues) {
        this.venues = venues;
    }

    public List<Venue> getFilteredvenues() {
        return filteredvenues;
    }

    public void setFilteredvenues(List<Venue> filteredvenues) {
        this.filteredvenues = filteredvenues;
    }
        
         public void setService( VenueController service) {
        this.service = service;
    }
        
        
}


     
  
