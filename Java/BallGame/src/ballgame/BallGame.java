/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ballgame;

import javafx.animation.Animation;
import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class BallGame extends Application {
       private static final int NUM_FRAMES_PER_SECOND = 60;
    private static final int POTATOES = 10;
    private BallWorld myGame;
    @Override
    public void start(Stage s) {

         s.setTitle("Big BallWorld!");
        // create your own game here
        myGame = new BallWorld();
        // attach game to the stage and display it
        Scene scene = myGame.init(s, 800, 800);
        s.setScene(scene);
        s.show();

        // setup the game's loop
        KeyFrame frame = myGame.start(NUM_FRAMES_PER_SECOND + 5);
        Timeline animation = new Timeline();
        animation.setCycleCount(Animation.INDEFINITE);
        animation.getKeyFrames().add(frame);
        animation.play();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
