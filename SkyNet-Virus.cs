/*
 * Created by SharpDevelop.
 * User: johannes
 * Date: 11.02.2016
 * Time: 20:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace asfsf
{
	class Program
	{

		
		static void Main(string[] args)
		{

			AgentStopper agSt = new AgentStopper();
			
			List<int> skynetMoves = new List<int>(){ 6, 3, 0 };
			
			foreach (int move in skynetMoves)
			{
				string cut = agSt.DecideCut(move);
				
				Console.WriteLine(cut);
			}
			
			Console.ReadLine();
		}
    
		
	}
	
	class AgentStopper
	{
		public List<Node> network = new List<Node>();
		public List<Node> gateways = new List<Node>();

		void createNode(string n)
		{
			bool exists = network.Exists(m => m.indexNr == int.Parse(n));
			if (!exists)
				network.Add(new Node(int.Parse(n)));
		}
		
		void setupLink(string n1, string n2)
		{
			Node node1 = network.Find(m => m.indexNr == int.Parse(n1));
			Node node2 = network.Find(m => m.indexNr == int.Parse(n2));
			
			//link node1 to node2
			node1.links.Add(node2);
			
			// link node2 tp node1
			node2.links.Add(node1);
		}
		
		void markGateWays(List<int> gw)
		{
			foreach (int gwidx in gw)
			{
				Node n = network.Find(m => m.indexNr == gwidx);
				n.isGateway = true;
				this.gateways.Add(n);
			}
		}
		
		void cutLink(Node n1, Node n2)
		{
			Node linked1 = n1.links.Find(m => m.indexNr == n2.indexNr);
			n1.links.Remove(linked1);
			
			Node linke2 = n2.links.Find(m => m.indexNr == n1.indexNr);
			n2.links.Remove(linke2);
		}
		
		public AgentStopper()
		{
			int N = 7; // the total number of nodes in the level, including the gateways
			int L = 12; // the number of links
			int E = 1; // the number of exit gateways
			
			List<string> linkList = new List<string>() {
				"0 1",
				"0 2",
				"0 3",
				"0 4",
				"0 5",
				"1 2",
				"2 3",
				"3 4",
				"4 5",
				"6 4",
				"6 3",
				"6 2"
			};
			

			
			
			foreach (string link in linkList)
			{
				string[] n = link.Split(' ');
				
				createNode(n[0]);
				createNode(n[1]);
				setupLink(n[0], n[1]);
				
			}
			
			
			List<int> exitGatewaysIdx = new List<int>();
			exitGatewaysIdx.Add(0);
			this.markGateWays(exitGatewaysIdx);
			
		}
		
		public string DecideCut(int skynetPos)
		{
			string theCut = "";
			// decide which link to cut
			Node gateway = this.searchGateway(skynetPos);
			
			if (gateway != null)
			{
				Node skynet = this.network.Find(m => m.indexNr == skynetPos);
				theCut = skynetPos.ToString() + " " + gateway.indexNr.ToString();
				this.cutLink(skynet, gateway);
			}
			else
			{
				//no gateway within one step reach
				// pick an outgoing link from a gatway
				Node gw = this.gateways.Find(m => m.links.Count > 0);
				if (gw != null)
				{
					theCut = gw.indexNr.ToString() + " " + gw.links[0].indexNr.ToString();
					this.cutLink(gw,gw.links[0]);
				}
				
			}
			
			return theCut;
		}
		
		private Node searchGateway(int nodePos)
		{
			// search 1 level only
			Node n = network.Find(m => m.indexNr == nodePos);
			Node gateway = n.links.Find(m => m.isGateway);
			if (gateway != null)
				return gateway;
			else
				return null;
		}
		
	}
	
	public class Node
	{
		public bool isGateway = false;
		public int indexNr;
		public List<Node> links;
		public Node(int indexNr)
		{
			this.indexNr = indexNr;
			this.links = new List<Node>();
		}
	}
}