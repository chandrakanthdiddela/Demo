using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
 public static int checkGrade(int pgrade)
    {
      
        int nrmultipleoffive= ((pgrade / 5) +1 )*5;
        int diff = nrmultipleoffive - pgrade;
        int finalvalue = pgrade;

        if ((diff) <= 2 || pgrade%5==0)
        {
            if(pgrade>37)
            {if(diff==5)
                {
                    finalvalue = pgrade;
                }
                else
                {
                    finalvalue = pgrade + diff;
                }
            }
        }
        return finalvalue;
    }


    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        for (int a0 = 0; a0 < arr.Length; a0++)
        {
            int grade = Convert.ToInt32(Console.ReadLine());
            
            if(grade>=0 && grade<=100)
            {
           arr[a0]=   Solution.checkGrade(grade);
             //Console.WriteLine(value);
            }

        }
        for (int i = 0; i < arr.Length;i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
