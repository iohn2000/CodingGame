using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        List<int> horses = new List<int>();
        
        int N = int.Parse(Console.ReadLine());
        int oldDiff = int.MaxValue;
        
        for (int i = 0; i < N; i++)
            horses.Add(int.Parse(Console.ReadLine()));
       
       horses.Sort();
        
        for (int outter=0; outter<N-1; outter++)
        {
                int diff = Math.Abs(horses[outter] - horses[outter+1]);
                
                if (diff < oldDiff) oldDiff = diff;
                    
                if (oldDiff == 1)  break;
        }

        Console.WriteLine(oldDiff);
    }
}