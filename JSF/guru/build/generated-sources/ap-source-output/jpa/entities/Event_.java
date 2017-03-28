package jpa.entities;

import java.util.Date;
import javax.annotation.Generated;
import javax.persistence.metamodel.CollectionAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;
import jpa.entities.Eventattendance;
import jpa.entities.Review;
import jpa.entities.Users;
import jpa.entities.Venue;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-12-10T15:13:31")
@StaticMetamodel(Event.class)
public class Event_ { 

    public static volatile SingularAttribute<Event, Integer> eventID;
    public static volatile CollectionAttribute<Event, Eventattendance> eventattendanceCollection;
    public static volatile SingularAttribute<Event, Venue> venue;
    public static volatile SingularAttribute<Event, Date> endDate;
    public static volatile SingularAttribute<Event, Users> createdBy;
    public static volatile SingularAttribute<Event, String> description;
    public static volatile SingularAttribute<Event, String> eventType;
    public static volatile CollectionAttribute<Event, Review> reviewCollection;
    public static volatile SingularAttribute<Event, Date> startDate;

}