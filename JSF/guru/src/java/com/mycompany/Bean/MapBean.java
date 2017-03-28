/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.Bean;

import javax.inject.Named;
import javax.enterprise.context.RequestScoped;

/**
 *
 * @author chandrakanth
 */
@Named(value = "mapBean")
@RequestScoped
public class MapBean {

    /**
     * Creates a new instance of MapBean
     */
    public MapBean() {
    }
    
    private int latitude;
    private int longitude;
    
    public String insert()
    {
        
        return  "32.78" + "," + "-117.00";
    }

    /**
     * @return the latitude
     */
    public int getLatitude() {
        return latitude;
    }

    /**
     * @param latitude the latitude to set
     */
    public void setLatitude(int latitude) {
        this.latitude = latitude;
    }

    /**
     * @return the longitude
     */
    public int getLongitude() {
        return longitude;
    }

    /**
     * @param longitude the longitude to set
     */
    public void setLongitude(int longitude) {
        this.longitude = longitude;
    }
    
    public String  setcordinates()
    {
        int x=getLatitude();
        int y= getLongitude();
        
        return x + "," + y;
                
        
    }
    
}
