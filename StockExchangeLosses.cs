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


		List<int> sortedMax = new List<int>(stocks);
		sortedMax.Sort((x,y)=> y.CompareTo(x));

		Console.Error.Write("\r\nSorted List :");
		foreach (int i in sortedMax) Console.Error.Write(i.ToString()+ ", ");
		Console.Error.WriteLine("");

		int min, maxLoss = 0, indexMin, indexMax;

		Console.Error.Write("\r\nReverse Max : ");
		for (int reversIndx = sortedMax.Count - 1; reversIndx > -1; reversIndx--) 
		{
			Console.Error.Write (sortedMax[reversIndx].ToString() + ", ");
			min = sortedMax [reversIndx];
			indexMin = stocks.IndexOf(min);
			foreach (int maxValue in sortedMax)
			{
				indexMax = stocks.IndexOf(maxValue);
				if (indexMax < indexMin)
				{
					maxLoss = Math.Min(maxLoss, (maxValue - min) * -1);
					break;
				}
			}
		}


		Console.Error.WriteLine ("\r\n");
		Console.WriteLine(maxLoss.ToString());
	}
}
