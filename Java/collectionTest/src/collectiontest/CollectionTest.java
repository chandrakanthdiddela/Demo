/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package collectiontest;

import java.util.Collection;
import java.util.HashSet;
import java.util.Iterator;

/**
 *
 * @author Varnith
 */
public class CollectionTest {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Collection<Object> hs;
        hs=new HashSet();
       //  HashSet hs = new HashSet();
      // add elements to the hash set
      hs.add("B");
      hs.add("A");
      hs.add("D");
      hs.add("E");
      hs.add("C");
      hs.add("F");
        Iterator<Object> obj = hs.iterator();
      while(obj.hasNext()){
          String value=(String)obj.next();
          if(value.equals("D"))
          {
            System.out.println(" Iterating over HashSet in Java current object: " + value);
          }
      }
     // for(O)
    }
    
}
