package warpack;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;

public class Solution {
	
	public static enum PlayerNumber { Player1, Player2, PAT };
	private int roundsPlayed = 0;
	private HashMap<String,Integer> mapperCardValue = new HashMap<String,Integer>();
	ArrayList<String> player1Cards = new ArrayList<String>();
	ArrayList<String> player2Cards = new ArrayList<String>();
		
	public Solution() 
	{
		for (int idx=2; idx<11; idx++)
			mapperCardValue.put(Integer.toString(idx), idx);
		mapperCardValue.put("J", 11);
		mapperCardValue.put("Q", 12);
		mapperCardValue.put("K", 13);
		mapperCardValue.put("A", 14);
	}
	
	private void addCardToPlayerStack(PlayerNumber p, String card)
	{
		this.addCardToPlayerStack(p, Arrays.asList(card));
	}
	private void addCardToPlayerStack(PlayerNumber p, List<String> warStack)
	{
		switch (p) 
		{
		case Player1:
			player1Cards.addAll(warStack);
			break;
		case Player2:
			player2Cards.addAll(warStack);
			break;
		}		
	}
	
	private int getCardValue(String card)
	{
		//ignore suit 
		String c = card.substring(0,card.length()-1);
		int v = this.mapperCardValue.get(c);
		return v;
	}
	private String takeCardFromPlayerStack(int amountCards, List<String> playerCards, List<String> warStack)
	{
		String newCard = "";
		for (int idx=0; idx<amountCards; idx++)
		{
			newCard = playerCards.get(0);
			playerCards.remove(newCard);
			warStack.add(newCard);	
		}
		return newCard;
	}
	public PlayerNumber CalcWinner(String p1C, String p2C)
	{
		int v1 = this.getCardValue(p1C);
		int v2 = this.getCardValue(p2C);
		int result = v1-v2;
		if (result > 0)
		{
			return PlayerNumber.Player1;
		}
		else if (result < 0)
		{
			return PlayerNumber.Player2;
		}
		else
			return PlayerNumber.PAT;
	}
	
	public void DoBattle()
	{
		PlayerNumber winner;
		int amountofWarRounds = 0;
		String p1Card, p2Card;
		ArrayList<String> p1WarStack = new ArrayList<String>();
		ArrayList<String> p2WarStack = new ArrayList<String>();
		
		//take card out of players stack
		p1Card = this.takeCardFromPlayerStack(1,this.player1Cards, p1WarStack);
		p2Card = this.takeCardFromPlayerStack(1,this.player2Cards, p2WarStack);
		
		while (  (winner = this.CalcWinner(p1Card, p2Card)) == PlayerNumber.PAT )
		{
			amountofWarRounds++;
			// running out of cards --> PAT
			if (this.player1Cards.size() < 4 | this.player2Cards.size() < 4)
			{
				this.player1Cards.clear();
				this.player2Cards.clear();
				return;
			}
			
			// play a round of war
			this.takeCardFromPlayerStack(3, this.player1Cards, p1WarStack);
			this.takeCardFromPlayerStack(3, this.player2Cards, p2WarStack);
				
			// draw cards one each again
			//take card out of players stack
			p1Card = this.takeCardFromPlayerStack(1,this.player1Cards, p1WarStack);
			p2Card = this.takeCardFromPlayerStack(1,this.player2Cards, p2WarStack);
		}
		
		if (amountofWarRounds == 0)
		{
			this.addCardToPlayerStack(winner, p1Card);
			this.addCardToPlayerStack(winner, p2Card);			
		}
		else
		{
			// games of war happened, give warStacks and cards to winner
			this.addCardToPlayerStack(winner, p1WarStack);
			this.addCardToPlayerStack(winner, p2WarStack);		
		}
		

	}
	
	public String PlayGameOfWar()
	{
		String result  ="";
		do  
		{
			this.DoBattle();
			this.roundsPlayed++;
			
		} while (this.player1Cards.size() > 0  & this.player2Cards.size() > 0);
		
		
		if (this.player1Cards.size() > 0)
			result = "1 " + Integer.toString(this.roundsPlayed);
		
		if (this.player2Cards.size() > 0)
			result = "2 " + Integer.toString(this.roundsPlayed);
		
		if (this.player1Cards.size() == 0 & this.player2Cards.size() == 0)
			result = "PAT";
		
		return result;
	}

	public static void main(String[] args) 
	{
		Solution w = new Solution();
		
		Scanner in = new Scanner(System.in);
        int n = in.nextInt(); // the number of cards for player 1
        for (int i = 0; i < n; i++) {
            String card = in.next(); // the n cards of player 1
            w.addCardToPlayerStack(PlayerNumber.Player1, card);
        }
        int m = in.nextInt(); // the number of cards for player 2
        for (int i = 0; i < m; i++) {
            String card = in.next(); // the m cards of player 2
            w.addCardToPlayerStack(PlayerNumber.Player2, card);
        }

        // Write an action using System.out.println()
        // To debug: System.err.println("Debug messages...");

		
		String result = w.PlayGameOfWar();
        
        System.out.println(result);

	}
}
/*
3
AD
KC
QC
3
KH
QS
JC
1 3
*/

/*
26
6H
7H
6C
QS
7S
8D
6D
5S
6S
QH
4D
3S
7C
3C
4S
5H
QD
5C
3H
3D
8C
4H
4C
QC
5D
7D
26
JH
AH
KD
AD
9C
2D
2H
JC
10C
KC
10D
JS
JD
9D
9S
KS
AS
KH
10S
8S
2S
10H
8H
AC
2C
9H
2 56

----
Battle

5
8C
KD
AH
QH
2S
5
8D
2D
3H
4D
3S

2 1
--------




*/
