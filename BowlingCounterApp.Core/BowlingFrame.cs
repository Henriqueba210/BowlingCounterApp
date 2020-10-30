using System;

namespace BowlingCounterApp.Core
{
    public class BowlingFrame
    {
        public int Frame1 { get; private set; } = 0;

        public int Frame2 { get; private set; } = 0;

        public int Frame3 { get; private set; } = 0;

        public int Points { get; private set; }

        public int NumberOfPlays = 0;

        private bool CantPlayAnymore = false;

        public int Bonus { get; set; }

        public BonusType BonusType { get; set; } = BonusType.None;

        public bool LastFrame { get; private set; }

        public BowlingFrame(bool LastFrame)
        {
            this.LastFrame = LastFrame;
        }

        public BonusType SetPinsDropped(int numberOfPinsDropped)
        {
            if (numberOfPinsDropped > 10 || numberOfPinsDropped < 0)
            {
                throw new ArgumentException("Number of pins dropped must be between 0 and 10");
            }

            if (NumberOfPlays == 0)
            {

                if (IsStrike(numberOfPinsDropped))
                {
                    BonusType = BonusType.Strike;
                    CantPlayAnymore = !LastFrame ? true : false;
                }
                else
                {
                    BonusType = BonusType.None;
                }
                NumberOfPlays++;
                Frame1 = numberOfPinsDropped;
            }
            else
            {
                if (CantPlayAnymore)
                {
                    // TODO: Create new exception for running out of plays.
                    throw new InvalidOperationException("You have already ended all plays of this frame.");
                }
                else if (!LastFrame)
                {
                    if (IsSpare(Frame1, numberOfPinsDropped))
                    {
                        BonusType = BonusType.Spare;
                    }
                    Frame2 = numberOfPinsDropped;
                    this.CantPlayAnymore = true;
                }
                else
                {
                    if (!CantPlayAnymore)
                    {
                        if ((IsSpare(Frame1, Frame2) || IsStrike(Frame1) || IsStrike(Frame2)) && NumberOfPlays == 2)
                        {
                            Frame3 = numberOfPinsDropped;
                            NumberOfPlays++;
                            CantPlayAnymore = true;
                        }
                        else if (IsStrike(numberOfPinsDropped) || IsStrike(Frame1))
                        {
                            BonusType = BonusType.Strike;
                            Frame2 = numberOfPinsDropped;
                            NumberOfPlays++;
                        }
                        else if (IsSpare(Frame1, numberOfPinsDropped))
                        {
                            BonusType = BonusType.Spare;
                            Frame2 = numberOfPinsDropped;
                            NumberOfPlays++;
                        }
                        else
                        {
                            BonusType = BonusType.None;
                            Frame2 = numberOfPinsDropped;
                            CantPlayAnymore = true;
                        }
                    }
                }
            }
            return BonusType;
        }

        public void CalculateScore()
        {
            this.Points = Frame1 + Frame2 + Frame3 + Bonus;
        }

        public void ResetState()
        {
            this.Frame1 = 0;
            this.Frame2 = 0;
            this.Frame3 = 0;
            this.Bonus = 0;
            this.Points = 0;
            this.BonusType = BonusType.None;
            this.CantPlayAnymore = false;
            this.NumberOfPlays = 0;
        }

        private bool IsStrike(int numberOfPinsDropped)
        {
            return numberOfPinsDropped == 10;
        }

        private bool IsSpare(int previousFrame, int numberOfPinsDropped)
        {
            return previousFrame + numberOfPinsDropped == 10;
        }
    }
}