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
import jpa.entities.Review;
import jsf.ReviewController;

/**
 *
 * @author Lamya
 */
@Named(value = "dtFilterViewReview")
@ViewScoped
public class dtFilterViewReview implements Serializable{

    /**
     * Creates a new instance of dtFilterViewReview
     */
    public dtFilterViewReview() {
    }
    
    
      private List<Review> reviews;
     
    private List<Review> filteredreviews;
    
    @ManagedProperty("#{EventController}")
    private ReviewController service;
 
    @PersistenceContext
    public void init() {
        reviews = service.getItems();
    }

    public List<Review> getReviews() {
        return reviews;
    }

    public void setReviews(List<Review> reviews) {
        this.reviews = reviews;
    }

    public List<Review> getFilteredreviews() {
        return filteredreviews;
    }

    public void setFilteredreviews(List<Review> filteredreviews) {
        this.filteredreviews = filteredreviews;
    }

    public ReviewController getService() {
        return service;
    }

    public void setService(ReviewController service) {
        this.service = service;
    }
    
    
    
}
