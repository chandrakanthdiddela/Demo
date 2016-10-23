/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package seleniumsample;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.htmlunit.HtmlUnitDriver;

/**
 *
 * @author Varnith
 */
public class SeleniumSample {

    /**
     * @param args the command line arguments
     */
    
    private static String mstrSearchkeyword=null;
    
    public static void main(String[] args) {
        try {
            System.out.println("****Enter the input to search on www.google.com : ");
            
            Scanner lobjscanner= new Scanner(System.in);
            
             mstrSearchkeyword= lobjscanner.next();
            
            InvokeSelenium(mstrSearchkeyword);   // invock Launch Selenium method...
            
        } catch (Exception lobjException) {
            Logger.getLogger(SeleniumSample.class.getName()).log(Level.SEVERE, null, lobjException);
        }
        
    }
     public  static void InvokeSelenium(String pstrSearchkeyword)
    {
        try {
            WebDriver driver = new HtmlUnitDriver();
            driver.get("http://www.google.com");
            WebElement lobjelement = driver.findElement(By.name("q"));
            lobjelement.sendKeys(pstrSearchkeyword);
            lobjelement.submit();
             char[] lobjBuffer= driver.getPageSource().toCharArray();
            //lobjfilewriter.write(lobjBuffer);
            //String lstrpath=file.getAbsolutePath();
            //System.out.println(mstrSearchkeyword+" File successfully created at!! "+lstrpath);
            WriteTheContentToTextFile(lobjBuffer,pstrSearchkeyword);
             driver.quit();
            
            
        }
        catch (Exception lobjException) {
            Logger.getLogger(SeleniumSample.class.getName()).log(Level.SEVERE, null, lobjException);
            
        }
    }
    
    private static void WriteTheContentToTextFile(char[] pobjBuffer,String psearchkeyword) throws IOException
    {
        String filepath="output\\"+psearchkeyword+".txt";
        File file = new File(filepath);
     
            
           if (file.getParentFile().mkdir()) 
            {
            
                file.createNewFile();
                FileWriter lobjfilewriter=new FileWriter(file);
            lobjfilewriter.write(pobjBuffer);
                System.out.println("content has been sucessfully fetched and written into file path" +file.getAbsolutePath());
            
              } 
            else 
            {
                 file.createNewFile();
                FileWriter lobjfilewriter=new FileWriter(file);
            lobjfilewriter.write(pobjBuffer);
                System.out.println("content has been sucessfully fetched and written into file path" +file.getAbsolutePath());
   
            }
    }


    
}
