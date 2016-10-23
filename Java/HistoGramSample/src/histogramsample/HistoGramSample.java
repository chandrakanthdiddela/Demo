/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package histogramsample;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import javafx.application.Application;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.chart.BarChart;
import javafx.scene.chart.CategoryAxis;
import javafx.scene.chart.NumberAxis;
import javafx.scene.chart.XYChart;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class HistoGramSample extends Application {
    
     HashMap dict;
    @Override
    public void start(Stage stage) {
       
        stage.setWidth(500);
        stage.setHeight(500);
        Scene scene = new Scene(new Group());
         StackPane root = new StackPane();

        stage.setTitle("Bar Chart Sample");
        final CategoryAxis xAxis = new CategoryAxis();
        final NumberAxis yAxis = new NumberAxis();
        final BarChart<String,Number> bc = 
            new BarChart<String,Number>(xAxis,yAxis);
        bc.setTitle("Alphabetscount");
        xAxis.setLabel("Alphabets");       
        yAxis.setLabel("count");
 
        XYChart.Series series1 = new XYChart.Series();
        series1.setName("2003"); 
        
 CountCharacters();

 Iterator<Map.Entry<Integer, String>> iterator = dict.entrySet().iterator();
        while(iterator.hasNext()){
            Map.Entry<Integer, String> entry = iterator.next();
             series1.getData().add(new XYChart.Data(entry.getKey(), entry.getValue()));
          //  System.out.printf("Key : %s and Value: %s %n", entry.getKey(), 
            //                                               entry.getValue());
            iterator.remove(); // right way to remove entries from Map, 
                               // avoids ConcurrentModificationException
        }
        //series1.getData().add(new XYChart.Data("A", 2));
//        series1.getData().add(new XYChart.Data("B", 2));
//        series1.getData().add(new XYChart.Data("C", 1));
//        series1.getData().add(new XYChart.Data("D", 3));
//        series1.getData().add(new XYChart.Data("E", 1));     
          bc.getData().addAll(series1);
        root.getChildren().addAll(bc);
        scene.setRoot(root);

        stage.setScene(scene);
        stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
    public void CountCharacters()
    {
        
    String lstrInputText="ABCDEFABC";
        dict = new HashMap();
                        
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
    }
    

    }
}