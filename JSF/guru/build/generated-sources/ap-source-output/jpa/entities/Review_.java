package jpa.entities;

import java.util.Date;
import javax.annotation.Generated;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;
import jpa.entities.City;
import jpa.entities.Country;
import jpa.entities.Event;
import jpa.entities.State;
import jpa.entities.Users;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-12-10T15:13:31")
@StaticMetamodel(Review.class)
public class Review_ { 

    public static volatile SingularAttribute<Review, Date> date;
    public static volatile SingularAttribute<Review, Country> country;
    public static volatile SingularAttribute<Review, City> city;
    public static volatile SingularAttribute<Review, Integer> rating;
    public static volatile SingularAttribute<Review, String> description;
    public static volatile SingularAttribute<Review, State> state;
    public static volatile SingularAttribute<Review, Event> event;
    public static volatile SingularAttribute<Review, Integer> reviewid;
    public static volatile SingularAttribute<Review, Users> user;

}