using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    public static int[] compare( int[] pa,int[] pb)
        {
        int Alicescore=0;
        int BobScore=0;
        int[] scores={0,0};
        for(int i=0;i<3;i++)
            {
            
        
        if(pa[i]>=1 && pa[i]<=100 && pb[i]>=1 && pb[i]<=100)
            {
            
            if(pa[i]==pb[i])
                {
                Alicescore=  Alicescore+0;
                BobScore= BobScore+0;
                
            }
            if(pa[i]>pb[i])
                {
                 Alicescore=Alicescore+1;
            }
            
            if(pa[i]<pb[i])
                {
                 BobScore=BobScore+1;
                
            }
         
            
        }
        else
            {
            Console.WriteLine("Invalid input");
        }
        }
        scores[0]=Alicescore;
        scores[1]=BobScore;
        return scores;
        
    }
    static void Main(String[] args) {
        string[] tokens_a0 = Console.ReadLine().Split(' ');
        int a0 = Convert.ToInt32(tokens_a0[0]);
        int a1 = Convert.ToInt32(tokens_a0[1]);
        int a2 = Convert.ToInt32(tokens_a0[2]);
        string[] tokens_b0 = Console.ReadLine().Split(' ');
        int b0 = Convert.ToInt32(tokens_b0[0]);
        int b1 = Convert.ToInt32(tokens_b0[1]);
        int b2 = Convert.ToInt32(tokens_b0[2]);
        int[] alicearray={a0,a1,a2};
        int[] bobarray={b0,b1,b2};
        int [] scores =compare(alicearray,bobarray);
        
        for(int i=0;i<scores.Length;i++)
            {
            Console.Write(scores[i]+" ");
        }
    }
}