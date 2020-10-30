using System;

namespace BowlingCounterApp.Core
{
    public class BowlingFrame
    {
        public int Frame1 { get; private set; } = 0;

        public int Frame2 { get; private set; } = 0;

        public int Frame3 { get; private set; } = 0;

        public int Points { get; private set; }

        private int numberOfPlays = 0;

        private bool cantPlayAnymore = false;

        public int Bonus { get; set; }

        public bool LastFrame { get; private set; }

        public BowlingFrame(bool LastFrame)
        {
            this.LastFrame = LastFrame;
        }

        public BonusType setPinsDropped(int numberOfPinsDropped)
        {
            if (numberOfPinsDropped > 10 || numberOfPinsDropped < 0)
            {
                throw new ArgumentException("Number of pins dropped must be between 0 and 10");
            }

            var bonusType = BonusType.None;

            if (numberOfPlays == 0)
            {

                if (isStrike(numberOfPinsDropped))
                {
                    bonusType = BonusType.Strike;
                    cantPlayAnymore = !LastFrame ? true : false;
                }
                else
                {
                    bonusType = BonusType.None;
                }
                numberOfPlays++;
                Frame1 = numberOfPinsDropped;
            }
            else
            {
                if (cantPlayAnymore)
                {
                    // TODO: Create new exception for running out of plays.
                    throw new InvalidOperationException("You have already ended all plays of this frame.");
                }
                else if (!LastFrame)
                {
                    if (isSpare(Frame1, numberOfPinsDropped))
                    {
                        bonusType = BonusType.Spare;
                    }
                    Frame2 = numberOfPinsDropped;
                    this.cantPlayAnymore = true;
                }
                else
                {
                    if (!cantPlayAnymore)
                    {
                        if ((isSpare(Frame1, Frame2) || isStrike(Frame1) || isStrike(Frame2)) && numberOfPlays == 2)
                        {
                            Frame3 = numberOfPinsDropped;
                            numberOfPlays++;
                            cantPlayAnymore = true;
                        }
                        else if (isStrike(numberOfPinsDropped) || isStrike(Frame1))
                        {
                            bonusType = BonusType.Strike;
                            Frame2 = numberOfPinsDropped;
                            numberOfPlays++;
                        }
                        else if (isSpare(Frame1, numberOfPinsDropped))
                        {
                            bonusType = BonusType.Spare;
                            Frame2 = numberOfPinsDropped;
                            numberOfPlays++;
                        }
                        else
                        {
                            bonusType = BonusType.None;
                            Frame2 = numberOfPinsDropped;
                            cantPlayAnymore = true;
                        }
                    }
                }
            }
            return bonusType;
        }

        public void calculateScore()
        {
            this.Points = Frame1 + Frame2 + Frame3 + Bonus;
        }

        public void resetState()
        {
            this.Frame1 = 0;
            this.Frame2 = 0;
            this.Frame3 = 0;
            this.Bonus = 0;
            this.Points = 0;
            this.cantPlayAnymore = false;
            this.numberOfPlays = 0;
        }

        public bool isStrike(int numberOfPinsDropped)
        {
            return numberOfPinsDropped == 10;
        }

        public bool isSpare(int previousFrame, int numberOfPinsDropped)
        {
            return previousFrame + numberOfPinsDropped == 10;
        }
    }
}