using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BowlingCounterApp.Core
{
    public class BowlingCounter
    {
        private int[] rollsPerformed { get; set; }
        private int currentRoll = 0;

        public BowlingCounter()
        {
            rollsPerformed = new int[21];
        }
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
                if (isStrike(rollIndex))
                {
                    score += 10 + calculateStrikeBonus(rollIndex);
                    rollIndex--;
                }
                else if (isSpare(rollIndex))
                {
                    score += 10 + calculateSpareBonus(rollIndex);
                }
                else
                    score += sumOfPinsDroppedInFrame(rollIndex);

                rollIndex += 2;
            }

            return score;
        }

        private bool isStrike(int rollIndex)
        {
            return rollsPerformed[rollIndex] == 10;
        }

        private int sumOfPinsDroppedInFrame(int rollIndex)
        {
            return rollsPerformed[rollIndex] + rollsPerformed[rollIndex + 1];
        }

        private int calculateSpareBonus(int rollIndex)
        {
            return rollsPerformed[rollIndex + 2];
        }

        private int calculateStrikeBonus(int rollIndex)
        {
            return rollsPerformed[rollIndex + 1] + rollsPerformed[rollIndex + 2];
        }

        private bool isSpare(int rollIndex)
        {
            return rollsPerformed[rollIndex] + rollsPerformed[rollIndex + 1] == 10;
        }
    };
}