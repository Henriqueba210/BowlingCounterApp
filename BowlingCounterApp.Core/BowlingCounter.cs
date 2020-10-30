using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BowlingCounterApp.Core
{
    public class BowlingCounter
    {
        public int CurrentFrame { get; private set; } = 0;

        public int TotalScore { get; private set; }

        public void PlayFrame(int firstPlay, int secondPlay = 0, int thirdPlay = 0)
        {
            var bowlingFrame = frames[CurrentFrame];

            var bonusScored = bowlingFrame.SetPinsDropped(firstPlay);
            if (bonusScored == BonusType.Strike && !bowlingFrame.LastFrame)
            {
                IndexStrikeFramesToBeScored.Add(CurrentFrame);
            }
            else if (bowlingFrame.LastFrame)
            {
                bonusScored = bowlingFrame.SetPinsDropped(secondPlay);
                if (bonusScored == BonusType.Spare || bonusScored == BonusType.Strike)
                {
                    bowlingFrame.SetPinsDropped(thirdPlay);
                }
            }
            else
            {
                bonusScored = bowlingFrame.SetPinsDropped(secondPlay);
                if (bonusScored == BonusType.Spare)
                    IndexSpareFramesToBeScored.Add(CurrentFrame);
            }

            bowlingFrame.CalculateScore();

            CalculateStrikeScoreBonus();
            CalculateSpareScoreBonus();

            CalculateTotalScore();

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
            if (IndexStrikeFramesToBeScored.Count > 0 && !frames[CurrentFrame].LastFrame)
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
            else
            {
                var frame8 = frames[7];
                var frame9 = frames[8];
                var frame10 = frames[9];

                if (frame8.BonusType == BonusType.Strike)
                {
                    frame8.Bonus = frame9.Points + frame10.Frame1;
                    frame8.CalculateScore();
                }
                if (frame9.BonusType == BonusType.Strike)
                {
                    frame9.Bonus = frame10.Frame1 + frame10.Frame2;
                    frame9.CalculateScore();
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
            bonusFrame.CalculateScore();
        }

        public void CalculateTotalScore()
        {
            this.TotalScore = 0;
            this.frames.ForEach((bowlingFrame) => this.TotalScore += bowlingFrame.Points);
        }

        public List<int> IndexStrikeFramesToBeScored = new List<int>();

        public List<int> IndexSpareFramesToBeScored = new List<int>();

        public void ResetGameState()
        {
            this.CurrentFrame = 0;
            this.TotalScore = 0;
            this.frames.ForEach((bowlingFrame) => bowlingFrame.ResetState());
            this.IndexSpareFramesToBeScored.Clear();
            this.IndexStrikeFramesToBeScored.Clear();
        }
    };
}