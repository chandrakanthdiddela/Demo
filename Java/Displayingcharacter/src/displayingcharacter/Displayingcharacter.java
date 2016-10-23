/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package displayingcharacter;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.StackPane;
import javafx.scene.text.Text;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class Displayingcharacter extends Application {
    
    @Override
    public void start(Stage primaryStage) {
        Button btn = new Button();
        btn.setText("Say 'Hello World'");
        btn.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
                System.out.println("Hello World!");
            }
        });
        
        StackPane root = new StackPane();
        //root.getChildren().add(btn);
        
        Scene scene = new Scene(root, 300, 250);
        
        primaryStage.setTitle("Hello World!");
        primaryStage.setScene(scene);
        primaryStage.show();
          Label lobjlabel = new Label("Pr");
          root.getChildren().add(lobjlabel);
         scene.setOnMouseMoved(new EventHandler<MouseEvent>() {
		

            @Override
            public void handle(MouseEvent event) {
              // double xcordinate= event.getX();
               double xcordinate= event.getX();
              // double ycordinate=event.getY();
                double ycordinate=event.getY();
               //Label lobjlabel= new Label("A");
              
               lobjlabel.setTranslateX(xcordinate);
               lobjlabel.setTranslateY(ycordinate);
             
                //root.setBackground(Background.EMPTY);
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
