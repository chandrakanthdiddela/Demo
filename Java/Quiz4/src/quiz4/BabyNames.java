package quiz4;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class BabyNames
{
   public static final double LIMIT = 50;
 private static void sortList(List<String> aItems){
    Collections.sort(aItems, String.CASE_INSENSITIVE_ORDER);
  }
   public static void main(String[] args) throws FileNotFoundException, IOException
   { 
       ArrayList<String> lstrlist= new ArrayList<String>();
       
         ArrayList<String> lstrgals= new ArrayList<String>();
       
       
       
        FileReader fileReader = 
                new FileReader("babynames.txt");

            // Always wrap FileReader in BufferedReader.
            BufferedReader bufferedReader = 
                new BufferedReader(fileReader);
String line;
            while((line = bufferedReader.readLine()) != null) {
               // System.out.println("hello");
               String lstr[]= line.split(" ");
               
            // for (int i=0;i<lstr.length-1;i++) {
                 
                 lstrlist.add(lstr[2]);
                 
                 lstrgals.add(lstr[8]);
                  //System.out.println(lstr[2]);
    // do some work here on intValue
//}
                
                
               // System.out.println(line);
            }   

//       BabyNames.sortList(lstrlist);
//         System.out.println("boys name in sorted order") ;  
//       for(String str:lstrlist)
//       {
//           System.out.println(str);
//       }
//       
//       
//         System.out.println("gals name in sorted order") ;
//          BabyNames.sortList(lstrgals);
//       for(String str:lstrgals)
//       {
//           System.out.println(str);
//       }
       
       
       lstrgals.addAll(lstrlist);
        BabyNames.sortList(lstrgals);
        for(String str:lstrgals)
       {
           System.out.println(str);
       }
//      Scanner in = new Scanner(new File("babynames.txt"));
//      
//     
//         
//      RecordReader boys = new RecordReader(LIMIT);
//      RecordReader girls = new RecordReader(LIMIT);
//      
//      while (boys.hasMore() || girls.hasMore())
//      {
//         int rank = in.nextInt();
//         System.out.print(rank + " ");
//         boys.process(in);
//         girls.process(in);
//         System.out.println();
//      }
//
//      in.close();
   }
}	
