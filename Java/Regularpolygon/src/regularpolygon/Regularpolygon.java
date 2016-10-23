/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package regularpolygon;

import java.awt.Polygon;
import java.util.ArrayList;
import java.util.List;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class Regularpolygon extends Application {
    
   
   
    int numberside=5;
    double[] listx =new double[numberside];
    double[] listy =new double[numberside];
    
    @Override
    public void start(Stage primaryStage) {
        
        
      final  Canvas canvas = new Canvas(250,250);
GraphicsContext gc = canvas.getGraphicsContext2D();
        CalculatePolygonCoordinates(numberside);
       gc.fillPolygon(listx, listy, numberside);

        StackPane root = new StackPane();
        root.getChildren().add(canvas);
        
        Scene scene = new Scene(root, 300, 250);
        
        primaryStage.setTitle("Hello World!");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
    public void CalculatePolygonCoordinates(int pnumberside)
    {
 
         double WIDTH = 100, HEIGHT = 100;
      double centerX = WIDTH / 2, centerY = HEIGHT / 2;
      double radius = Math.min(WIDTH, HEIGHT) * 0.4;
  
      // Add points to the polygon list
      for (int i = 0; i < pnumberside; i++) {
          listx[i]=centerX + radius * Math.cos(2 * i * Math.PI / pnumberside);
        listy[i]=centerY - radius * Math.sin(2 * i * Math.PI / pnumberside);
      } 
        
        
    }
}
