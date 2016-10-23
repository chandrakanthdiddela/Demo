/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package monthinterestcalcualtor;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class MonthInterestCalcualtor extends Application {
     Label lobjLoanAmountLabel,lobjLoanPeriod;
    TextField lobjAmountText,lobjLoanText;
    Button lobjCalcuate;
    @Override
    public void start(Stage primaryStage) {
  
        StackPane lobStakpane = new StackPane();
        
GridPane root = new GridPane();
root.setPadding(new javafx.geometry.Insets(10,10,10,10));
root.setVgap(5);
root.setHgap(5);

 lobjLoanAmountLabel = new Label("LoanAmount:");
lobjAmountText = new TextField ();
GridPane.setConstraints(lobjLoanAmountLabel, 0, 0);
GridPane.setConstraints(lobjAmountText, 0, 1);
root.getChildren().add(lobjLoanAmountLabel);
root.getChildren().add(lobjAmountText);

lobjLoanPeriod = new Label("Period");
lobjLoanText = new TextField ();
GridPane.setConstraints(lobjLoanPeriod, 1, 0);
GridPane.setConstraints(lobjLoanText, 1, 1);
root.getChildren().add(lobjLoanPeriod);
root.getChildren().add( lobjLoanText);





 
lobjCalcuate= new Button("ShowTable");
 lobjCalcuate.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
                TextArea lobjTextArea= new TextArea();
                GridPane.setConstraints(lobjTextArea, 4, 4);
                root.getChildren().add( lobjTextArea);

            }
        });

GridPane.setConstraints(lobjCalcuate, 1, 4);

root.getChildren().add(lobjCalcuate);
 Scene scene = new Scene(root, 300, 250);
        
        primaryStage.setTitle("Hello World!");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
    public HBox addHBox() {
    HBox hbox = new HBox();
    hbox.setPadding(new Insets(15, 12, 15, 12));
    hbox.setSpacing(10);
    hbox.setStyle("-fx-background-color: #336699;");

    Button buttonCurrent = new Button("Current");
    buttonCurrent.setPrefSize(100, 20);

    Button buttonProjected = new Button("Projected");
    buttonProjected.setPrefSize(100, 20);
    hbox.getChildren().addAll(buttonCurrent, buttonProjected);

    return hbox;
}
}
