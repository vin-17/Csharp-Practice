using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace First_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NumberTable numberTableObject = new NumberTable();

            //numberTableObject.run();

            //FizzBuzz fizzBuzz = new FizzBuzz();

            //fizzBuzz.run();

            TicTacToe gameObject = new TicTacToe();
            gameObject.start();

            Console.ReadLine();
        }
    }
}
