using System;

namespace BowlingCounterApp.Core
{
    public class BowlingFrame
    {
        public int Frame1 { get; private set; }

        public int Frame2 { get; private set; }

        public int Points { get; private set; }

        private bool playedOnce = false;

        private bool cantPlayAnymore = false;

        public BonusType bonusType { get; private set; }

        public int Bonus { get; set; }

        public BowlingFrame(bool ApplyBonusScoring)
        {
            this.Frame1 = 0;
            this.Frame2 = 0;
        }

        public BonusType setPinsDropped(int numberOfPinsDropped)
        {
            if (numberOfPinsDropped > 10 || numberOfPinsDropped < 0)
            {
                throw new ArgumentException("Number of pins dropped must be between 0 and 10");
            }

            if (!playedOnce)
            {
                if (numberOfPinsDropped == 10)
                {
                    bonusType = BonusType.Strike;
                    cantPlayAnymore = true;
                }
                else
                {
                    playedOnce = true;
                }
                Frame1 = numberOfPinsDropped;
            }
            else
            {
                if (cantPlayAnymore)
                {
                    // TODO: Create new exception for running out of plays.
                    throw new InvalidOperationException("You have already ended all plays of this frame.");
                }
                else
                {
                    if (Frame1 + numberOfPinsDropped == 10)
                    {
                        bonusType = BonusType.Spare;
                    }
                    Frame2 = numberOfPinsDropped;
                    this.cantPlayAnymore = true;
                }
            }
            return bonusType;
        }

        public void calculateScore()
        {
            this.Points = Frame1 + Frame2 + Bonus;
        }

    }
}