using System;
namespace Practica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.Likes(new string[0]));
            Console.WriteLine(Kata.Likes(new string[] { "Peter" })); 
            Console.WriteLine(Kata.Likes(new string[] { "Alex", "Jacob", "Mark", "Max" })); 
        }
    }
}
