package jpa.entities;

import javax.annotation.Generated;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;
import jpa.entities.Event;
import jpa.entities.Users;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-12-10T15:13:31")
@StaticMetamodel(Eventattendance.class)
public class Eventattendance_ { 

    public static volatile SingularAttribute<Eventattendance, Integer> rating;
    public static volatile SingularAttribute<Eventattendance, Event> event;
    public static volatile SingularAttribute<Eventattendance, Integer> eventAttendanceid;
    public static volatile SingularAttribute<Eventattendance, Users> user;

}