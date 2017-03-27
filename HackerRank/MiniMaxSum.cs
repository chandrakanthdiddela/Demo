using System;
using System.Collections.Generic;
using System.IO;
class Solution {
     static long  sumofArray(Int64[] pinputarr)
        {
      long  sum=0;
        for(int i=0;i<pinputarr.Length; i++)
            {
            sum=sum+pinputarr[i];
        }
        return sum;
    }
    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        String lstrinput = Console.ReadLine();
      Int64[] linputarr= Array.ConvertAll(lstrinput.Split(' '),Int64.Parse);
        
 Array.Sort(linputarr);

 long  sum = Solution.sumofArray(linputarr);
        Console.Write((sum-linputarr[linputarr.Length-1]) + " " + (sum-linputarr[0]));
       
        
            
    }
}