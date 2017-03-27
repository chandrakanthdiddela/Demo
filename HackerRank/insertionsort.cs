using System;
using System.Collections.Generic;
using System.IO;
class Solution {
static void insertionSort(int[] ar) {
for(int i=0;i<=ar.Length;i++)
            {
                int j = 0;
                int count = 0;
                for(j=i+1;j>0 && ar.Length>j;j--)
                {
                    count = count + 1;
                   
                    if(ar[j]<ar[j-1])
                    {
                        int temp = ar[j-1];
                        ar[j-1] = ar[j];
                        ar[j] = temp;
                      
                    }

                }
                if (ar.Length > count && count>0)
                {
                    //Console.WriteLine("Value of J" + count);
                    count = 0;
                    for (int k = 0; k < ar.Length; k++)
                    {
                        Console.Write(ar[k] + " ");
                    }
                    Console.WriteLine();
                }
               
               
            }

}
static void Main(String[] args) {
           
           int _ar_size;
           _ar_size = Convert.ToInt32(Console.ReadLine());
           int [] _ar =new int [_ar_size];
           String elements = Console.ReadLine();
           String[] split_elements = elements.Split(' ');
           for(int _ar_i=0; _ar_i < _ar_size; _ar_i++) {
                  _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]); 
           }

           insertionSort(_ar);
    }
}
