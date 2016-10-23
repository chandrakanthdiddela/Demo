/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package finalexam;

import static finalexam.Chapter18.getSize;
import java.io.File;
import java.util.Scanner;

/**
 *
 * @author Varnith
 */


public class FinalExam {
    static int  count=0;
    public static int repeat(int base, int exp) {
 if (exp == 1) {
  return base;
 }

 return base * repeat(base, exp - 1);
}
     public static long factorial(int n) 
     {
 if (n == 0)
{// Base case
    count=count+1;
return 1;
}
else
{
    count=count+1;
 return n * factorial(n - 1); // Recursive call
 }
     }

     
     public static int xMethod(int n) {
if (n == 1)
return 1;
else
return n + xMethod(n - 1);
}
     
     
   public static void xMethod1(int n) 
   {
if (n > 0) {
System.out.print(n % 10);
xMethod1(n / 10);
}
}
    /**
     * @param args the command line arguments
//     */
//    public static void main(String[] args) 
//    {
//        System.out.println(repeat(5, 2
//        ));
//        //xMethod1(1234567);
//        //System.out.println("Sum is " + xMethod1(1234567));
//        // TODO code application logic here
////       
////        Scanner input = new Scanner(System.in);
//// System.out.print("Enter a nonnegative integer: ");
//// int n = input.nextInt();
////
//// // Display factorial
//// System.out.println("Factorial of " + n + " is " + factorial(n));
//// System.out.println("count of " + n + " is " + FinalExam.count);
//    }
   
   public static void main(String[] args) {
//xMethod5(1234567);

Chapter18 lobjChapter18 = new Chapter18();
System.out.print("Enter a directory or a file: ");
Scanner input = new Scanner(System.in);
 String directory = input.nextLine();

// Display the size
 System.out.println(getSize(new File(directory)) + " bytes");


//lobjChapter18.isPalindrome("abcba");
      // System.out.println("hello");
//lobjChapter18.isPalindrome("abdxcxdba");
      // System.out.println("count value"+ lobjChapter18.);
}
//public static void xMethod2(int n) {
//if (n > 0) {
//    xMethod2(n - 1);
//    
//System.out.print(n + " ");
//
//}
//}

public static void xMethod5(double n) {
if (n != 0) {
System.out.println(n);
xMethod5(n / 10);
}
   
}
}
