/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package polygondraw;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Varnith
 */
public class PolygonDraw {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
             // ObservableList<Double> list = 
     // list.clear();
 List<Double> listx = new ArrayList<Double>();
 List<Double> listy = new ArrayList<Double>();
 
          final double WIDTH = 200, HEIGHT = 200;
      double centerX = WIDTH / 2, centerY = HEIGHT / 2;
      double radius = Math.min(WIDTH, HEIGHT) * 0.4;
  
      // Add points to the polygon list
      for (int i = 0; i < 6; i++) {
          
        listx.add(centerX + radius * Math.cos(2 * i * Math.PI / 6)); 
        listy.add(centerY - radius * Math.sin(2 * i * Math.PI / 6));
      } 
        for (int i = 0; i < listx.size(); i++) {
           System.out.println(listx.get(i));
            
        }
        for (int i = 0; i < listy.size(); i++) {
           System.out.println(listy.get(i));
            
        }
       
    }
    
}
