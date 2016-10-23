/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package simpletraingle;

/**
 *
 * @author Varnith
 */
public class SimpleTraingle extends  GeometricObject {

    
    double side1,side2,side3;
    
    public SimpleTraingle()
    {
        side1=1;
        side2=1;
        side3=1;
    }
    
    public SimpleTraingle( double pside1, double pside2,double pside3)
    {
         side1=pside1;
        side2=pside2;
        side3=pside3;
    }
    
    public double area()
    {
        double larea=0;
        double p=(side1+side2+side3)/2;
        
        double lobj= p*(p-side1)*(p-side2)*(p-side3);
         larea=Math.sqrt(lobj);
        return larea;
    }
    
    public double perimeter()
    {
        double lperimeter=0;
        lperimeter=(side1+side2+side3)/2;
        return lperimeter;
                
    }
    public String toString()
    {
      return "Triangle: side1 = " + side1 + " side2 = " + side2 +
 " side3 = " + side3;

    }
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try
        {
        // TODO code application logic here 
        
        SimpleTraingle lobjTraingle= new SimpleTraingle();
        
        System.out.println("Area of triangle with defalut constructor:"+ lobjTraingle.area());
        
        System.out.println("Perimeter of triangle with defalut constructor:"+ lobjTraingle.perimeter());
        lobjTraingle.toString();
        
        SimpleTraingle lobjTraingle1= new SimpleTraingle(3,4,5);
        
        System.out.println("Area of triangle with defalut constructor:"+ lobjTraingle1.area());
        
        System.out.println("Perimeter of triangle with defalut constructor:"+ lobjTraingle1.perimeter());
        
        lobjTraingle1.toString();
    }
        catch(Exception lobjException)
        {
            System.out.println("exception:"+ lobjException.getMessage());
        }
    }
    
}
