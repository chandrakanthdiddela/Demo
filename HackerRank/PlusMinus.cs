using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    public static double[] PlusMinusTest(int[] parr)
        {
        int pcount=0,ncount=0,zcount=0;
        double [] values = {0.0,0.0,0.0};
        for(int i=0;i<parr.Length;i++)
            {
            if(parr[i]>0)
                {
                pcount=pcount+1;
            }
            else if(parr[i]<0)
                {
                ncount=ncount+1;
            }
            else if (parr[i]==0)
                {
                zcount=zcount+1;
            }
        }
        
        double pvalue= (double)pcount/parr.Length;
        values[0]=pvalue;
        double nvalue = (double)ncount/parr.Length;
        values[1]=nvalue;
        double zvalue= (double)zcount/parr.Length;
        values[2]=zvalue;
        return values;
        
    }
    
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        double[] values=PlusMinusTest(arr);
        for(int i=0;i<values.Length;i++)
            {
            Console.WriteLine(values[i]);
        }
    }
}