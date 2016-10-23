/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cargamedemo;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyCodeCombination;
import javafx.scene.input.KeyCombination;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class CarGameDemo extends Application {
    
    @Override
    public void start(Stage primaryStage) {
       // Create a car
 		BuildCarPane pane = new BuildCarPane();
 
 		// Create and register handles
 		pane.setOnMousePressed(e -> pane.pause());
 		pane.setOnMouseReleased(e -> pane.play());
                
                 pane.requestFocus();
 
 		pane.setOnKeyPressed(e -> {
                  ///  if(e.getCode()=KeyCode.CONTROL) // working 
 	
                            //e.get
                    if (e.getCode() == KeyCode.UP)
                    {
                        System.out.println("Key is pressed" + e.getCode());
                         // KeyCodeCombination lobj=  new KeyCodeCombination(KeyCode.SHIFT, KeyCombination.CONTROL_DOWN);
                          //lobj.getCode();
                            //System.out.println( "add value2" +lobj.getCode());
 				pane.increaseSpeed();
                    }
 			else if (e.getCode() == KeyCode.DOWN) {
                            System.out.println("minus value1"+ KeyCode.MINUS);
 				pane.decreaseSpeed();
 			}
 		});
 
 		// Create a scene and place it in the stage
 		Scene scene = new Scene(pane, 600, 100);
 		primaryStage.setTitle("CarRacingGame"); // Set the stage title
 		primaryStage.setScene(scene); // Place the scene in the stage
 		primaryStage.show(); // Display the stage
 
 		pane.requestFocus(); // Request focus
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
