package jpa.entities;

import javax.annotation.Generated;
import javax.persistence.metamodel.CollectionAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;
import jpa.entities.Review;
import jpa.entities.State;
import jpa.entities.Users;
import jpa.entities.Venue;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-12-10T15:13:31")
@StaticMetamodel(Country.class)
public class Country_ { 

    public static volatile SingularAttribute<Country, String> countrycode;
    public static volatile CollectionAttribute<Country, State> stateCollection;
    public static volatile SingularAttribute<Country, String> countryName;
    public static volatile CollectionAttribute<Country, Users> usersCollection;
    public static volatile CollectionAttribute<Country, Review> reviewCollection;
    public static volatile SingularAttribute<Country, Integer> countryID;
    public static volatile CollectionAttribute<Country, Venue> venueCollection;

}