﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGameTOO
{
    class Program
    {
        static void Main(string[] args)
        {
            // variable value, pass into the game
            int value;
            // intialize game to null
            Game game = null;
           
            Console.WriteLine("Welcome to War: Press 1 for a play-by-play or Press 0 for the result.");
            // try to run the game, passing in the value 1 or 0
            try
            {
                // parse to convert input to an integer
                value = Int32.Parse(Console.ReadLine());
                // Start the game
                game = new Game(value);


            }
            // if theres a problem catch it
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
            
            /* instead of making a switch, we formatted the the game according to wheather or not the user entered a 0 or 1.*/
            // names of the players
            Console.WriteLine("The players are "+ game.getNames());
            string winner = game.start();
            // announce the winner
            Console.Write("The winner is ", winner);

            Console.WriteLine("Please enter any key to continue...");
            Console.ReadKey();
        }
    }
}
