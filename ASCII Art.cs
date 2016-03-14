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
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine().ToUpperInvariant();
        
        byte[] letterAscii = Encoding.ASCII.GetBytes(T);
        string[] asciiRows = new string[H];
        
        string[] resultRows = new string[H];
        
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            asciiRows[i] = ROW;
        }
        
        foreach (byte letterByte in letterAscii)
        {
            byte byteValue =  letterByte;
            
            if (letterByte < 65 | letterByte > 90)
                byteValue  = 91;
                
            int startPos = L * (byteValue - 65);
            for (int r = 0; r < H; r++)
            {
                string letterPart = asciiRows[r].Substring(startPos,L);
                resultRows[r] += letterPart;
            }
        }
        
        for (int r = 0; r < H; r++)
            Console.WriteLine(resultRows[r]);
    }
}