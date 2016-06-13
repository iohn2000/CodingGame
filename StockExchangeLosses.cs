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
		List<int> stocks = new List<int>();

		int n = int.Parse(Console.ReadLine());
		string[] inputs = Console.ReadLine().Split(' ');
		for (int i = 0; i < n; i++)
		{
			int v = int.Parse(inputs[i]);
			Console.Error.Write (inputs[i] + ", ");
			stocks.Add(v);
		}

        int currentMax = int.MinValue;
        int currentDelta = 0;
        // only one loop O(n)
        Console.Error.WriteLine ("\r\n");
        for (int idx =0; idx < n-1; idx++)
        {
            
            currentMax = Math.Max(currentMax,stocks[idx]);
            Console.Error.WriteLine("new Max = " + currentMax.ToString());
            
            int newDelta = currentMax - stocks[idx+1];
            Console.Error.WriteLine("new Delta = " + newDelta.ToString());
            
            
            
            currentDelta = Math.Max(currentDelta,newDelta);
            Console.Error.WriteLine("current MaxDelta =" + currentDelta.ToString());
            
            
        }
        currentDelta *= -1;
		Console.WriteLine(currentDelta.ToString());
	}
}
