using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
public static void printStairCase(int n)
    {
       for (int i = 0; i < n; i++)
        {
            for (int j = n - i-1; j > 0; j--)
                Console.Write(" ");
            for (int k = 0; k <= i;k++ )
                Console.Write("#");
            Console.WriteLine();
        }
    
}
    
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        printStairCase(n);
    }
}
