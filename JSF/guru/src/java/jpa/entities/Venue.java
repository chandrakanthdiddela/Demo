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
@Table(name = "venue")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Venue.findAll", query = "SELECT v FROM Venue v"),
    @NamedQuery(name = "Venue.findByVenueID", query = "SELECT v FROM Venue v WHERE v.venueID = :venueID"),
    @NamedQuery(name = "Venue.findByName", query = "SELECT v FROM Venue v WHERE v.name = :name"),
    @NamedQuery(name = "Venue.findByPhoneNumber", query = "SELECT v FROM Venue v WHERE v.phoneNumber = :phoneNumber"),
    @NamedQuery(name = "Venue.findByStreetAddress", query = "SELECT v FROM Venue v WHERE v.streetAddress = :streetAddress")})
public class Venue implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "VenueID")
    private Integer venueID;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 45)
    @Column(name = "Name")
    private String name;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 45)
    @Column(name = "PhoneNumber")
    private String phoneNumber;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 45)
    @Column(name = "StreetAddress")
    private String streetAddress;
    @JoinColumn(name = "city", referencedColumnName = "cityID")
    @ManyToOne(optional = false)
    private City city;
    @JoinColumn(name = "country", referencedColumnName = "countryID")
    @ManyToOne(optional = false)
    private Country country;
    @JoinColumn(name = "state", referencedColumnName = "StateID")
    @ManyToOne(optional = false)
    private State state;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "venue")
    private Collection<Event> eventCollection;

    public Venue() {
    }

    public Venue(Integer venueID) {
        this.venueID = venueID;
    }

    public Venue(Integer venueID, String name, String phoneNumber, String streetAddress) {
        this.venueID = venueID;
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.streetAddress = streetAddress;
    }

    public Integer getVenueID() {
        return venueID;
    }

    public void setVenueID(Integer venueID) {
        this.venueID = venueID;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getStreetAddress() {
        return streetAddress;
    }

    public void setStreetAddress(String streetAddress) {
        this.streetAddress = streetAddress;
    }

    public City getCity() {
        return city;
    }

    public void setCity(City city) {
        this.city = city;
    }

    public Country getCountry() {
        return country;
    }

    public void setCountry(Country country) {
        this.country = country;
    }

    public State getState() {
        return state;
    }

    public void setState(State state) {
        this.state = state;
    }

    @XmlTransient
    public Collection<Event> getEventCollection() {
        return eventCollection;
    }

    public void setEventCollection(Collection<Event> eventCollection) {
        this.eventCollection = eventCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (venueID != null ? venueID.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Venue)) {
            return false;
        }
        Venue other = (Venue) object;
        if ((this.venueID == null && other.venueID != null) || (this.venueID != null && !this.venueID.equals(other.venueID))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "jpa.entities.Venue[ venueID=" + venueID + " ]";
    }
    
}
