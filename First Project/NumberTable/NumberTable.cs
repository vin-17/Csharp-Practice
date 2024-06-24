using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project
{
    internal class NumberTable
    {
        public NumberTable()
        {

        }

        public void run()
        {
            //Exercise : Tables code
            Console.WriteLine(" ----------- Number Table ---------------------------------");
            Console.Write(" enter the number : ");
            string input = Console.ReadLine();

            Boolean success = false;
            while (!success)
            {
                if (int.TryParse(input, out int num))
                {
                    success = true;
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.WriteLine(num * i);
                    }
                }
                else
                {
                    Console.WriteLine("please provide and integer !! ");
                    Console.Write(" enter the number : ");
                    input = Console.ReadLine();
                }
            }
        }
    }
}
