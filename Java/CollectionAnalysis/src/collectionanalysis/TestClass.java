package collectionanalysis;


import java.util.Date;
import java.util.Random;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Varnith
 */
public class TestClass {
     private static Random r;
	   private Date my_date; 
           //public static int lintvalue=1;
	   public TestClass () 
           {
               //lintvalue=lintvalue+1;
	      my_date = new Date();
	      long l = my_date.getTime();
	      int i = (int) (l/1000/60/60/24);
	      if (r==null)
                  r = new Random();
	      i = r.nextInt(i);
	      l = ((long) i)*24*60*60*1000;      
	      my_date.setTime(l);
	   }
           
           
	      
 
    
    
}
