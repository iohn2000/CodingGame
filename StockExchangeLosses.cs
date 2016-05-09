using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**


Actually you just have to keep track of max value and max loss (delta, diff... what ever you want to call it).
All other variables are just "clutter" because next value will either be new maximum or something you want to subtract from max.
Reply as linked Topic
magaiti
3d

Yes. an obvious naive implementation in O(n^2) is to compare all pairs of values. 
Next logical step is to only compare a value with all the preceding ones. 
Then, you are only interested in one preceding value - the maximum one. 
And as you go from current minimum candidate to the next, 
there is only one way for the preceding maximum to change - if the previous minimum candidate is the new maximum. 
As it is the only value added to the set of preceding ones from the previous step.
ement.
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
