using System;
using BowlingCounter.Core;
using Xunit;

namespace BowlingCounter.Tests
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
    }
}
