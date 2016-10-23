/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Factorial_Test;

import java.math.BigDecimal;
import java.util.Scanner;
import java.text.SimpleDateFormat;
import java.util.Date;
/**
 *
 * @author IAlsmadi
 */
public class Factorial_Test {
    
    private static Long secondsBetween(Date first, Date second){
    return (first.getTime() - second.getTime())/1000;
}
    static void testNoRecursion(){
         String str, another = "y";
      int left, right;
      Scanner s = new Scanner(System.in);
      //Date first= new Date();
      long t1 = System.nanoTime();
      while (another.equalsIgnoreCase("y")) // allows y or Y
      {
         System.out.println ("Enter a potential factorial:");
         str = s.nextLine();
        
         BigDecimal result= new BigDecimal(str);
          BigDecimal result1=NoRecursion.factorial(result);
         System.out.println("Using no recursion...."+result1);
        // Date second = new Date();
         long t2 = System.nanoTime();
         long elapsedTimeInSeconds = (t2 - t1) / 1000000000;
      System.out.println("Total time...." + elapsedTimeInSeconds);
      }
      
    }
     static void testRecursion(){
         String str, another = "y";
      int left, right;
      Scanner s = new Scanner(System.in);
      //Date first= new Date();
      long t1 = System.nanoTime();
      while (another.equalsIgnoreCase("y")) // allows y or Y
      {
         System.out.println ("Enter a potential factorial:");
         str = s.nextLine();
        
         BigDecimal result= new BigDecimal(str);
          BigDecimal result1=Recursion.factorial(result);
         System.out.println("Using recursion...."+result1);
        // Date second = new Date();
         long t2 = System.nanoTime();
         long elapsedTimeInSeconds = (t2 - t1) / 1000000000;
      System.out.println("Total time...." + elapsedTimeInSeconds);
      }
     }
     
     static void testTailRecursion(){
         String str, another = "y";
      int left, right;
      Scanner s = new Scanner(System.in);
      //Date first= new Date();
      long t1 = System.nanoTime();
      while (another.equalsIgnoreCase("y")) // allows y or Y
      {
         System.out.println ("Enter a potential factorial:");
         str = s.nextLine();
        
         BigDecimal result= new BigDecimal(str);
          BigDecimal result1=TailRecursion.factorial(result);
         System.out.println("Using Tail recursion...."+result1);
        // Date second = new Date();
         long t2 = System.nanoTime();
         long elapsedTimeInSeconds = (t2 - t1) / 1000000000;
      System.out.println("Total time...." + elapsedTimeInSeconds);
      }
     }
     public static void main (String[] args)
   {
     testNoRecursion();
     testRecursion();
     testTailRecursion();
   }
}
