using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameTOO
{
    public class CardStock: IEnumerable
    {
        // create a random number generator
        private static Random rand = new Random();
        // list of cards
        List<Card> Cards;

        // constructor
        public CardStock()
        {
            Cards = new List<Card>(); // create the list object for Card
            // loop to create 13 cards of each color, so 26 total
            for(int i = 2; i <= 14; i++)
            {
                Cards.Add(new Card(i, "BLACK"));
                Cards.Add(new Card(i, "RED"));

            }
            // call the shuffle function
            shuffle();
        }

        // shuffling cards
        public void shuffle()
        {
            // set teh amount of cards to shuffle
            int amount = Cards.Count;
            
            // while the number of cards is greater than 1, carry out a copy function inorder to decide its place
            while(amount > 1)
            {
                amount--;
                int rand_num = rand.Next(amount + 1); // generate random card inisde the amount of cards left
                Card temp = Cards[rand_num];
                Cards[rand_num] = Cards[amount];
                Cards[amount] = temp;
            }
        }
       
        // distribute method deals out the cards, making sure each player gets the same amount, until the remainder. 
        public void distribute(params Players[] players)
        {
            // find out the number of players
            int numPlayers = players.Length;
            int numCardsPlayer = Cards.Count / numPlayers;  // number of cards each player is supposed to get
            int remainder = Cards.Count % numPlayers; // how many cards are left over 
     
            // for each player, deal out an equal number of cards
            foreach(Players p in players)
            {
                for(int i = 0; i < numCardsPlayer; i++)
                {
                    p.addCard(Cards.ElementAt(0)); // add to each players' hand the card at the top of the deck
                    Cards.RemoveAt(0); // remove the top card from the deck
                }
                // if there is a remainder, give out the remaining cards
                if (remainder > 0)
                {
                    p.addCard(Cards.ElementAt(0)); // add to each players' hand the top card of the remainder pile
                    Cards.RemoveAt(0); // remove the card from the remainder pile
                    remainder--; // decrament the amount of remaining cards left
                }

            }
        }

        // find card intex for an integer
        public Card this[int i]
        {
            get
            {
                if (i < 0 || i > 25) // if i is greater than the number of positions or less than 0, return null
                {
                    return null;
                }
                return Cards[i];  // return the position of the card
            }
        }

        // find card index for a string
        public Card this[string positionName]
        {
            get
            {
                Card card = null;
                // iterate through the list Cards, if a name of the card is equal to the position, set card to that card/position
                foreach(Card c in Cards)
                {
                    if(c.CardName == positionName)
                    {
                        card = c;
                        break;
                    }
                    
                }
                return card;
            }
        }
        // override to string 
        public override string ToString()
        {
            return base.ToString();
        }

        // add card method 
        public void addCardStock(Card card)
        {
            Cards.Add(card);
        }
        // remove a card from the deck
        public void removeCardStock()
        {
            Cards.RemoveAt(0);
        }

        // Enumerators, allowing us to carry out foreach
        public IEnumerator<Card> GetEnumerator()
        {
            return Cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



    }
}
