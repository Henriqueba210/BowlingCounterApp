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

            var ballIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                score += this.rollsPerformed[ballIndex] + this.rollsPerformed[ballIndex + 1];
                ballIndex += 2;
            }

            return score;
        }
    };
}