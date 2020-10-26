using System;

namespace BowlingCounter.Core
{
    public class BowlingFrame
    {
        public int Frame1 { get; private set; }

        public int Frame2 { get; private set; }

        public bool Strike { get; private set; }

        public bool Spare { get; private set; }

        private bool playedOnce = false;

        private bool cantPlayAnymore = false;

        public bool LastFrame { get; private set; }

        public BowlingFrame(bool LastFrame)
        {
            this.Frame1 = 0;
            this.Frame2 = 0;
            this.Strike = false;
            this.Spare = false;
            this.LastFrame = LastFrame;
        }

        public void setPinsDropped(int numberOfPinsDropped)
        {
            if (!playedOnce)
            {
                if (numberOfPinsDropped == 10)
                {
                    Strike = true;
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
                    throw new InvalidOperationException("You have already ended all plays of this frame.");
                }
                else
                {
                    if (Frame1 + numberOfPinsDropped == 10)
                    {
                        this.Spare = true;
                    }
                    Frame2 = numberOfPinsDropped;
                    this.cantPlayAnymore = true;
                }
            }
        }

    }
}