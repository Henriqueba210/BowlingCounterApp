using System;
using BowlingCounterApp.Core;
using Xunit;

namespace BowlingCounterApp.Tests
{
    public class BowlingFrameTest
    {
        [Fact]
        public void AssertCantExceedNumberOfPlays()
        {
            BowlingFrame bowlingFrame = new BowlingFrame(false);

            bowlingFrame.setPinsDropped(4);
            bowlingFrame.setPinsDropped(5);

            Assert.Throws<InvalidOperationException>(() => bowlingFrame.setPinsDropped(1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-19)]
        [InlineData(11)]
        public void AssertInvalidNumberOfPinsDropped(int value)
        {
            BowlingFrame bowlingFrame = new BowlingFrame(false);

            Assert.Throws<ArgumentException>(() => bowlingFrame.setPinsDropped(value));
        }

        [Fact]
        public void AssertStateHasBeenReset()
        {
            BowlingFrame bowlingFrame = new BowlingFrame(false);

            bowlingFrame.setPinsDropped(5);
            bowlingFrame.setPinsDropped(5);

            bowlingFrame.resetState();

            Assert.Equal(0, bowlingFrame.Frame1);
            Assert.Equal(0, bowlingFrame.Frame2);
            Assert.Equal(0, bowlingFrame.Bonus);
            Assert.Equal(0, bowlingFrame.Points);
        }
    }
}
