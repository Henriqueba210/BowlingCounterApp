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

                if (numberOfPinsDropped == 10)
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
                    if (Frame1 + numberOfPinsDropped == 10)
                    {
                        bonusType = BonusType.Spare;
                    }
                    Frame2 = numberOfPinsDropped;
                    this.cantPlayAnymore = true;
                }
                else
                {
                    if (!cantPlayAnymore && numberOfPlays >= 1)
                    {
                        if (Frame1 + numberOfPinsDropped == 10)
                        {
                            bonusType = BonusType.Spare;
                            Frame2 = numberOfPinsDropped;
                            numberOfPlays++;
                        }
                        else if (numberOfPinsDropped == 10 || bonusType == BonusType.Strike)
                        {
                            bonusType = BonusType.Strike;
                            Frame2 = numberOfPinsDropped;
                            numberOfPlays++;
                        }
                        else if ((bonusType == BonusType.Spare || bonusType == BonusType.Strike) && numberOfPlays == 2)
                        {
                            Frame3 = numberOfPinsDropped;
                            numberOfPlays++;
                            cantPlayAnymore = true;
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
            this.Bonus = 0;
            this.Points = 0;
            this.cantPlayAnymore = false;
            this.numberOfPlays = 0;
        }
    }
}