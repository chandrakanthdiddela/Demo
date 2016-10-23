/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cargamedemo;



import javafx.animation.KeyFrame;
import javafx.animation.Timeline;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.scene.shape.Circle;
import javafx.scene.shape.Polygon;
import javafx.scene.shape.Rectangle;
import javafx.util.Duration;
import javafx.application.Platform;

/**
 *
 * @author Varnith
 */

public class BuildCarPane extends Pane {
    private double w = 200;
 	private double x = 0;
 	private double y = 100;
 	private double radius = 5;
 	private Rectangle rectangle;
 	private Polygon polygon;
 	private Circle circle1;
 	private Circle circle2;
 	private Timeline animation;
 
 	private int sleepTime = 50;
  public void move() {
    if (x > w)
      x = -20;
    else
      x += 1;
    
    setValues();
  }
  private Thread thread = new Thread(() -> {
    try {
      while (true) {
        Platform.runLater(() -> move());
        Thread.sleep(sleepTime);
      }
    }
    catch (InterruptedException ex) {
    }
  });
 	BuildCarPane() {
 		drawCar();
 		animation = new Timeline(
 			new KeyFrame(Duration.millis(50), e -> moveCar()));
 		animation.setCycleCount(Timeline.INDEFINITE);
                System.out.println("Start of constrctor called");
 		animation.play();
                System.out.println("end of contructor car ");
                
 	}
 
 	public void setValues() {
    circle1.setCenterX(x + 10 + 5);
    circle1.setCenterY(x - 10 + 5);
    circle2.setCenterX(x + 30 + 5);
    circle2.setCenterY(y - 10 + 5);

    rectangle.setX(x);
    rectangle.setY(y - 20);
    
    polygon.getPoints().clear();
    polygon.getPoints().addAll(x + 10, y - 20, 
            x + 20, y - 30, x + 30, y - 30, 
            x + 40, y - 20);   
  }
 	private void drawCar() {
 		getChildren().clear();
 		rectangle = new Rectangle(x, y - 20, 50, 10);
                rectangle.setFill(Color.GREEN);
		polygon = new Polygon(x + 10, y - 20, x + 20, y - 30, x + 30, 
			y - 30, x + 40, y - 20);
                polygon.setFill(Color.RED);
		circle1 = new Circle(x + 15, y - 5, radius);
                circle1.setFill(Color.BLACK);
		circle2 = new Circle(x + 35, y - 5, radius);
                circle2.setFill(Color.BLACK);
 		getChildren().addAll(rectangle, circle1, circle2, polygon);
 	}
 
 
 	public void pause() {
            System.out.println("Pause car called");
 		animation.pause();
 	}
 
 	
 	public void play() {
             System.out.println("Play car called");
 		animation.play();
 	}
 
 	
 	public void increaseSpeed() {
            System.out.println("Increase speed called");
 		animation.setRate(animation.getRate()  + 1);
                if (sleepTime > 1)
      sleepTime--;
 	}
 
 	
 	public void decreaseSpeed() {
            System.out.println("decrease speed called");
 		animation.setRate(animation.getRate() > 0 ? animation.getRate() - 1 : 0);
               sleepTime++;
 	}
 
 	
 	protected void moveCar() {
            System.out.println("move car called");
 		if (x <= getWidth()) {
                     System.out.println(" if block called");
                     play();
 			x  = x+1;	
 		} 
 		else
                {
                    System.out.println(" else block called");
 			x = 0;
                }
 
 		drawCar();
                  System.out.println("draw car called");
    
}
}
