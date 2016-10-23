/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cardgame;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class CardGame extends Application {
    
    // define a label
    
    Label card1,card2,card3;
    Image img1,img2,img3;
    @Override
    public void start(Stage primaryStage) {

        StackPane root = new StackPane();
        Scene scene = new Scene(root, 300, 250);
        img1= new Image(getClass().getResourceAsStream("images/duke.gif"));
        card1 = new Label("",new ImageView(img1));
        img2=new Image(getClass().getResourceAsStream("images/duke.gif"));
         card2 = new Label("",new ImageView(img2));
        img3=new Image(getClass().getResourceAsStream("images/duke.gif"));
         card3 = new Label("",new ImageView(img3));
        
        root.getChildren().add(card1);
        root.getChildren().add(card2);
        root.getChildren().add(card3);
        root.setAlignment(card1, Pos.TOP_LEFT);
       root.setAlignment(card2, Pos.TOP_CENTER);
        root.setAlignment(card3, Pos.TOP_RIGHT);
        primaryStage.setTitle("CardGame!");
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
