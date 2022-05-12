using System;

namespace Summator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Summator summator = new Summator();
            int result = summator.Sum(new int[] { 10, 20, 30 });
            if (result == 20)
            {
                Console.WriteLine("Test Pass");
            } 
            else
            {
                Console.WriteLine("Test Fail");
            }
        }
    }
}
