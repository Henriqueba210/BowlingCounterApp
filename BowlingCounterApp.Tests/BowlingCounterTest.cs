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

        // [Fact]
        // public void AssertPerfectGameScoreIs300()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     RepeatThrows(bowlingCounter, 10, 9);

        //     bowlingCounter.PlayFrame(10, 10, 10);

        //     Assert.Equal(300, bowlingCounter.TotalScore);
        // }




        // [Fact]
        // public void AssertScoreIs24ForAStrikeFollowedBy3And4Ball()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     PerformStrike(bowlingCounter);
        //     bowlingCounter.PlayFrame(3, 0);
        //     bowlingCounter.PlayFrame(4, 0);

        //     Assert.Equal(24, bowlingCounter.TotalScore);
        // }

        // [Fact]
        // public void AssertScoreIs30ForAStrikeFollowedBySpare()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     PerformStrike(bowlingCounter);
        //     PerformSpare(bowlingCounter);

        //     Assert.Equal(30, bowlingCounter.TotalScore);
        // }

        // [Fact]
        // public void AssertFunctionalityForSpareInLastFrameWorks()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     RepeatThrows(bowlingCounter, 5, 9);

        //     bowlingCounter.PlayFrame(5, 5, 5);

        //     Assert.Equal(15, bowlingCounter.frames[9].Points);
        // }

        // [Fact]
        // public void AssertFunctionalityForNotBeingAbleToPlayExtraFrameInLastFrameWorks()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     RepeatThrows(bowlingCounter, 5, 9);

        //     bowlingCounter.PlayFrame(5, 4, 1);

        //     Assert.Equal(9, bowlingCounter.frames[9].Points);
        // }

        // [Fact]
        // public void Test()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     bowlingCounter.PlayFrame(1, 9);

        //     bowlingCounter.PlayFrame(1, 3);


        //     Assert.Equal(15, bowlingCounter.TotalScore);
        // }

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
    }
}
