using System;
using Xunit;
using BowlingCounterApp.Core;

namespace BowlingCounterApp.Tests
{
    public class BowlingCounterTest
    {
        BowlingCounter gameScoring;

        public BowlingCounterTest()
        {
            gameScoring = new BowlingCounter();
        }


        [Fact]
        public void GutterGameScoreIsZero()
        {
            repeatBallThrows(20, 0);

            Assert.Equal(0, gameScoring.TotalScore());
        }

        [Fact]
        public void AllOnesGameScoreIsTwenty()
        {
            repeatBallThrows(20, 1);

            Assert.Equal(20, gameScoring.TotalScore());
        }

        [Fact]
        public void ScoreIs16ForASpareFollowedBy3Ball()
        {
            throwSpare();
            gameScoring.throwBall(3);

            Assert.Equal(16, gameScoring.TotalScore());
        }

        [Fact]
        public void ScoreIs24ForAStrikeFollowedBy3And4Ball()
        {
            throwStrike();
            gameScoring.throwBall(3);
            gameScoring.throwBall(4);
            repeatBallThrows(16, 0);

            Assert.Equal(24, gameScoring.TotalScore());
        }

        [Fact]
        public void PerfectGameScoreIs300()
        {
            repeatBallThrows(12, 10);

            Assert.Equal(300, gameScoring.TotalScore());
        }

        [Fact]
        public void ScoreIs30ForAStrikeFollowedBySpare()
        {

            throwSpare();
            throwStrike();

            Assert.Equal(30, gameScoring.TotalScore());
        }

        [Fact]
        public void SpareWorksProperly()
        {
            gameScoring.throwBall(1);
            gameScoring.throwBall(9);
            gameScoring.throwBall(1);
            gameScoring.throwBall(3);

            Assert.Equal(15, gameScoring.TotalScore());
        }

        private void repeatBallThrows(int numberOfThrows, int numberOfPinsDropped)
        {
            for (int i = 0; i < numberOfThrows; i++)
            {
                gameScoring.throwBall(numberOfPinsDropped);
            }
        }

        private void throwSpare()
        {
            gameScoring.throwBall(5);
            gameScoring.throwBall(5);
        }

        private void throwStrike()
        {
            gameScoring.throwBall(10);
        }
    }
}
