using System;
using System.Diagnostics.CodeAnalysis;

namespace BowlingCounterApp.Core
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var bowlingCounter = new BowlingCounter();

            for (int i = 0; i < 8; i++)
            {
                int firstPlay = askForPinsDropped();
                int secondPlay = 0;

                if (firstPlay < 10)
                    secondPlay = askForPinsDropped(2);

                bowlingCounter.throwBall(firstPlay);
                bowlingCounter.throwBall(secondPlay);
            }
        }

        private static int askForPinsDropped(int frameNumber = 1)
        {
            Console.Write($"Insert the number of pins dropped in attempt {frameNumber}: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
