/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jpa.entities;

import java.io.Serializable;
import java.util.Collection;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author chandrakanth
 */
@Entity
@Table(name = "city")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "City.findAll", query = "SELECT c FROM City c"),
    @NamedQuery(name = "City.findByCityID", query = "SELECT c FROM City c WHERE c.cityID = :cityID"),
    @NamedQuery(name = "City.findByLatitude", query = "SELECT c FROM City c WHERE c.latitude = :latitude"),
    @NamedQuery(name = "City.findByLongitude", query = "SELECT c FROM City c WHERE c.longitude = :longitude"),
    @NamedQuery(name = "City.findByName", query = "SELECT c FROM City c WHERE c.name = :name"),
    @NamedQuery(name = "City.findByCountryName", query = "SELECT c FROM City c WHERE c.countryName = :countryName")})
public class City implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "cityID")
    private Integer cityID;
    @Basic(optional = false)
    @NotNull
    @Column(name = "latitude")
    private double latitude;
    @Basic(optional = false)
    @NotNull
    @Column(name = "longitude")
    private double longitude;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 45)
    @Column(name = "Name")
    private String name;
    @Basic(optional = false)
    @NotNull
    @Column(name = "CountryName")
    private int countryName;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "city")
    private Collection<Venue> venueCollection;
    @JoinColumn(name = "StateName", referencedColumnName = "StateID")
    @ManyToOne(optional = false)
    private State stateName;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "city")
    private Collection<Review> reviewCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "city")
    private Collection<Users> usersCollection;

    public City() {
    }

    public City(Integer cityID) {
        this.cityID = cityID;
    }

    public City(Integer cityID, double latitude, double longitude, String name, int countryName) {
        this.cityID = cityID;
        this.latitude = latitude;
        this.longitude = longitude;
        this.name = name;
        this.countryName = countryName;
    }

    public Integer getCityID() {
        return cityID;
    }

    public void setCityID(Integer cityID) {
        this.cityID = cityID;
    }

    public double getLatitude() {
        return latitude;
    }

    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    public double getLongitude() {
        return longitude;
    }

    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getCountryName() {
        return countryName;
    }

    public void setCountryName(int countryName) {
        this.countryName = countryName;
    }

    @XmlTransient
    public Collection<Venue> getVenueCollection() {
        return venueCollection;
    }

    public void setVenueCollection(Collection<Venue> venueCollection) {
        this.venueCollection = venueCollection;
    }

    public State getStateName() {
        return stateName;
    }

    public void setStateName(State stateName) {
        this.stateName = stateName;
    }

    @XmlTransient
    public Collection<Review> getReviewCollection() {
        return reviewCollection;
    }

    public void setReviewCollection(Collection<Review> reviewCollection) {
        this.reviewCollection = reviewCollection;
    }

    @XmlTransient
    public Collection<Users> getUsersCollection() {
        return usersCollection;
    }

    public void setUsersCollection(Collection<Users> usersCollection) {
        this.usersCollection = usersCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (cityID != null ? cityID.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof City)) {
            return false;
        }
        City other = (City) object;
        if ((this.cityID == null && other.cityID != null) || (this.cityID != null && !this.cityID.equals(other.cityID))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "jpa.entities.City[ cityID=" + cityID + " ]";
    }
    
}
