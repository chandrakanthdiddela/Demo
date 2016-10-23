package ballgame;



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
        myPlayer.setTranslateX(myGenerator.nextInt(width));
        myPlayer.setTranslateY(myGenerator.nextInt(height));
        myEnemy = new Circle(myGenerator.nextInt(width), myGenerator.nextInt(height), OPPONENT_SIZE);
        myEnemy.setFill(Color.BLACK);
        myEnemy1 = new Circle(myGenerator.nextInt(500), myGenerator.nextInt(500), OPPONENT_SIZE1);
        myEnemy1.setFill(Color.BLUE);
        myEnemy.setOnMouseClicked(e -> handleMouseInput(e));
        myEnemyVelocity = new Point2D(myGenerator.nextInt(5) - 3, myGenerator.nextInt(5) - 3);
        myEnemy1.setOnMouseClicked(e -> handleMouseInput(e));
        myEnemyVelocity1 = new Point2D(myGenerator.nextInt(2) - 1, myGenerator.nextInt(2) - 1);
        // remember shapes for viewing later
        myRoot.getChildren().add(myEnemy);
        myRoot.getChildren().add(myEnemy1);
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
        
         redballCenterx=myEnemy.getCenterX();
         
         redballCentery=myEnemy.getCenterY();
        
         blueballCenterx=myEnemy1.getCenterX();
         blueballCentery=myEnemy1.getCenterY();
         // calculate distance between two ball and check whether exist near by if so moving the ball 
         // coordinate little bit far from each other.
         double distancex=Math.abs(redballCenterx-blueballCenterx)* Math.abs(redballCenterx-blueballCenterx);
         double distancey=Math.abs(redballCentery-blueballCentery)*Math.abs(redballCentery-blueballCentery);
         double distance =distancex+distancey;
         double radius1=myEnemy.getRadius();
         double radius2=myEnemy1.getRadius();
         double sumradius=radius1+radius2;
         if(Math.sqrt(distance)<= Math.abs(sumradius)+5)
         {
             
            
       myEnemy.setCenterX(myEnemy.getCenterX()+100 + myEnemyVelocity.getX()+20);
        myEnemy.setCenterY(myEnemy.getCenterY()+120 + myEnemyVelocity.getY()+20);
       
        myEnemy1.setCenterX(myEnemy1.getCenterX()-20 + myEnemyVelocity1.getX());
        myEnemy1.setCenterY(myEnemy1.getCenterY()-12 + myEnemyVelocity1.getY());
        
         }
         else
         {
        myPlayer.setRotate(myPlayer.getRotate() + 1);
        myEnemy.setCenterX(myEnemy.getCenterX() + myEnemyVelocity.getX());
        myEnemy.setCenterY(myEnemy.getCenterY() + myEnemyVelocity.getY());
        myEnemy1.setCenterX(myEnemy1.getCenterX() + myEnemyVelocity1.getX());
        myEnemy1.setCenterY(myEnemy1.getCenterY() + myEnemyVelocity1.getY());
         }
        
        if (myEnemy.getCenterX() >= myScene.getWidth() || myEnemy.getCenterX() <= 0) {
            
            myEnemyVelocity = new Point2D(myEnemyVelocity.getX() * -1, myEnemyVelocity.getY());
        }
        if (myEnemy.getCenterY() >= myScene.getHeight() || myEnemy.getCenterY() <= 0) {
            myEnemyVelocity = new Point2D(myEnemyVelocity.getX(), myEnemyVelocity.getY() * -1);
        }
        
         if (myEnemy1.getCenterX() >= myScene.getWidth() || myEnemy1.getCenterX() <= 0) {
            myEnemyVelocity1 = new Point2D(myEnemyVelocity1.getX() * -1, myEnemyVelocity1.getY());
        }
        if (myEnemy1.getCenterY() >= myScene.getHeight() || myEnemy1.getCenterY() <= 0) {
            myEnemyVelocity1 = new Point2D(myEnemyVelocity1.getX(), myEnemyVelocity1.getY() * -1);
        }
        checkCollide(myPlayer, myEnemy,myEnemy1);
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
    private void checkCollide (Node player, 
            Node enemy,
            Node enemy1) {
        // check for collision
        if (player.getBoundsInParent().intersects(enemy.getBoundsInParent())) {
            System.out.println("Collide black!");
            
        }
        if (player.getBoundsInParent().intersects(enemy1.getBoundsInParent())) {
            System.out.println("Collide blue!");
        }
         if (enemy.getBoundsInParent().intersects(enemy1.getBoundsInParent())) {
            System.out.println("Collide both!");
        }
        
    
       
    }
}
