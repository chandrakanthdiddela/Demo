/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package collectionanalysis;

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

/**
 *
 * @author Varnith
 */
public class HelperMain {
    
    
    public static Object[] getObjects( int parraySize) 
    {
      //int max_l = 50000;
      Object[] arr = new Object[parraySize];
      for (int l=0; l<parraySize; l++) {
          
         arr[l] = l;
      // arr[l] = new MyDate(); // with element.compareTo() implemented
      }
      return arr;
    }
    
    public static void AnalayseCreation(Object[] arr)
    {
          
int searchkeyindex= (int)arr.length/2;
      Collection<Object> col;
      System.out.println("Collection Class, Number of Objects, Time");
      col = new HashSet<Object>();
      testCollection(arr,col);
      SearchTime(col,arr[searchkeyindex]);
      col = new LinkedHashSet<Object>();
      testCollection(arr,col);
    SearchTime(col,arr[searchkeyindex]);
      col = new Vector<Object>();
      testCollection(arr,col);
      SearchTime(col,arr[searchkeyindex]);
      col = new ArrayList<Object>();
      testCollection(arr,col);
      SearchTime(col,arr[searchkeyindex]);
      col = new LinkedList<Object>();
      testCollection(arr,col);
      SearchTime(col,arr[searchkeyindex]);

      Map<Object, Object> dic; 
      System.out.println("Map Class, Number of Objects, Time");
      dic = new TreeMap<Object, Object>();
      testMap(arr,dic);
      LoopingMaps(dic,arr[searchkeyindex]);
      dic = new HashMap<Object, Object>();
      testMap(arr,dic);
      LoopingMaps(dic,arr[searchkeyindex]);
      dic = new IdentityHashMap<Object, Object>();
      testMap(arr,dic);
      LoopingMaps(dic,arr[searchkeyindex]);
      dic = new WeakHashMap<Object, Object>();
      testMap(arr,dic);
      LoopingMaps(dic,arr[searchkeyindex]);
      dic = new Hashtable<Object, Object>();
      testMap(arr,dic);
      LoopingMaps(dic,arr[searchkeyindex]);
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
   
   private static void SearchTime( Collection<Object> pcol ,Object psearchvalue)
   {
       long time1=System.currentTimeMillis();
    Iterator<Object> obj = pcol.iterator();
   // Iterator<TestClass> obj1 = pcol.iterator();
      while(obj.hasNext())
      {
         // obj.next();
         Object value=obj.next();
          if(value.equals(psearchvalue))
          {
            System.out.println("object is found and its value is  " + value);
            break;
          }
          
          //lobjtest.
            //System.out.println(" Iterating over HashSet in Java current object: " + obj.next());
      }
        long time2=System.currentTimeMillis();
        long time3=time2-time1;
        System.out.println("Time taken by " + pcol.getClass().getName()+" to find object with collection size " + pcol.size() +" " +" is "+ time3);
   }
   
   private static void LoopingMaps( Map<Object, Object> pdict,Object psearchvalue )
   {
       long time1=System.currentTimeMillis();
       Iterator<Object> it = pdict.keySet().iterator();
    while (it.hasNext()) {
        
        Object lobjkey = it.next();
        Object lobjValue=pdict.get(lobjkey);
          if(lobjValue.equals(psearchvalue))
          {
            System.out.println("object is found and its value is  " + lobjValue);
            break;
          }
       
    }
    
      
        long time2=System.currentTimeMillis();
        long time3=time2-time1;
        System.out.println("Time taken by " + pdict.getClass().getName()+" to find object with collection size " + pdict.size() +" " +" is "+ time3);
        
   }
}
