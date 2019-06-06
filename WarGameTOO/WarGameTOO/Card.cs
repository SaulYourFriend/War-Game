using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameTOO
{
    // put in icomparable to compare this object to other objects, we will want to do this in our game
    public class Card : IComparable<Card>
    {
        // getters and setters
        public Color Color // enum of type color, name color
        {
            get;
            set; 
        }
        private int num;
        // create a setter for Number
        private int Number
        {
            set
            {
                if (value < 2 || value > 14) // value is a key word
                {
                    throw new Exception("invalid number: PLease enter a number between 2 and 14");
                }
                num = value;
            }
        }
        // convert our number to the appropirate face card
        public string CardName
        {
            get
            {
                switch (num)
                {
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    case 14:
                        return "Ace";

                    default:
                        return num.ToString(); // convert number to string
                }

            }
        }

        // constructors
        public Card() { }
        public Card(int num, string color)
        {
            // need to do try, because being passed color, so we check to make sure we have the correct color.
            try
            {
                Number = num;
                Color = (Color)Enum.Parse(typeof(Color), color.ToUpper()); // convert our string to upper case, and we parse the string inorder to convert it to our enum.
            }
            catch(Exception mistake)
            {
                if (mistake is ArgumentException) // if one of the arguement given was not correct (the color) we will throw this type of exception
                {
                    Console.WriteLine("The color {0) is not a valid color", color);
                }
                else throw mistake;
            }
        }
        // override to string section, need to voerride becuase every single object in C# inherits from Object
        public override string ToString()
        {
            return string.Format("The card is a {0}, {1}", Color, CardName);
        }
        // instead of having to write the compare function we just choose to compare their number values
        public int CompareTo(Card temp) // call it compareto, not overriding
        {
            return num.CompareTo(temp.num);
        }
        
    }
}
