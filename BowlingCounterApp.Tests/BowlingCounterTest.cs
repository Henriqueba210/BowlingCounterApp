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

            Assert.Equal(30, bowlingCounter.frames[0].Points);
            Assert.Equal(20, bowlingCounter.frames[1].Points);
            Assert.Equal(10, bowlingCounter.frames[2].Points);
        }
    }
}
