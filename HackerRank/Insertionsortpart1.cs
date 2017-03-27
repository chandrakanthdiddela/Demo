using System;
using System.Collections.Generic;
using System.IO;
class Solution {
static void insertionSort(int[] ar) {

     int newelement = ar[ar.Length - 1];
        for(int i=ar.Length-1;i>=0;i--)
        {
               if(i==0)
            {
                ar[0] = newelement;
                break;
            }
            if (ar[i-1] > newelement)
            {
                ar[i] = ar[i-1];

            }
            else
            {
                ar[i] = newelement;
                break;
            }

            for (int j = 0; j< ar.Length; j++)
            {
                Console.Write(ar[j] + " ");
            }
            Console.WriteLine();
        }

}
/* Tail starts here */
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
        for (int j = 0; j < _ar.Length; j++)
        {
            Console.Write(_ar[j] + " ");
        }
    }
}