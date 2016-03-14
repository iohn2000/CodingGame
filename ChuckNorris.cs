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
    static string encodedStr = "";
    static void Main(string[] args)
    {
        string MESSAGE = Console.ReadLine();
        
        // get byte code for each letter
        byte[] msgAscii = Encoding.ASCII.GetBytes(MESSAGE);
        string binaryMsg = "";
        
        foreach (byte msgByte in msgAscii)
        {
            string binaryString = Convert.ToString(msgByte,2);
            binaryString = binaryString.PadLeft(7,'0');
            binaryMsg += binaryString;
            Console.Error.WriteLine("binary string : " + binaryString);
        }
        
        // now to run time length encoding
        encodeOnePart(binaryMsg);
        Console.WriteLine(encodedStr.Trim());
    }
    
    public static void encodeOnePart(string msgStr)
		{
			string prefix = "";
			string estr = "";
			int counter = 0;
			//get first char 
			string firstChar = msgStr.Substring(0, 1);
        
			//count how ofte its there in a row
			for (int idx = 1; idx < msgStr.Length; idx++)
			{
				if (msgStr.Substring(idx, 1) != firstChar)
					break;
				counter = idx;
			}
        
			if (firstChar == "1")
				prefix = "0 ";
			else
				prefix = "00 ";
            
			estr = prefix + estr + "".PadLeft(counter + 1, '0');
        
			encodedStr += estr + " ";
        
			Console.Error.WriteLine("Count:" + (counter + 1).ToString() + " Code : " + estr);
        
			// cut string and call yourself
			string newMsgStr = msgStr.Substring(counter + 1);
			if (newMsgStr.Length > 0)
				encodeOnePart(newMsgStr);
		}
}