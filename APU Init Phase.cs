using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    static void Main(string[] args)
    {
        List<coords> powerCells = new List<coords>();
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        int[,] theGrid = new int[height,width];
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            for (int col=0; col<line.Length; col++)
            {
                if (line.Substring(col,1) == ".")
                    theGrid[i,col] = 0;
                else
                {
                    theGrid[i,col] = 1;
                    // save coord for later
                    powerCells.Add(new coords(i,col));
                }
            }
        }
        
        foreach (coords node in powerCells)
        {
            // check for right neighbour
            string rCoord = "-1 -1";
            List<coords> r = powerCells.FindAll(m => ( m.row == node.row & m.col > node.col ));
            if (r != null && r.Count > 0)
            {
                
                rCoord = (r[0].col).ToString() + " " + r[0].row.ToString();
            }
            
            
            string bCoord = "-1 -1";
            List<coords> b = powerCells.FindAll(m => ( m.row > node.row & m.col == node.col ));
            if (b != null && b.Count > 0)
            {
                
                bCoord = (b[0].col).ToString() + " " + b[0].row.ToString();
            }            
        
            Console.WriteLine (node.col.ToString() + " " + node.row.ToString() + " " + rCoord + " " + bCoord);
            
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

       
    }
}

	public class coords
	{
		public int row;
		public int col;
		public coords(int row, int col)
		{
			this.row = row;
			this.col = col;
		
		}

	}