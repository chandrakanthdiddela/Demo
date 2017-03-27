using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    public static int arraySum(int[] parr)
        {
        int sum=0;
        for(int i=0;i<parr.Length;i++)
            {
            sum =sum+ parr[i];
            
        }
        return sum;
        
    }
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        
        int sum= Solution.arraySum(arr);
        Console.WriteLine(sum);
    }
}