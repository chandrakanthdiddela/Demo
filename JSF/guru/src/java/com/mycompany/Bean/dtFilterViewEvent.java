/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.Bean;

import java.io.Serializable;
import java.util.List;
import javax.faces.bean.ManagedProperty;
import javax.inject.Named;
import javax.faces.view.ViewScoped;
import javax.persistence.PersistenceContext;
import jpa.entities.Event;
import jsf.EventController;

/**
 *
 * @author Lamya
 */
@Named(value = "dtFilterViewEvent")
@ViewScoped
public class dtFilterViewEvent implements Serializable{

    /**
     * Creates a new instance of dtFilterViewEvent
     */
    public dtFilterViewEvent() {
    }
       private List<Event> events;
     
    private List<Event> filteredvenues;
    
    @ManagedProperty("#{EventController}")
    private EventController service;
 
    @PersistenceContext
    public void init() {
        events = service.getItems();
    }

    public List<Event> getEvents() {
        return events;
    }

    public void setEvents(List<Event> events) {
        this.events = events;
    }

    public List<Event> getFilteredvenues() {
        return filteredvenues;
    }

    public void setFilteredvenues(List<Event> filteredvenues) {
        this.filteredvenues = filteredvenues;
    }

    public EventController getService() {
        return service;
    }

    public void setService(EventController service) {
        this.service = service;
    }
    
    
    
}
