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
        string LON = Console.ReadLine().Replace(",",".");
        string LAT = Console.ReadLine().Replace(",",".");
        int N = int.Parse(Console.ReadLine());
        
        				double longA = double.Parse(LON);
				double latA = double.Parse(LAT);
       
       string solution = "";
	   double oldDistance = double.MaxValue;
	   
	   
       for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            Console.Error.WriteLine(DEFIB);
            
            string[] data = DEFIB.Split(new String[]{ ";" }, StringSplitOptions.None);
				

				double longB = double.Parse(data[4].Replace(",","."));
				double latB = double.Parse(data[5].Replace(",","."));
				
				double x = (longB - longA) * Math.Cos((latA + latB) / 2.0d);
				double y = latB - latA;
							
				double distance = Math.Sqrt((x * x) + (y * y)) * 6371;
				
				Console.Error.WriteLine(distance.ToString());
				
				if (distance < oldDistance)
				{
					oldDistance = distance;
					solution = data[1];
				}            
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(solution);
    }
}