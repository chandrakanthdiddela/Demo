package jpa.entities;

import javax.annotation.Generated;
import javax.persistence.metamodel.CollectionAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;
import jpa.entities.City;
import jpa.entities.Country;
import jpa.entities.Event;
import jpa.entities.State;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-12-10T15:13:31")
@StaticMetamodel(Venue.class)
public class Venue_ { 

    public static volatile SingularAttribute<Venue, Country> country;
    public static volatile SingularAttribute<Venue, String> phoneNumber;
    public static volatile CollectionAttribute<Venue, Event> eventCollection;
    public static volatile SingularAttribute<Venue, String> streetAddress;
    public static volatile SingularAttribute<Venue, City> city;
    public static volatile SingularAttribute<Venue, Integer> venueID;
    public static volatile SingularAttribute<Venue, String> name;
    public static volatile SingularAttribute<Venue, State> state;

}