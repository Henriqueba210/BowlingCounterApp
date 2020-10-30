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

            bowlingFrame.SetPinsDropped(4);
            bowlingFrame.SetPinsDropped(5);

            Assert.Throws<InvalidOperationException>(() => bowlingFrame.SetPinsDropped(1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-19)]
        [InlineData(11)]
        public void AssertInvalidNumberOfPinsDropped(int value)
        {
            BowlingFrame bowlingFrame = new BowlingFrame(false);

            Assert.Throws<ArgumentException>(() => bowlingFrame.SetPinsDropped(value));
        }

        [Fact]
        public void AssertStateHasBeenReset()
        {
            BowlingFrame bowlingFrame = new BowlingFrame(false);

            bowlingFrame.SetPinsDropped(5);
            bowlingFrame.SetPinsDropped(5);

            bowlingFrame.ResetState();

            Assert.Equal(0, bowlingFrame.Frame1);
            Assert.Equal(0, bowlingFrame.Frame2);
            Assert.Equal(0, bowlingFrame.Frame3);
            Assert.Equal(0, bowlingFrame.Bonus);
            Assert.Equal(0, bowlingFrame.Points);
            Assert.Equal(BonusType.None, bowlingFrame.BonusType);
        }
    }
}
