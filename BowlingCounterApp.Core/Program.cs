using System;

namespace BowlingCounterApp.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var bowlingCounter = new BowlingCounter();

            for (int i = 0; i < 8; i++)
            {
                bowlingCounter.PlayFrame((int frameNumber) =>
                {
                    Console.Write($"Insert the number of pins dropped in frame {frameNumber}: ");
                    return Convert.ToInt32(Console.ReadLine());
                });
            }
        }
    }
}
