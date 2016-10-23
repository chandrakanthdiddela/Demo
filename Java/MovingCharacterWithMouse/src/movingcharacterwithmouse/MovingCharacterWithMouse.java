/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package movingcharacterwithmouse;


import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class MovingCharacterWithMouse extends Application {
    
    @Override
    public void start(Stage primaryStage) {
       
        
        StackPane root = new StackPane();
        
        Scene scene = new Scene(root, 300, 250);
        
        primaryStage.setTitle("Hello World!");
        primaryStage.setScene(scene);
        primaryStage.show();
        
          Label lobjlabel = new Label("Pr");
          root.getChildren().add(lobjlabel);
        scene.setOnMouseMoved(new EventHandler<MouseEvent>() {

            @Override
            public void handle(MouseEvent event) {
                
               double xcordinate= 100;
                double ycordinate=100;
              
                while(true)
                {
                     lobjlabel.setTranslateX(xcordinate);
               lobjlabel.setTranslateY(ycordinate);
               ycordinate=ycordinate+30;
                xcordinate= xcordinate+30;
                }
            }

           
        });
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
