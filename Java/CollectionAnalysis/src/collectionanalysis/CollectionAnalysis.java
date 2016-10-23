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
import java.util.StringTokenizer;
import java.util.TreeMap;
import java.util.Vector;
import java.util.WeakHashMap;


/**
 *
 * @author Varnith
 */
public class CollectionAnalysis {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) 
    {
         try 
         {
   
             
        System.out.println("**** Java collection classes Analysis****");
        System.out.println("");
        System.out.println("");
        System.out.println("**** Enter an input value to create a dataset****");
        Scanner lobjScanner = new Scanner(System.in);
        int input =lobjScanner.nextInt();
        Object[] lobjarray = HelperMain.getObjects(input);
        HelperMain.AnalayseCreation(lobjarray);
        
        } catch (Exception e) {
        }
      
        
       // HelperMain.Insert();
     
    }
    
        }
      
