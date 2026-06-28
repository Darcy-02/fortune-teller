using System;
using FortuneCookies;

namespace FortuneCookies.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookie = new FortuneCookie();

            Console.Write("Enter your lucky number: ");
            string input = Console.ReadLine();

            int number;
            if (!int.TryParse(input, out number) || number <= 0)
            {
                Console.WriteLine("Please enter a positive whole number.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine(cookie.CrackOpen(number));
        }
    }
}