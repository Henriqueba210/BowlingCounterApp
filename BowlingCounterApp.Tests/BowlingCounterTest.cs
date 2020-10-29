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

            bowlingCounter.PlayFrame((int i) => 10);
            bowlingCounter.PlayFrame((int i) => 10);
            bowlingCounter.PlayFrame((int i) => 10);
            bowlingCounter.PlayFrame((int i) => 5);
            bowlingCounter.PlayFrame((int i) => 5);
            bowlingCounter.PlayFrame((int i) => 4);
            bowlingCounter.PlayFrame((int i) => 3);
            bowlingCounter.PlayFrame((int i) => 2);
            bowlingCounter.PlayFrame((int i) => 1);
            bowlingCounter.PlayFrame((int i) => 0);

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
        }

        [Fact]
        public void AssertStateHasBeenReset()
        {
            var bowlingCounter = new BowlingCounter();

            bowlingCounter.PlayFrame((int i) => 10);
            bowlingCounter.PlayFrame((int i) => 5);


            bowlingCounter.ResetGameState();

            Assert.Equal(0, bowlingCounter.CurrentFrame);
            Assert.Empty(bowlingCounter.IndexSpareFramesToBeScored);
            Assert.Empty(bowlingCounter.IndexStrikeFramesToBeScored);
            Assert.Equal(0, bowlingCounter.CurrentFrame);

            bowlingCounter.frames.ForEach(bowlingFrame =>
            {
                Assert.Equal(0, bowlingFrame.Frame1);
                Assert.Equal(0, bowlingFrame.Frame2);
                Assert.Equal(0, bowlingFrame.Bonus);
                Assert.Equal(0, bowlingFrame.Points);
            });
        }
    }
}
