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
@Table(name = "state")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "State.findAll", query = "SELECT s FROM State s"),
    @NamedQuery(name = "State.findByStateID", query = "SELECT s FROM State s WHERE s.stateID = :stateID"),
    @NamedQuery(name = "State.findByStateName", query = "SELECT s FROM State s WHERE s.stateName = :stateName")})
public class State implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "StateID")
    private Integer stateID;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 45)
    @Column(name = "StateName")
    private String stateName;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "state")
    private Collection<Venue> venueCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "stateName")
    private Collection<City> cityCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "state")
    private Collection<Review> reviewCollection;
    @JoinColumn(name = "CountryID", referencedColumnName = "countryID")
    @ManyToOne(optional = false)
    private Country countryID;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "state")
    private Collection<Users> usersCollection;

    public State() {
    }

    public State(Integer stateID) {
        this.stateID = stateID;
    }

    public State(Integer stateID, String stateName) {
        this.stateID = stateID;
        this.stateName = stateName;
    }

    public Integer getStateID() {
        return stateID;
    }

    public void setStateID(Integer stateID) {
        this.stateID = stateID;
    }

    public String getStateName() {
        return stateName;
    }

    public void setStateName(String stateName) {
        this.stateName = stateName;
    }

    @XmlTransient
    public Collection<Venue> getVenueCollection() {
        return venueCollection;
    }

    public void setVenueCollection(Collection<Venue> venueCollection) {
        this.venueCollection = venueCollection;
    }

    @XmlTransient
    public Collection<City> getCityCollection() {
        return cityCollection;
    }

    public void setCityCollection(Collection<City> cityCollection) {
        this.cityCollection = cityCollection;
    }

    @XmlTransient
    public Collection<Review> getReviewCollection() {
        return reviewCollection;
    }

    public void setReviewCollection(Collection<Review> reviewCollection) {
        this.reviewCollection = reviewCollection;
    }

    public Country getCountryID() {
        return countryID;
    }

    public void setCountryID(Country countryID) {
        this.countryID = countryID;
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
        hash += (stateID != null ? stateID.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof State)) {
            return false;
        }
        State other = (State) object;
        if ((this.stateID == null && other.stateID != null) || (this.stateID != null && !this.stateID.equals(other.stateID))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "jpa.entities.State[ stateID=" + stateID + " ]";
    }
    
}
