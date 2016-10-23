/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package quiz7;

/**
 *
 * @author Varnith
 */


public class Quiz7 {

    public static int countUppercaseLetter(String s) {
    if (s.length() == 0) return 0;
    int lintcap = Character.isUpperCase(s.charAt(0)) ? 1 : 0;
    return countUppercaseLetter(s.substring(1)) + lintcap;
}
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        
        System.out.println("number of capital letters"+  Quiz7.countUppercaseLetter("ChandraKANTH"));
        
    }
    
}
