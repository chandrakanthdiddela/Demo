/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package filecreationsample;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

/**
 *
 * @author Varnith
 */
public class FileCreationSample {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws IOException {
        String text = "Hello world";
        BufferedWriter output = null;
        try {
            File file = new File("example.txt");
            output = new BufferedWriter(new FileWriter(file)); 
            for(int i=5000;i>=1000;i--)
            {
                //output.newLine();
            output.write(String.valueOf(i));
            output.newLine();
            //output.write("\n");
            }
        } catch ( IOException e ) {
            e.printStackTrace();
        } finally {
            if ( output != null ) output.close();
        }
    }
//        // TODO code application logic here
//        
//        File file = new File("output\\test.txt");
//if (file.getParentFile().mkdir()) {
//    file.createNewFile();
//} else {
//    throw new IOException("Failed to create directory " + file.getParent());
//}
//    }
    
}
