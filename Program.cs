using System;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //iterator pattern
            NumericCollection nums = new ("Sl4ve M2sTe4");
            foreach (var item in nums)
                System.Console.WriteLine(item);


        }
    }
}
