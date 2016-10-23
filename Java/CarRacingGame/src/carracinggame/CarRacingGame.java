/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package carracinggame;


import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.HBox;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class CarRacingGame extends Application {
    
    @Override
    public void start(Stage stage) {
       Scene scene = new Scene(new Group());
    stage.setTitle("Label Sample");
    stage.setWidth(400);
    stage.setHeight(180);

    HBox hbox = new HBox();

   // Label label1 = new Label("Search");
   Image  img1= new Image(getClass().getResourceAsStream("images/duke.gif"));
       Label label1 = new Label("",new ImageView(img1));
    label1.setTranslateY(100);
    
    

    hbox.setSpacing(10);
    hbox.getChildren().add((label1));
    ((Group) scene.getRoot()).getChildren().add(hbox);
    
     scene.setOnMouseMoved(new EventHandler<MouseEvent>() {
		

            @Override
            public void handle(MouseEvent event) {
              // double xcordinate= event.getX();
               double xcordinate= event.getX();
              // double ycordinate=event.getY();
                double ycordinate=event.getY();
               //Label lobjlabel= new Label("A");
              
               label1.setTranslateX(xcordinate);
               label1.setTranslateY(ycordinate);
             
                //root.setBackground(Background.EMPTY);
            }
	});
//    label1.onKeyPressedProperty(new EventHandler<MouseEvent>() {
//      @Override
//      public void handle(MouseEvent e) {
//        label1.setScaleX(1.5);
//        label1.setScaleY(1.5);
//      }
//    });

    stage.setScene(scene);
    stage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
