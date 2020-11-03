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
        public void AssertGutterGameScoreIsZero()
        {
            repeatBallThrows(20, 0);

            Assert.Equal(0, gameScoring.TotalScore());
        }

        [Fact]
        public void AssertAllOnesGameScoreIsTwenty()
        {
            repeatBallThrows(20, 1);

            Assert.Equal(20, gameScoring.TotalScore());
        }

        [Fact]
        public void AssertScoreIs16ForASpareFollowedBy3Ball()
        {
            throwSpare();
            gameScoring.throwBall(3);

            Assert.Equal(16, gameScoring.TotalScore());
        }

        [Fact]
        public void AssertScoreIs24ForAStrikeFollowedBy3And4Ball()
        {
            throwStrike();
            gameScoring.throwBall(3);
            gameScoring.throwBall(4);
            repeatBallThrows(16, 0);

            Assert.Equal(24, gameScoring.TotalScore());
        }

        [Fact]
        public void AssertPerfectGameScoreIs300()
        {
            repeatBallThrows(12, 10);

            Assert.Equal(300, gameScoring.TotalScore());
        }

        [Fact]
        public void AssertScoreIs30ForAStrikeFollowedBySpare()
        {

            throwSpare();
            throwStrike();

            Assert.Equal(30, gameScoring.TotalScore());
        }

        [Fact]
        public void AssertSpareWorksProperly()
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
