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
class Player
{
	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int W = int.Parse(inputs[0]); // width of the building.
		int H = int.Parse(inputs[1]); // height of the building.
		int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
		inputs = Console.ReadLine().Split(' ');
		int X0 = int.Parse(inputs[0]);
		int Y0 = int.Parse(inputs[1]);

		Console.Error.WriteLine("width : " + W.ToString());
		Console.Error.WriteLine("height : " + H.ToString());
		Console.Error.WriteLine("turns : " + N.ToString());
		Console.Error.WriteLine("X0 : " + X0.ToString());
		Console.Error.WriteLine("Y0 : " + Y0.ToString());

		// game loop
		while (true)
		{
			string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
			Console.Error.WriteLine("bombDir : " + bombDir);
			/*
			    U (Up)
			    UR (Up-Right)
			    R (Right)
			    DR (Down-Right)
			    D (Down)
			    DL (Down-Left)
			    L (Left)
			    UL (Up-Left)
			*/

			switch (bombDir) {
			case "U": 
				Y0--; 
				break;
			case "UR":
				Y0--;
				X0++;
				break;
			case "R":
				X0++;
				break;
			case "DR":
				Y0++;
				X0++;
				break;
			case "D":
				Y0++;
				break;
			case "DL":
				Y0++;
				X0--;
				break;
			case "L":
				X0--;
				break;
			case "UL":
				Y0--;
				X0--;
				break;
			default:
				break;
			}


			// the location of the next window Batman should jump to.
			Console.WriteLine(string.Format("{0} {1}",X0,Y0));
		}
	}
}