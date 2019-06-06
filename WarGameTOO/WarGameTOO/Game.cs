using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameTOO
{
    public class Game
    {
        private CardStock Deck = new CardStock(); // the deck is created and shuffled
        private Players[] players = new Players[2];
        private int v;

        public string getNames()
        {
            return players[0].Name + " and " + players[1].Name;
        }

        // Constructor
        public Game(int v)
        {
            string inputLine;
            this.v = v;
            for(int i = 0; i < players.Length; i++)
            {
                this.players[i] = new Players();
                Console.Write("Please enter your name \n");
                inputLine = Console.ReadLine();
                this.players[i].Name = inputLine;
            }
            Deck.distribute(players); // deals out the hands to the players
        }
        // return the names of the players and their cards
        public override string ToString()
        {
            string output = null;
            foreach(Players p in players)
            {
                output += p.ToString(); // concatenate each player to output
            }
            return base.ToString();
        }
        // start the game and the rules
        public string start()
        {
            while (true)
            {
                Stack<Card>[] table = new Stack<Card>[players.Length];
                for (int i = 0; i < players.Length; i++)
                {
                    table[i] = new Stack<Card>();
                }

                for (int i = 0; i < players.Length; i++)
                {
                    table[i].Push(players[i].pop()); // pop the first card of each player into the table
                }

                handleCompare(table, players);
                // if one of the players does not haveany cards lefts
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
        private void war(Stack<Card>[] table, Players[] players)
        {
            // Hold cards for the players
            

            // Add facedown cards to list
            for(int i = 0; i < players.Length; i++)
            {
                // Add two cards (if we can)
                for(int z = 0; z < 2; z++)
                {
                    // Check that there are cards to add
                    if(players[i].count() > 0)
                    {
                        table[i].Push(players[i].pop());
                    }
                }
            }

            handleCompare(table, players);
        }

        public void handleCompare(Stack<Card>[] table, Players[] players)
        {
            int temp = table[0].Peek().CompareTo(table[1].Peek()); // compare the 2 cards

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

                // Add the cards from the table to p0
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

                // Add cards from the table to p1
                foreach (Stack<Card> c in table)
                {
                    while (c.Count > 0)
                    {
                        players[1].addCard(c.Pop());
                    }
                }
            }
            if (temp == 0)
            {
                Console.WriteLine("WAR!!!");

                // Check if step by step
                if (v == 1)
                {
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadKey();
                }

                war(table, players);
            }
        }
    }
}
