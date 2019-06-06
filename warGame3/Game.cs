using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameTOO
{
    public class Game
    {
        private CardStock Deck = new CardStock(); // the deck is created and shuffled, as soon as a object of type CardStock is created, the object's constructor shuffles the deck
        // make a Players array for 2 players
        private Players[] players = new Players[2]; 
        private int v;

        // return the names of the players
        public string getNames()
        {
            return players[0].Name + " and " + players[1].Name;
        }

        // Constructor
        public Game(int v)
        {
            // inputline will be the name of the players
            string inputLine;
            this.v = v;
            // loop in order to set the players names
            for(int i = 0; i < players.Length; i++)
            {
                this.players[i] = new Players();
                Console.Write("Please enter your name \n");
                inputLine = Console.ReadLine();
                this.players[i].Name = inputLine;
            }
            Deck.distribute(players); // deals out the hands to the players
        }
        // return the names of the players and their cards, as a string
        public override string ToString()
        {
            string output = null;
            foreach(Players p in players)
            {
                output += p.ToString(); // concatenate each player to output
            }
            return base.ToString();
        }
        // start the game and the rules and conditions of the game
        /* the way that this program works is that each round, a player draws his card, then he pushes it into a stack (each player is given his own stack). 
         The cards are then peeked at in the stack, and a winner is decided.  IF there is war, then the war method is called, in which each player will push 2 cards into the stack,
         1 is his face down card and the other is the card that he will comapre with the other player.  IF there is another war, then war is called again.  This continues until
         a winner of the round is decided, then a new round is played. */
        public string start()
        {
            // this method will run until the game is over
            while (true)
            {
                // create an array of stacks called table, for each player, each time they draw cards, the cards will go into their respective stack
                Stack<Card>[] table = new Stack<Card>[players.Length];
                for (int i = 0; i < players.Length; i++)
                {
                    table[i] = new Stack<Card>();
                }

                // each player draws a card, pops it from their "hand" or player array, and push it into the approproiate stack
                for (int i = 0; i < players.Length; i++)
                {
                    table[i].Push(players[i].pop()); // pop the first card of each player into the table
                }
                // call a fucntion to compare the cards
                handleCompare(table, players);

                // if one of the players does not have any cards lefts, he loses
                if (players[0].loseout())
                {
                    return players[1].Name;
                }
                if (players[1].loseout())
                {
                    return players[0].Name;
                }
            }

        }

        // WAR method, carry out war, the way war works is that we pop an additional card from each palyers' hand, put it into the stack, then call handleCompare inorder to decide the winner
        // need to remember that if a player is out of cards, he cannot add another card to the stack, so he will just use his previous card to compare
        private void war(Stack<Card>[] table, Players[] players)
        {   

            // Add facedown cards to list
            for(int i = 0; i < players.Length; i++)
            {
                // Add two cards (if we can)
                for(int z = 0; z < 2; z++)
                {
                    // Check that there are cards to add, and if so, add the cards to the appropriate stack
                    if(players[i].count() > 0)
                    {
                        table[i].Push(players[i].pop());
                    }
                }
            }
            // call handleCompare to dedide the winnner of war
            handleCompare(table, players);
        }

        // handleCompare is a function to compare the cards drawn by the players
        public void handleCompare(Stack<Card>[] table, Players[] players)
        {
            // compare the 2 cards and save the result into temp
            // if temp is greater than 0 then player 1 won, if temp is less than 0 then player 2 won, if temp is 0 that means there is WAR!
            int temp = table[0].Peek().CompareTo(table[1].Peek()); // compare the 2 cards

            // outpute the current cards on the field
            Console.WriteLine("{0}: {1}, {2}: {3}", players[0].Name, table[0].Peek(), players[1].Name, table[1].Peek());
            
            // player 1 won this round and gets the cards
            if (temp > 0)
            {
                // Output result
                Console.WriteLine("{0} wins the battle! :D", players[0].Name);

                // Check if step by step
                if(v == 1)
                {
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadKey();
                }

                // Add the cards from the table to the player 1's hand  
                foreach (Stack<Card> c in table)
                {
                    while (c.Count > 0)
                    {
                        players[0].addCard(c.Pop());
                    }
                }
            }
            // player 2 won this round and gets the cards
            if (temp < 0)
            {
                // Output the result
                Console.WriteLine("{0} wins the battle! :D", players[1].Name);

                // Check if step by step
                if (v == 1)
                {
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadKey();
                }

                // Add cards from the table to player 2's hand
                foreach (Stack<Card> c in table)
                {
                    while (c.Count > 0)
                    {
                        players[1].addCard(c.Pop());
                    }
                }
            }
            // the 2 cards are the same so WAR 
            if (temp == 0)
            {
                Console.WriteLine("WAR!!!");

                // Check if step by step
                if (v == 1)
                {
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadKey();
                }
                // call War function to carry out the war
                war(table, players);
            }
        }
    }
}
