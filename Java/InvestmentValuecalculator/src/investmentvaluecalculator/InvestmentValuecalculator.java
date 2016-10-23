/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package investmentvaluecalculator;

import javafx.scene.control.TextField;
import javafx.scene.control.Label;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class InvestmentValuecalculator extends Application {
    Label lobjInvestmentAmountLabel,lobjAnnualRateOfInterestlabel,lobjYearsLabel,lobjFutureValue;
    TextField lobjYearsText,lobjInvestemntamountText,lobjAnnualRateOfInterestText,lobjFutureText;
    Button lobjCalcuate;
    String lstrYears,lstrRateInterest,lstrInvestementamount,lstrFuturevalue;
    @Override
    public void start(Stage primaryStage) {
      //http://docs.oracle.com/javafx/2/ui_controls/text-field.htm  
        GridPane root = new GridPane();
root.setPadding(new javafx.geometry.Insets(10,10,10,10));
root.setVgap(5);
root.setHgap(5);

 lobjInvestmentAmountLabel = new Label("InvestmentAmount:");
lobjInvestemntamountText = new TextField ();
GridPane.setConstraints(lobjInvestmentAmountLabel, 0, 0);
GridPane.setConstraints(lobjInvestemntamountText, 1, 0);
root.getChildren().add(lobjInvestmentAmountLabel);
root.getChildren().add(lobjInvestemntamountText);

lobjAnnualRateOfInterestlabel = new Label("AnnualRateOfInterest");
lobjAnnualRateOfInterestText = new TextField ();
GridPane.setConstraints(lobjAnnualRateOfInterestlabel, 0, 1);
GridPane.setConstraints(lobjAnnualRateOfInterestText, 1, 1);
root.getChildren().add(lobjAnnualRateOfInterestlabel);
root.getChildren().add( lobjAnnualRateOfInterestText);



lobjYearsLabel = new Label("Years");
lobjYearsText = new TextField ();
GridPane.setConstraints(lobjYearsLabel, 0, 2);
GridPane.setConstraints(lobjYearsText, 1, 2);
root.getChildren().add(lobjYearsLabel);
root.getChildren().add( lobjYearsText);

lobjFutureValue = new Label("FutureValue");
lobjFutureText = new TextField ();
GridPane.setConstraints(lobjFutureValue, 0, 3);
GridPane.setConstraints(lobjFutureText, 1, 3);
root.getChildren().add(lobjFutureValue);
root.getChildren().add( lobjFutureText);
//lobjFutureText.disabledProperty();
 
lobjCalcuate= new Button("Calcuate");
 lobjCalcuate.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
               double lintamount=Double.parseDouble(lobjInvestemntamountText.getText().toString());
               double lstrYears= Double.parseDouble(lobjYearsText.getText().toString());
               double lstrRateInterest=Double.parseDouble(lobjAnnualRateOfInterestText.getText().toString());
                double futurevalue= lintamount*(1+lstrRateInterest);
                double future=Math.pow(futurevalue ,lstrYears*12);
              
               lobjFutureText.setText(String.valueOf(future));
            }
        });

GridPane.setConstraints(lobjCalcuate, 1, 4);

root.getChildren().add(lobjCalcuate);

//root.getChildren().add(lobjInvestemntamountText);
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
    
}
