package testcollection;


import java.util.Date;
import java.util.Random;


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
