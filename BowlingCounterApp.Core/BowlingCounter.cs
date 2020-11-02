using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BowlingCounterApp.Core
{
    public class BowlingCounter
    {
        private int _score = 0;
        public void throwBall(int pinsDropped)
        {
            _score += pinsDropped;
        }

        public int TotalScore()
        {
            return _score;
        }
    };
}