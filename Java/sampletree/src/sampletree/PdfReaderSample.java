/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sampletree;

import com.itextpdf.text.pdf.PdfReader;
import com.itextpdf.text.pdf.parser.PdfTextExtractor;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Varnith
 */
public class PdfReaderSample {
    
    public  ArrayList<Integer>   ReadPdfDocument() throws IOException
    {
          String[] lstrwordlist={};
   ArrayList<Integer>  lobjlist = new ArrayList<Integer>();
        PdfReader reader = new PdfReader("C:/Users/Varnith/Desktop/TestFilewithNumbers.pdf");
            System.out.println("This PDF has "+reader.getNumberOfPages()+" pages.");
            for(int i=0;i<reader.getNumberOfPages();i++)
            {
            String page = PdfTextExtractor.getTextFromPage(reader, i+1);
             lstrwordlist= page.trim().split("\n");
                //System.out.println("hello");
                for(int j=0;j<lstrwordlist.length;j++)
                {
                    lobjlist.add(Integer.valueOf(lstrwordlist[j].trim()));
                    
                }
                //lobjlist.add(lstrwordlist[0]);
            //System.out.println("Page Content:\n\n"+page+"\n\n");
            }
            System.out.println("length of element :" + lobjlist.size());
            return lobjlist;
    }
    
}
