/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jpa.entities;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author chandrakanth
 */
@Entity
@Table(name = "review")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Review.findAll", query = "SELECT r FROM Review r"),
    @NamedQuery(name = "Review.findByReviewid", query = "SELECT r FROM Review r WHERE r.reviewid = :reviewid"),
    @NamedQuery(name = "Review.findByDescription", query = "SELECT r FROM Review r WHERE r.description = :description"),
    @NamedQuery(name = "Review.findByDate", query = "SELECT r FROM Review r WHERE r.date = :date"),
    @NamedQuery(name = "Review.findByRating", query = "SELECT r FROM Review r WHERE r.rating = :rating")})
public class Review implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "reviewid")
    private Integer reviewid;
    @Basic(optional = false)
    @NotNull
    @Size(min = 1, max = 1000)
    @Column(name = "Description")
    private String description;
    @Basic(optional = false)
    @NotNull
    @Column(name = "Date")
    @Temporal(TemporalType.DATE)
    private Date date;
    @Basic(optional = false)
    @NotNull
    @Column(name = "Rating")
    private int rating;
    @JoinColumn(name = "City", referencedColumnName = "cityID")
    @ManyToOne(optional = false)
    private City city;
    @JoinColumn(name = "country", referencedColumnName = "countryID")
    @ManyToOne(optional = false)
    private Country country;
    @JoinColumn(name = "Event", referencedColumnName = "eventID")
    @ManyToOne(optional = false)
    private Event event;
    @JoinColumn(name = "State", referencedColumnName = "StateID")
    @ManyToOne(optional = false)
    private State state;
    @JoinColumn(name = "user", referencedColumnName = "userid")
    @ManyToOne(optional = false)
    private Users user;

    public Review() {
    }

    public Review(Integer reviewid) {
        this.reviewid = reviewid;
    }

    public Review(Integer reviewid, String description, Date date, int rating) {
        this.reviewid = reviewid;
        this.description = description;
        this.date = date;
        this.rating = rating;
    }

    public Integer getReviewid() {
        return reviewid;
    }

    public void setReviewid(Integer reviewid) {
        this.reviewid = reviewid;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
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

    public Event getEvent() {
        return event;
    }

    public void setEvent(Event event) {
        this.event = event;
    }

    public State getState() {
        return state;
    }

    public void setState(State state) {
        this.state = state;
    }

    public Users getUser() {
        return user;
    }

    public void setUser(Users user) {
        this.user = user;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (reviewid != null ? reviewid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Review)) {
            return false;
        }
        Review other = (Review) object;
        if ((this.reviewid == null && other.reviewid != null) || (this.reviewid != null && !this.reviewid.equals(other.reviewid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "jpa.entities.Review[ reviewid=" + reviewid + " ]";
    }
    
}
