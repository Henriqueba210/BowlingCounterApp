using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BowlingCounter.Core
{
    public class BowlingCounter
    {
        public BowlingCounter()
        {
            frames.ForEach(frame =>
            {
                Console.Write("Insira o número de pinos derrubados na primeira jogada: ");
                frame.setPinsDropped(Convert.ToInt32(Console.ReadLine()));

                Console.Write("Insira o número de pinos derrubados na segunda jogada: ");
                frame.setPinsDropped(Convert.ToInt32(Console.ReadLine()));
            });
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
    };
}