/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jpa.entities;

import java.io.Serializable;
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
import javax.validation.constraints.NotNull;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author chandrakanth
 */
@Entity
@Table(name = "eventattendance")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Eventattendance.findAll", query = "SELECT e FROM Eventattendance e"),
    @NamedQuery(name = "Eventattendance.findByEventAttendanceid", query = "SELECT e FROM Eventattendance e WHERE e.eventAttendanceid = :eventAttendanceid"),
    @NamedQuery(name = "Eventattendance.findByRating", query = "SELECT e FROM Eventattendance e WHERE e.rating = :rating")})
public class Eventattendance implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "EventAttendanceid")
    private Integer eventAttendanceid;
    @Basic(optional = false)
    @NotNull
    @Column(name = "Rating")
    private int rating;
    @JoinColumn(name = "event", referencedColumnName = "eventID")
    @ManyToOne(optional = false)
    private Event event;
    @JoinColumn(name = "user", referencedColumnName = "userid")
    @ManyToOne(optional = false)
    private Users user;

    public Eventattendance() {
    }

    public Eventattendance(Integer eventAttendanceid) {
        this.eventAttendanceid = eventAttendanceid;
    }

    public Eventattendance(Integer eventAttendanceid, int rating) {
        this.eventAttendanceid = eventAttendanceid;
        this.rating = rating;
    }

    public Integer getEventAttendanceid() {
        return eventAttendanceid;
    }

    public void setEventAttendanceid(Integer eventAttendanceid) {
        this.eventAttendanceid = eventAttendanceid;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public Event getEvent() {
        return event;
    }

    public void setEvent(Event event) {
        this.event = event;
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
        hash += (eventAttendanceid != null ? eventAttendanceid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Eventattendance)) {
            return false;
        }
        Eventattendance other = (Eventattendance) object;
        if ((this.eventAttendanceid == null && other.eventAttendanceid != null) || (this.eventAttendanceid != null && !this.eventAttendanceid.equals(other.eventAttendanceid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "jpa.entities.Eventattendance[ eventAttendanceid=" + eventAttendanceid + " ]";
    }
    
}
