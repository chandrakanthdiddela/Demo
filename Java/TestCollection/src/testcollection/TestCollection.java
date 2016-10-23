
package testcollection;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Hashtable;
import java.util.IdentityHashMap;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.LinkedList;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.Vector;
import java.util.WeakHashMap;


public class TestCollection {
      public static void main(String[] a) {
        Scanner lobjScanner = new Scanner(System.in);
        int input =lobjScanner.nextInt();
        Object[] arr = getObjects(input);
        int sk=(int)arr.length/4;
      Collection<Object> col;
      System.out.println("**********Collections***********");
      System.out.println();
      System.out.println("Collection, Number of Objects, Time");
      col = new HashSet<Object>();
      testCollection(arr,col);
      ReteriveFromCollection(col,arr[sk]);
      col = new LinkedHashSet<Object>();
      testCollection(arr,col);
    ReteriveFromCollection(col,arr[sk]);
      col = new Vector<Object>();
      testCollection(arr,col);
      ReteriveFromCollection(col,arr[sk]);
      col = new ArrayList<Object>();
      testCollection(arr,col);
      ReteriveFromCollection(col,arr[sk]);
      col = new LinkedList<Object>();
      testCollection(arr,col);
      ReteriveFromCollection(col,arr[sk]);

      Map<Object, Object> dic; 
      System.out.println("Map, Number of Objects, Time");
      dic = new TreeMap<Object, Object>();
      testMap(arr,dic);
      RetFromMaps(dic,arr[sk]);
      dic = new HashMap<Object, Object>();
      testMap(arr,dic);
      RetFromMaps(dic,arr[sk]);
      dic = new IdentityHashMap<Object, Object>();
      testMap(arr,dic);
      RetFromMaps(dic,arr[sk]);
      dic = new WeakHashMap<Object, Object>();
      testMap(arr,dic);
      RetFromMaps(dic,arr[sk]);
      dic = new Hashtable<Object, Object>();
      testMap(arr,dic);
      RetFromMaps(dic,arr[sk]);
   }
   
   
   
 
    public static Object[] getObjects( int parraySize) 
    {
      //int max_l = 50000;
      Object[] arr = new Object[parraySize];
      for (int l=0; l<parraySize; l++) {
          
         arr[l] = l;
    
      }
      return arr;
    }
   
   private static void testCollection(Object[] arr, 
		      Collection<Object> col) {
	   Date t1 = new Date();
		      for (int l=0; l<arr.length; l++) {
		      	// col.add(arr[l]);
                          col.add(l);
		      }
		      for (int l=0; l<arr.length; l++) {
		       	 boolean test=col.contains(arr[l]);
		       }
		      Date t2 = new Date();
		      System.out.println(col.getClass().getName()+", "+
		    	         arr.length+", "+(t2.getTime()-t1.getTime())); 
   }
   private static void testMap(Object[] arr, Map<Object, Object> col) {
	   Date t1 = new Date();
      for (int l=0; l<arr.length; l++) {
      	 col.put(new Integer(l), arr[l]);
      }
      
      for (int l=0; l<arr.length; l++) {
	       	 boolean test=col.containsValue(arr[l]);
	       }
      Date t2 = new Date();
      System.out.println(col.getClass().getName()+", "+
    	         arr.length+", "+(t2.getTime()-t1.getTime()));
      
   }
    private static void ReteriveFromCollection( Collection<Object> col ,Object searchvalue)
   {
       int t1=(int)System.currentTimeMillis();
    Iterator<Object> obj = col.iterator();
   
      while(obj.hasNext())
      {
         
         Object value=obj.next();
          if(value.equals(searchvalue))
          {
            System.out.println("Object Retrieved at:" + value);
            break;
          }
          
         
      }
        int t2=(int)System.currentTimeMillis();
        int t3=t2-t1;
        System.out.println("Time needed for " + col.getClass().getName()+" to find object with collection size " + col.size() +" " +" is "+ t3);
   }
   
   private static void RetFromMaps( Map<Object, Object> dict,Object searchvalue )
   {
       long t1=System.currentTimeMillis();
       Iterator<Object> it = dict.keySet().iterator();
    while (it.hasNext()) {
        
        Object key = it.next();
        Object Value=dict.get(key);
          if(Value.equals(searchvalue))
          {
            System.out.println("object is found and its value is  " +Value);
            break;
          }
       
    }
    
      
        long t2=System.currentTimeMillis();
        long t3=t2-t1;
        System.out.println("Time taken by " + dict.getClass().getName()+" to find object with collection size " + dict.size() +" " +" is "+ t3);
        
   }
   
}
    

