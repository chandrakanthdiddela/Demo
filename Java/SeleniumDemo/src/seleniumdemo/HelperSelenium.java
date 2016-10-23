/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package seleniumdemo;
import java.io.File;
import java.io.IOException;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.htmlunit.HtmlUnitDriver;
import java.util.logging.Level;
import java.util.logging.Logger;
/**
 *
 * @author Varnith
 */
public class HelperSelenium {
    
    public void InvokeSelenium(String pstrSearchkeyword)
    {
        try {
            WebDriver driver = new HtmlUnitDriver();
            driver.get("http://www.google.com");
            WebElement lobjelement = driver.findElement(By.name("q"));
            lobjelement.sendKeys(pstrSearchkeyword);
            lobjelement.submit();
            WriteTheContentToTextFile();
            
        }
        catch (Exception lobjException) {
            Logger.getLogger(HelperSelenium.class.getName()).log(Level.SEVERE, null, lobjException);
            
        }
    }
    
    private void WriteTheContentToTextFile() throws IOException
    {
            File file = new File("output\\test.txt");
            if (file.getParentFile().mkdir()) 
            {
                file.createNewFile();
              } 
            else 
            {
    throw new IOException("Failed to create directory " + file.getParent());
            }
    }
}
