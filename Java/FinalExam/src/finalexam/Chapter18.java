/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package finalexam;

import java.io.File;

/**
 *
 * @author Varnith
 */
public  class Chapter18 {
    
     int counter=0;
    static int getsizecounter=0;
     public static long getSize(File file) {
long size = 0; // Store the total size of all files

if (file.isDirectory()) {
 File[] files = file.listFiles(); // All files and subdirectories
 //for (int i = 0; files != null && i < files.length; i++) 
 for (int i = 0; i < files.length; i++) 
 {
 size += getSize(files[i]);
 getsizecounter=getsizecounter+1;
 System.out.println("getsize "+getsizecounter);
 // Recursive call
 }
 }
 else { // Base case
size += file.length();
 }
         
return size;
 }
     
    public boolean isPalindrome(String s) {
 if (s.length() <= 1)
 {// Base case
      counter= counter+1;
       System.out.println("counter"+counter);
return true;
 }
else if (s.charAt(0) != s.charAt(s.length() - 1)) // Base case
{
     counter= counter+1;
      System.out.println("counter"+counter);
 return false;
}
else
{
    counter= counter+1;
    System.out.println("counter"+counter);
return isPalindrome(s.substring(1, s.length() - 1));
}
    }
    
}
