package jpa.entities;

import javax.annotation.Generated;
import javax.persistence.metamodel.CollectionAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;
import jpa.entities.City;
import jpa.entities.Country;
import jpa.entities.Review;
import jpa.entities.Users;
import jpa.entities.Venue;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-12-10T15:13:31")
@StaticMetamodel(State.class)
public class State_ { 

    public static volatile SingularAttribute<State, String> stateName;
    public static volatile SingularAttribute<State, Integer> stateID;
    public static volatile CollectionAttribute<State, City> cityCollection;
    public static volatile CollectionAttribute<State, Users> usersCollection;
    public static volatile CollectionAttribute<State, Review> reviewCollection;
    public static volatile SingularAttribute<State, Country> countryID;
    public static volatile CollectionAttribute<State, Venue> venueCollection;

}