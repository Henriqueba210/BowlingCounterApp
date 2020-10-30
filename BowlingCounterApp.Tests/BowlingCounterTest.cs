using System;
using Xunit;
using BowlingCounterApp.Core;

namespace BowlingCounterApp.Tests
{
    public class BowlingCounterTest
    {

        [Fact]
        public void TestScorringWorksProperly()
        {
            var bowlingCounter = new BowlingCounter();

            PerformStrike(bowlingCounter);
            PerformStrike(bowlingCounter);
            PerformStrike(bowlingCounter);
            PerformSpare(bowlingCounter);
            PerformSpare(bowlingCounter);
            bowlingCounter.PlayFrame(4, 4);
            bowlingCounter.PlayFrame(3, 3);
            bowlingCounter.PlayFrame(2, 2);
            bowlingCounter.PlayFrame(1, 1);
            bowlingCounter.PlayFrame(0, 0);

            Assert.Equal(30, bowlingCounter.frames[0].Points);
            Assert.Equal(30, bowlingCounter.frames[1].Points);
            Assert.Equal(30, bowlingCounter.frames[2].Points);
            Assert.Equal(20, bowlingCounter.frames[3].Points);
            Assert.Equal(18, bowlingCounter.frames[4].Points);
            Assert.Equal(8, bowlingCounter.frames[5].Points);
            Assert.Equal(6, bowlingCounter.frames[6].Points);
            Assert.Equal(4, bowlingCounter.frames[7].Points);
            Assert.Equal(2, bowlingCounter.frames[8].Points);
            Assert.Equal(0, bowlingCounter.frames[9].Points);

            Assert.Equal(148, bowlingCounter.TotalScore);
        }

        [Fact]
        public void AssertStateHasBeenReset()
        {
            var bowlingCounter = new BowlingCounter();

            PerformStrike(bowlingCounter);
            PerformSpare(bowlingCounter);


            bowlingCounter.ResetGameState();

            Assert.Equal(0, bowlingCounter.CurrentFrame);
            Assert.Equal(0, bowlingCounter.TotalScore);
            Assert.Empty(bowlingCounter.IndexSpareFramesToBeScored);
            Assert.Empty(bowlingCounter.IndexStrikeFramesToBeScored);

            bowlingCounter.frames.ForEach(bowlingFrame =>
            {
                Assert.Equal(0, bowlingFrame.Frame1);
                Assert.Equal(0, bowlingFrame.Frame2);
                Assert.Equal(0, bowlingFrame.Frame3);
                Assert.Equal(0, bowlingFrame.Bonus);
                Assert.Equal(0, bowlingFrame.Points);
                Assert.Equal(BonusType.None, bowlingFrame.BonusType);
            });
        }

        [Fact]
        public void AssertGutterGameScoreIsZero()
        {
            var bowlingCounter = new BowlingCounter();

            RepeatThrows(bowlingCounter, 0, 10);

            Assert.Equal(0, bowlingCounter.TotalScore);
        }

        [Fact]
        public void AssertOnePinDropGameIsTwenty()
        {
            var bowlingCounter = new BowlingCounter();

            RepeatThrows(bowlingCounter, 1, 10);

            Assert.Equal(20, bowlingCounter.TotalScore);
        }

        [Fact]
        public void AssertPerfectGameScoreIs300()
        {
            var bowlingCounter = new BowlingCounter();

            RepeatThrows(bowlingCounter, 10, 9);

            bowlingCounter.PlayFrame(10, 10, 10);

            Assert.Equal(300, bowlingCounter.TotalScore);
        }

        [Fact]
        public void AssertScoreIs16ForASpareFollowedBy3Ball()
        {
            var bowlingCounter = new BowlingCounter();

            bowlingCounter.PlayFrame(4, 6);
            bowlingCounter.PlayFrame(0, 3);

            Assert.Equal(13, bowlingCounter.TotalScore);
        }


        [Fact]
        public void AssertScoreIs24ForAStrikeFollowedBy3And4Ball()
        {
            var bowlingCounter = new BowlingCounter();

            PerformStrike(bowlingCounter);
            bowlingCounter.PlayFrame(3, 0);
            bowlingCounter.PlayFrame(4, 0);

            Assert.Equal(24, bowlingCounter.TotalScore);
        }

        [Fact]
        public void AssertScoreIs30ForAStrikeFollowedBySpare()
        {
            var bowlingCounter = new BowlingCounter();

            PerformStrike(bowlingCounter);
            PerformSpare(bowlingCounter);

            Assert.Equal(30, bowlingCounter.TotalScore);
        }

        [Fact]
        public void AssertFunctionalityForSpareInLastFrameWorks()
        {
            var bowlingCounter = new BowlingCounter();

            RepeatThrows(bowlingCounter, 5, 9);

            bowlingCounter.PlayFrame(5, 5, 5);

            Assert.Equal(15, bowlingCounter.frames[9].Points);
        }

        [Fact]
        public void AssertFunctionalityForNotBeingAbleToPlayExtraFrameInLastFrameWorks()
        {
            var bowlingCounter = new BowlingCounter();

            RepeatThrows(bowlingCounter, 5, 9);

            bowlingCounter.PlayFrame(5, 4, 1);

            Assert.Equal(9, bowlingCounter.frames[9].Points);
        }

        [Fact]
        public void Test()
        {
            var bowlingCounter = new BowlingCounter();

            bowlingCounter.PlayFrame(1, 9);

            bowlingCounter.PlayFrame(1, 3);


            Assert.Equal(15, bowlingCounter.TotalScore);
        }

        private void PerformStrike(BowlingCounter bowlingCounter)
        {
            bowlingCounter.PlayFrame(10);
        }

        private void PerformSpare(BowlingCounter bowlingCounter)
        {
            bowlingCounter.PlayFrame(8, 2);
        }

        private void RepeatThrows(BowlingCounter bowlingCounter, int pinsDropped, int numberOfThrows)
        {
            for (int playCounter = 0; playCounter < numberOfThrows; playCounter++)
            {
                bowlingCounter.PlayFrame(pinsDropped, pinsDropped);
            }
        }
    }
}
