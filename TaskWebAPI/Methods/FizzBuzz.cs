using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskWebAPI.Methods
{
    public class FizzBuzz : IFizzBuzz
    {
        public string Get(int number)
        {
            string result = "";
            if (number <= 0)
            {
                result += "Enter a number greater than zero!";
            }
            else if (number % 2 == 0 & number % 3 == 0)
            {
                result += "FizzBuzz";
            }
            else if (number % 2 == 0)
            {
                result += "Fizz";
            }
            else if (number % 3 == 0)
            {
                result += "Buzz";
            }
            else result = number.ToString();

            return result;
        }
    }
}
