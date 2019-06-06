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
            shuffle();
        }

        // shuffling cards
        public void shuffle()
        {
            int amount = Cards.Count;
            
            while(amount > 1)
            {
                amount--;
                int rand_num = rand.Next(amount + 1); // generate random card inisde the amount of cards left
                Card temp = Cards[rand_num];
                Cards[rand_num] = Cards[amount];
                Cards[amount] = temp;
            }
        }
       
        // distribute method deals out the cards, making sure eahc player gets the same amount, until the remainder. 
        public void distribute(params Players[] players)
        {
            int numPlayers = players.Length;
            int numCardsPlayer = Cards.Count / numPlayers;  // number of cards each player is supposed to get
            int remainder = Cards.Count % numPlayers; // how many cards are left over
     
            foreach(Players p in players)
            {
                for(int i = 0; i < numCardsPlayer; i++)
                {
                    p.addCard(Cards.ElementAt(0));
                    Cards.RemoveAt(0);
                }
                // if thehre is a remainder, give out the remaining cards
                if (remainder > 0)
                {
                    p.addCard(Cards.ElementAt(0));
                    Cards.RemoveAt(0);
                    remainder--;
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

        // Enumerators
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
