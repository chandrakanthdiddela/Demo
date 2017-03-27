using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

   public static long sumbig(int[] parr_temp)
       {
       long sum=0;
       for(int i=0;i<parr_temp.Length;i++)
           {
           if(parr_temp[i]>=0 && parr_temp[i]<=Math.Pow(10,10))
           sum=sum+parr_temp[i];
           
       }
       
       return sum;
   }
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        if(n>=0 && n<=10)
            {
              string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        Console.WriteLine(sumbig(arr));
        }
      
    }
}
