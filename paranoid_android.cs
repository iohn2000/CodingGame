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
            Dictionary<int,int> gateways = new Dictionary<int,int>();
        	//List<int> elevators = new List<int> ();
            int stepsLeadingCloneDone = 0;

			//--------------------------------------------------
			string[] inputs;
			inputs = Console.ReadLine().Split(' ');

			int nbFloors = int.Parse(inputs[0]); // number of floors
			int width = int.Parse(inputs[1]); // width of the area
			int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
			int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
			int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
			int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
			int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
			int nbElevators = int.Parse(inputs[7]); // number of elevators
			
			Console.Error.WriteLine("Floors : " + nbFloors.ToString());
			Console.Error.WriteLine("Width : " + width.ToString());
			Console.Error.WriteLine("exitFloor : " + exitFloor.ToString());
			Console.Error.WriteLine("exitPos : " + exitPos.ToString());
            Console.Error.WriteLine("count elevators : " + nbElevators.ToString());
			// ------------------------------

			for (int i = 0; i < nbElevators; i++)
			{
				inputs = Console.ReadLine().Split(' ');
				int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
				int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor
			
				gateways.Add(elevatorFloor,elevatorPos);
				Console.Error.WriteLine("ElevatorPOS : " + elevatorPos.ToString());
			}
			
			gateways.Add(exitFloor, exitPos);
			Console.Error.WriteLine("count elevators : " + gateways.Count.ToString());
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
            int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
            
            Console.Error.WriteLine(" cloneFloor : " + cloneFloor.ToString());
            Console.Error.WriteLine(" clonePos : " + clonePos.ToString());
            Console.Error.WriteLine(" direction : " + direction.ToString());
            //Console.Error.WriteLine("floor:" + cloneFloor.ToString() + " pos:" + clonePos.ToString());
            
            int gatewayPOS = -1; 
            if (gateways.ContainsKey(cloneFloor))
                gatewayPOS = gateways[cloneFloor];

            Console.Error.WriteLine("floor:" + cloneFloor.ToString() + " pos:" + clonePos.ToString() + " elevators[cloneFloor] : " + gatewayPOS.ToString());
            
            if (clonePos == -1 && cloneFloor == -1)
            {
                Console.WriteLine("WAIT");
                continue;
            }
            
            if (
                (clonePos < gatewayPOS && direction == "LEFT") ||
                (clonePos > gatewayPOS && direction == "RIGHT")
                )
            {
                Console.WriteLine("BLOCK");
                continue;
            }

            Console.WriteLine("WAIT");
        }
    }
}