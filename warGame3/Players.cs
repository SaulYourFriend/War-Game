using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameTOO
{
    public class Players
    {
        // creating a queue for the cards
        Queue<Card> hand = new Queue<Card>();
        // getter and setter
        public String Name
        {
            get;
            set;
        }
        // add Card to your hand
        public void addCard(params Card[] card)
        {
            // a card is added to each player's hand
            foreach(Card c in card)
            {
                hand.Enqueue(c);
            }
                
        }
        // override to string
        public override string ToString()
        {
            string current_hand = string.Format("The Player's name is {0}, he has {1} cards, and they are: \n", Name, hand.Count);
            // scroll through each card in the hand and add it to our string
            foreach(Card c in hand)
            {
                current_hand += c;
            }
    
            return current_hand;
        }
        // boolean loser method, if the amount of cards in a player's hand is 0, they lose
        public bool loseout()
        {
            return hand.Count == 0; // if hand is empty, return true, it means player lost.  
        }

        // pop method, of type Card becuase need to pop and return the card
        public Card pop()
        {
            // dequeue a card from the hand and return the result.
            Card result = hand.Dequeue();
            return result;
        }

        // count the amount of cards in a player's hand
        public int count()
        {
            return hand.Count;
        }
    }
}
