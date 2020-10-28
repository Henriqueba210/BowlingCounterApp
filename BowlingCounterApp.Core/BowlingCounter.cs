using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BowlingCounterApp.Core
{
    public class BowlingCounter
    {
        public int CurrentFrame { get; private set; } = 0;

        public void PlayFrame(Func<int, int> askForNumberOfPinsDropped)
        {
            var bowlingFrame = frames[CurrentFrame];

            var bonusScored = bowlingFrame.setPinsDropped(askForNumberOfPinsDropped(1));
            if (bonusScored == BonusType.Strike)
            {
                IndexStrikeFramesToBeScored.Add(CurrentFrame);
            }
            else
            {
                bonusScored = bowlingFrame.setPinsDropped(askForNumberOfPinsDropped(2));
                if (bonusScored == BonusType.Spare)
                    IndexSpareFramesToBeScored.Add(CurrentFrame);
            }

            bowlingFrame.calculateScore();

            CalculateStrikeScoreBonus();
            CalculateSpareScoreBonus();

            CurrentFrame++;
        }

        public ImmutableList<BowlingFrame> frames = ImmutableList.Create<BowlingFrame>(
                new BowlingFrame(false),
                new BowlingFrame(false),
                new BowlingFrame(false),
                new BowlingFrame(false),
                new BowlingFrame(false),
                new BowlingFrame(false),
                new BowlingFrame(false),
                new BowlingFrame(false),
                new BowlingFrame(false),
                new BowlingFrame(true)
            );

        public void CalculateStrikeScoreBonus()
        {
            if (IndexStrikeFramesToBeScored.Count > 0)
            {
                foreach (var StrikeFrame in IndexStrikeFramesToBeScored.ToArray())
                {
                    if (CurrentFrame >= StrikeFrame + 1)
                    {
                        CalculateBonus(frames[StrikeFrame], frames[CurrentFrame]);
                        if (CurrentFrame == StrikeFrame + 2)
                            IndexStrikeFramesToBeScored.Remove(StrikeFrame);
                    }
                }
            }
        }

        public void CalculateSpareScoreBonus()
        {
            if (IndexSpareFramesToBeScored.Count > 0)
            {
                foreach (var SpareFrame in IndexSpareFramesToBeScored.ToArray())
                {
                    if (CurrentFrame == SpareFrame + 1)
                    {
                        CalculateBonus(frames[SpareFrame], frames[CurrentFrame]);
                        IndexSpareFramesToBeScored.Remove(SpareFrame);
                    }
                }
            }
        }

        public void CalculateBonus(BowlingFrame bonusFrame, BowlingFrame nextFrame)
        {
            bonusFrame.Bonus += nextFrame.Points;
            bonusFrame.calculateScore();
        }
        public List<int> IndexStrikeFramesToBeScored = new List<int>();

        public List<int> IndexSpareFramesToBeScored = new List<int>();

        public void ResetGameState()
        {
            this.CurrentFrame = 0;
            this.frames.ForEach((bowlingFrame) => bowlingFrame.resetState());
            this.IndexSpareFramesToBeScored.Clear();
            this.IndexStrikeFramesToBeScored.Clear();
        }
    };
}