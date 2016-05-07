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
    private static int jumpValueY = -1;
    private static int jumpValueX = -1;
    private static int H,W;
    
    public static int moveUp(int yPos)
    {
        if (jumpValueY == -1)
	        jumpValueY = (int)Math.Ceiling((double)yPos / 2.0);
	    else
	        jumpValueY = (int)Math.Ceiling((double)jumpValueY / 2.0);
	        
	    if (jumpValueY == 0)
	        jumpValueY = 1;
	        
		yPos = yPos - jumpValueY; 
		return yPos;
    }
    
    public static int moveDown(int yPos)
    {
        if (jumpValueY == -1)
	        jumpValueY =  (int)Math.Ceiling(((double)H - (double)yPos)/2.0);
	    else
	        jumpValueY = (int)Math.Ceiling((double)jumpValueY / 2.0);
		
		if (jumpValueY == 0)
	        jumpValueY = 1;  
	        
	    yPos = yPos + jumpValueY;   
	    if (yPos >= H)
	        yPos = H-1;
	    return yPos; 
    }
    
    public static int moveRight(int xPos)
    {
        if (jumpValueX == -1)
            jumpValueX = (int)Math.Ceiling( ((double)W - (double)xPos  ) / 2.0);
        else
            jumpValueX = (int)Math.Ceiling((double)jumpValueX / 2.0);
            
        if (jumpValueX == 0)
            jumpValueX = 1;
        
        xPos += jumpValueX;
        if (xPos >= W)
            xPos=W-1;
        return xPos;
    }
    
    public static int moveLeft(int xPos)
    {
        if (jumpValueX == -1)
            jumpValueX = (int)Math.Ceiling( ((double)xPos - 1.0  ) / 2.0);
        else
            jumpValueX = (int)Math.Ceiling((double)jumpValueX / 2.0);
            
        if (jumpValueX == 0)
            jumpValueX = 1;
        
        xPos -= jumpValueX;
        return xPos;        
    }
	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		W = int.Parse(inputs[0]); // width of the building.
		H = int.Parse(inputs[1]); // height of the building.
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
			
			switch (bombDir) {
			case "U": 
			    Y0 = moveUp(Y0);
				break;
				
			case "UR":
				Y0 = moveUp(Y0);
				X0 = moveRight(X0);
				break;
			case "R":
				X0 = moveRight(X0);
				break;
				
			case "DR":
				Y0 = moveDown(Y0);
				X0 = moveRight(X0);
				break;
			case "D":
                Y0 = moveDown(Y0);
				break;
				
			case "DL":
				Y0 = moveDown(Y0);
				X0 = moveLeft(X0);
				break;
				
			case "L":
				X0 = moveLeft(X0);
				break;
				
			case "UL":
				Y0 = moveUp(Y0);
				X0 = moveLeft(X0);
				break;
			default:
				break;
			}


			// the location of the next window Batman should jump to.
			Console.WriteLine(string.Format("{0} {1}",X0,Y0));
		}
	}
}