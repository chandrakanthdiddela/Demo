package jpa.entities;

import java.util.Date;
import javax.annotation.Generated;
import javax.persistence.metamodel.CollectionAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;
import jpa.entities.City;
import jpa.entities.Country;
import jpa.entities.Event;
import jpa.entities.Eventattendance;
import jpa.entities.Review;
import jpa.entities.State;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-12-10T15:13:31")
@StaticMetamodel(Users.class)
public class Users_ { 

    public static volatile SingularAttribute<Users, String> lastName;
    public static volatile SingularAttribute<Users, Country> country;
    public static volatile CollectionAttribute<Users, Event> eventCollection;
    public static volatile SingularAttribute<Users, String> gender;
    public static volatile SingularAttribute<Users, City> city;
    public static volatile SingularAttribute<Users, String> userName;
    public static volatile SingularAttribute<Users, Integer> userid;
    public static volatile SingularAttribute<Users, Date> birthDate;
    public static volatile SingularAttribute<Users, String> firstName;
    public static volatile CollectionAttribute<Users, Eventattendance> eventattendanceCollection;
    public static volatile SingularAttribute<Users, String> password;
    public static volatile SingularAttribute<Users, String> phoneNumber;
    public static volatile SingularAttribute<Users, String> userType;
    public static volatile SingularAttribute<Users, State> state;
    public static volatile CollectionAttribute<Users, Review> reviewCollection;
    public static volatile SingularAttribute<Users, String> email;

}