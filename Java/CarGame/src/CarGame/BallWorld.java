package CarGame;



import javafx.animation.KeyFrame;
import javafx.geometry.Point2D;
import javafx.scene.Group;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.input.MouseEvent;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.stage.Stage;
import javafx.util.Duration;
import java.util.Random;


/**
 * This represents the primary class for a game/animation.
 *
 * @author Robert C. Duvall
 */
class BallWorld {
    private static final double ENEMY_GROWTH_FACTOR = 1.1;
    private static final int OPPONENT_SIZE = 40;
     private static final int OPPONENT_SIZE1 = 40;
    private static final int PLAYER_SPEED = 4;
    private static final int PLAYER_SPEED1 = 2;

    private Scene myScene;
    private Group myRoot;
    private ImageView myPlayer;
    private ImageView myPlayer1;
    private Circle myEnemy;
    private Circle myEnemy1;
    private Point2D myEnemyVelocity;
    private Point2D myEnemyVelocity1;
    private Random myGenerator = new Random();
     double redballCenterx,redballCentery,blueballCenterx,blueballCentery;


    /**
     * Create the game's scene
     */
    public Scene init (Stage s, int width, int height) {
//        // create a scene graph to organize the scene
        myRoot = new Group();
        // make some shapes and set their properties
        myPlayer = new ImageView(new Image(getClass().getResourceAsStream("images/duke.gif")));
        myPlayer.setTranslateX(0);
        myPlayer.setTranslateY(100);
        myRoot.getChildren().add(myPlayer);

        // create a place to display the shapes and react to input
        myScene = new Scene(myRoot, width, height, Color.WHITE);
        myScene.setOnKeyPressed(e -> handleKeyInput(e));

        return myScene;
    }


    /**
     * Create the game's frame
     */
    public KeyFrame start (int frameRate) {
        return new KeyFrame(Duration.millis(1000 / frameRate), e -> updateSprites());
        //return new KeyFrame(Duration.millis(2000), e -> updateSprites());
    }

    /**
     * What to do each game frame
     *
     * Change the sprite properties each frame by a tiny amount to animate them
     *
     * Note, there are more sophisticated ways to animate shapes, but these simple ways work too.
     */
    private void updateSprites () {
        double x=10,y=0;
        while(true)
        { x=x+10;
              myPlayer.setTranslateX(0);
        myPlayer.setTranslateY(100);
        }
         
         
        //checkCollide(myPlayer);
    }

    /**
     * What to do each time a key is pressed
     */
    private void handleKeyInput (KeyEvent e) {
        KeyCode keyCode = e.getCode();
        if (keyCode == KeyCode.RIGHT) {
            myPlayer.setTranslateX(myPlayer.getTranslateX() + PLAYER_SPEED);
        }
        else if (keyCode == KeyCode.LEFT) {
            myPlayer.setTranslateX(myPlayer.getTranslateX() - PLAYER_SPEED);
        }
        else if (keyCode == KeyCode.UP) {
            myPlayer.setTranslateY(myPlayer.getTranslateY() - PLAYER_SPEED1);
        }
        else if (keyCode == KeyCode.DOWN) {
            myPlayer.setTranslateY(myPlayer.getTranslateY() + PLAYER_SPEED1);
        }
    }
    
    /**
     * What to do each time the mouse is clicked
     */
    private void handleMouseInput (MouseEvent e) {
        myEnemy.setScaleX(myEnemy.getScaleX() * ENEMY_GROWTH_FACTOR);
        myEnemy.setScaleY(myEnemy.getScaleY() * ENEMY_GROWTH_FACTOR);
    }

    /**
     * What to do each time shapes collide
     */
    private void checkCollide (Node player) {
        // check for collision
//        if (player.getBoundsInParent().intersects(enemy.getBoundsInParent())) {
//            System.out.println("Collide black!");
//            
//        }
    
        
    
       
    }
}
