/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minterestcalc;


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
import javafx.scene.layout.VBox;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;
import javafx.stage.Stage;

/**
 *
 * @author Varnith
 */
public class MInterestCalc extends Application {
    
     Label lobjLoanAmountLabel,lobjLoanPeriod;
    TextField lobjAmountText,lobjLoanText;
    Button lobjCalcuate;
    @Override
    public void start(Stage primaryStage) {
      StackPane root = new StackPane();
      HBox hbox = new HBox();
        hbox.setPadding(new javafx.geometry.Insets(15, 12, 15, 12));
        hbox.setSpacing(10);
 
    GridPane root1 = new GridPane();
root1.setPadding(new javafx.geometry.Insets(10,10,10,10));
root1.setVgap(5);
root1.setHgap(5);

 lobjLoanAmountLabel = new Label("LoanAmount:");
lobjAmountText = new TextField ();
GridPane.setConstraints(lobjLoanAmountLabel, 0, 0);
GridPane.setConstraints(lobjAmountText, 0, 1);
root1.getChildren().add(lobjLoanAmountLabel);
root1.getChildren().add(lobjAmountText);

lobjLoanPeriod = new Label("Period");
lobjLoanText = new TextField ();
GridPane.setConstraints(lobjLoanPeriod, 1, 0);
GridPane.setConstraints(lobjLoanText, 1, 1);
root1.getChildren().add(lobjLoanPeriod);
root1.getChildren().add( lobjLoanText);
lobjCalcuate= new Button("ShowTable");
 lobjCalcuate.setOnAction(new EventHandler<ActionEvent>() {
            
            @Override
            public void handle(ActionEvent event) {
     VBox vbox = new VBox();
    vbox.setPadding(new Insets(10));
    vbox.setSpacing(8);
    TextArea lobjTextArea= new TextArea();
    vbox.getChildren().add(lobjTextArea);           
    root.getChildren().add(vbox);
    
            double prinicpal=Double.parseDouble(lobjAmountText.getText().toString());
          //  double time= Double.parseDouble(lobjLoanText.getText().toString());
              double time=5;
             double interest=5,amount,SI,totalpayment;
        double additionalinterest=0.125;
        String header="InterestRate" + "   " +"monthlypayment" + "  " +"TotalPayment"+"\n";
        lobjTextArea.appendText(header);
        //lobjTextArea.appendText("\n");
       // System.out.println("InterestRate" + "   " +"monthlypayment" + "  " +"TotalPayment");
        for (int i=0;i<15;i++)
        {
            SI=prinicpal*time*interest;
            SI=SI/100;
            totalpayment=prinicpal+SI;
            interest=interest+additionalinterest;
            String eachline=interest + "            "+SI +"      "+totalpayment +"\n";
             lobjTextArea.appendText(eachline);
            
        }
            }
        });

GridPane.setConstraints(lobjCalcuate, 1, 4);

root1.getChildren().add(lobjCalcuate);

    hbox.getChildren().addAll(root1);
        
        Scene scene = new Scene(root, 300, 250);
        
        primaryStage.setTitle("Hello World!");
        primaryStage.setScene(scene);
        primaryStage.show();
        root.getChildren().add(hbox);
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
}
