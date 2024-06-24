using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class FizzBuzz
    {
        public FizzBuzz()
        {
        }

        public void run()
        {
            //Fizz Buzz Game Code
            Console.WriteLine(" ----------- Fizz Buzz Game ---------------------------------");
            for (int i = 1; i <= 15; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else Console.WriteLine(i);
            }
        }
    }
}
