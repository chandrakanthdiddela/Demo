/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package movingballgame;

import javafx.application.Application;
import javafx.geometry.Pos;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.FlowPane;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class MovingBallGame extends Application {
    
    @Override
    public void start(Stage stage) {
        
         BallPane ballPane = new BallPane(); 
         StackPane lobjStackpane = new StackPane();
         lobjStackpane.getChildren().add(ballPane);
       stage.setTitle("HTML");
        stage.setWidth(300);
        stage.setHeight(300);
        Scene scene = new Scene(lobjStackpane);
        
        
 
        stage.setScene(scene);
        stage.show();
         ballPane.requestFocus();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
