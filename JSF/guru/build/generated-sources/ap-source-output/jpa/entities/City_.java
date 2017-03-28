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
@StaticMetamodel(City.class)
public class City_ { 

    public static volatile SingularAttribute<City, State> stateName;
    public static volatile SingularAttribute<City, Double> latitude;
    public static volatile SingularAttribute<City, String> name;
    public static volatile SingularAttribute<City, Integer> cityID;
    public static volatile SingularAttribute<City, Integer> countryName;
    public static volatile CollectionAttribute<City, Users> usersCollection;
    public static volatile CollectionAttribute<City, Review> reviewCollection;
    public static volatile SingularAttribute<City, Double> longitude;
    public static volatile CollectionAttribute<City, Venue> venueCollection;

}