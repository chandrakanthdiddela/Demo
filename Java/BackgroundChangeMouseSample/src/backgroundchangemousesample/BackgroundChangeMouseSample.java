/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package backgroundchangemousesample;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.Event;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.Button;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.Background;
import javafx.scene.layout.Pane;
import javafx.scene.layout.StackPane;
import javafx.scene.paint.Color;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class BackgroundChangeMouseSample extends Application {
    
    @Override
    public void start(Stage primaryStage) {
       
        //http://stackoverflow.com/questions/25468882/change-color-of-background-in-javafx-canvas
        Pane root = new Pane();

        StackPane holder = new StackPane();
        Canvas canvas = new Canvas(400,  300);

        holder.getChildren().add(canvas);
        root.getChildren().add(holder);

        //holder.setStyle("-fx-background-color: red");
        Scene scene = new Scene(root, 600, 400);
        primaryStage.setScene(scene);
        primaryStage.show();
        scene.setOnMousePressed(new EventHandler<MouseEvent>() {
		

            @Override
            public void handle(MouseEvent event) {
                holder.setStyle("-fx-background-color: red");
                //root.setBackground(Background.EMPTY);
            }
	});
        
         scene.setOnMouseReleased(new EventHandler<MouseEvent>() {
		

            @Override
            public void handle(MouseEvent event) {
                  holder.setStyle("-fx-background-color: blue");
               
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
