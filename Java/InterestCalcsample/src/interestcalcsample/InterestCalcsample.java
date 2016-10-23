/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package interestcalcsample;

/**
 *
 * @author Varnith
 */
public class InterestCalcsample {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        double prinicpal=10000,interest=5,time=5,amount,SI,totalpayment;
        double additionalinterest=0.125;
        System.out.println("InterestRate" + "   " +"monthlypayment" + "  " +"TotalPayment");
        for (int i=0;i<15;i++)
        {
            SI=prinicpal*time*interest;
            SI=SI/100;
            totalpayment=prinicpal+SI;
            interest=interest+additionalinterest;
            System.out.println(interest + "            "+SI +"      "+interest);
            
        }
        
    }
    
}
