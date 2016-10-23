/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package rsa;

import java.math.BigInteger;
import java.security.SecureRandom;
import static java.util.Collections.max;
import static java.util.Collections.min;
import java.util.Random;
import java.util.Scanner;

/**
 *
 * @author Varnith
 */
public class RSA {
 


  public  BigInteger encrypt(BigInteger message,BigInteger e,BigInteger modulus ) 
  {
      return message.modPow(e, modulus);
   }

  public  BigInteger decrypt(BigInteger encrypted,BigInteger d,BigInteger modulus) {
      return encrypted.modPow(d, modulus);
   }

  
 
   public static void main(String[] args) {
       
RSA key = new RSA();
    
       BigInteger one      = new BigInteger("1");
       Scanner lobj = new Scanner(System.in);
       System.out.println("enter p value");
       BigInteger p= lobj.nextBigInteger() ;
       System.out.println("enter q value");
       BigInteger q= lobj.nextBigInteger() ;
        BigInteger phi = (p.subtract(one)).multiply(q.subtract(one));
    System.out.println("phi value is ="+ phi);
     BigInteger modulus    = p.multiply(q);
       System.out.println("modulus = "+ modulus);
      
  
      BigInteger e = new BigInteger("7");//BigInteger.valueOf(15);
       System.out.println(e);
        while (phi.gcd(e).compareTo(BigInteger.ONE) > 0 && e.compareTo(phi) < 0)
        {
            e.add(BigInteger.ONE);
        }
        //System.out.println("out of phi");
           BigInteger d= e.modInverse(phi);
           System.out.println("d value is = "+d);
            BigInteger message = new BigInteger("35");

   
 BigInteger encrypt = key.encrypt(message, e, modulus);
      BigInteger decrypt = key.decrypt(encrypt, d, modulus);
     
      System.out.println("message   = " + message);
      System.out.println("encrypted = " + encrypt);
      System.out.println("decrypted = " + decrypt);
        
}
   
}
