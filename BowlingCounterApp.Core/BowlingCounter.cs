using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BowlingCounterApp.Core
{
    public class BowlingCounter
    {

        private int[] rollsPerformed { get; set; } = new int[21];
        private int currentRoll = 0;
        public void throwBall(int pinsDropped)
        {
            rollsPerformed[currentRoll++] = pinsDropped;
        }

        public int TotalScore()
        {
            var score = 0;

            var rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (isSpare(rollIndex))
                    score += 10 + rollsPerformed[rollIndex + 2];
                else
                    score += rollsPerformed[rollIndex] + rollsPerformed[rollIndex + 1];

                rollIndex += 2;
            }

            return score;
        }

        private bool isSpare(int rollIndex)
        {
            return rollsPerformed[rollIndex] + rollsPerformed[rollIndex + 1] == 10;
        }
    };
}