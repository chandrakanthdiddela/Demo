/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package samplefile;

import javafx.application.Application;
import javafx.beans.value.ObservableValue;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.ScrollBar;
import javafx.scene.control.TextField;
import javafx.scene.layout.Background;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.StackPane;
import javafx.scene.paint.Color;
import javafx.scene.text.Text;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class Samplefile extends Application {
    
    @Override
    public void start(Stage primaryStage) {
       
        
        //StackPane root = new StackPane();
        GridPane root1 = new GridPane();
root1.setPadding(new javafx.geometry.Insets(10,10,10,10));
root1.setVgap(5);
root1.setHgap(5);
 Text lobjSampleText = new Text("Programming is fun");
GridPane.setConstraints(lobjSampleText, 0, 0);
 root1.getChildren().add(lobjSampleText);
 ScrollBar s1 = new ScrollBar();
 
 GridPane.setConstraints(s1, 1, 0);
 root1.getChildren().add(s1);
  s1.valueProperty().addListener(ov ->
          lobjSampleText.setFill(Color.BLUEVIOLET));
  
  
  
  ScrollBar s2 = new ScrollBar();
 
 GridPane.setConstraints(s2, 0, 4);
 root1.getChildren().add(s2);
 
  s2.valueProperty().addListener(ov ->
          lobjSampleText.setFill(Color.BROWN));
  
  ScrollBar s3 = new ScrollBar();
 
 GridPane.setConstraints(s3, 0, 3);
 root1.getChildren().add(s3);
 
  s3.valueProperty().addListener(ov ->
          lobjSampleText.setFill(Color.RED));
 
        Scene scene = new Scene(root1, 300, 250);
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
    
}
