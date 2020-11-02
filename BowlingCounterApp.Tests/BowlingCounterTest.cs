using System;
using Xunit;
using BowlingCounterApp.Core;

namespace BowlingCounterApp.Tests
{
    public class BowlingCounterTest
    {

        [Fact]
        public void AssertGutterGameScoreIsZero()
        {
            var gameScoring = new BowlingCounter();

            for (int i = 0; i < 20; i++)
            {
                gameScoring.throwBall(0);
            }

            Assert.Equal(0, gameScoring.TotalScore());
        }

        // [Fact]
        // public void AssertOnePinDropGameIsTwenty()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     RepeatThrows(bowlingCounter, 1, 10);

        //     Assert.Equal(20, bowlingCounter.TotalScore);
        // }

        // [Fact]
        // public void AssertPerfectGameScoreIs300()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     RepeatThrows(bowlingCounter, 10, 9);

        //     bowlingCounter.PlayFrame(10, 10, 10);

        //     Assert.Equal(300, bowlingCounter.TotalScore);
        // }

        // [Fact]
        // public void AssertScoreIs16ForASpareFollowedBy3Ball()
        // {
        //     var bowlingCounter = new BowlingCounter();

        //     bowlingCounter.PlayFrame(4, 6);
        //     bowlingCounter.PlayFrame(0, 3);

        //     Assert.Equal(13, bowlingCounter.TotalScore);
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
    }
}
