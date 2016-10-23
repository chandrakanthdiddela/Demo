/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lettercount;

import java.util.ArrayList;
import java.util.Dictionary;
import java.util.HashMap;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

/**
 *
 * @author Varnith
 */
public class LetterCount {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        String lstr="ABCDEFGH";
        
			// Pattern p = Pattern.Complie("");
			System.out.println("**********Welcome to String "
					+ "reverse Application*********");
			System.out.println();
			// Prompt the user to enter the String
			System.out.print("Enter the String to reverse: ");
			// Read the input from the keyboard//
			Scanner input = new Scanner(System.in);
			// read an input string from the keyboard
			String lstrInputText = input.nextLine();
			System.out.println("");
                        HashMap dict = new HashMap();
                        
			if (lstrInputText.length() > 0) {
				

				for (int i=0; i<= lstrInputText.length() - 1; i++) {
                                    String key=String.valueOf(lstrInputText.charAt(i));
                                   
                                    System.out.println(dict.containsKey(key));
                                    int currentcount=1;
                                     if(dict.containsKey(key))
                                     {
                                          currentcount =(int)dict.get(key);
                                         
                                    
					dict.put(String.valueOf(lstrInputText.charAt(i)),currentcount+1);
                                     }
                                     
                                     else
                                     {
                                       dict.put(String.valueOf(lstrInputText.charAt(i)),1);  
                                     }
				}
System.out.println("abc");
                        }
                
 Iterator<Map.Entry<Integer, String>> iterator = dict.entrySet().iterator();
        while(iterator.hasNext()){
            Map.Entry<Integer, String> entry = iterator.next();
            System.out.printf("Key : %s and Value: %s %n", entry.getKey(), 
                                                           entry.getValue());
            iterator.remove(); // right way to remove entries from Map, 
                               // avoids ConcurrentModificationException
        }


        
    }}
    

