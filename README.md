# Bowling Counter App

> The objective of this repository is to create an app that can count the number of points in a bowling game.

## Game Logic

The point system works as follows: A game is composed of 10 frames, each with two tries on dropping all pins, the score of the frame is determined by the number of pins dropped.
If the player manages to drop all pins, the score of the next two frames will be added to the score of this frame. If a player manages to drop all pins in the second attempt a Spare will be given, so the points scored in the next frame will be added to its score.

When a player reaches the last frame if they score 2 strikes or a spare they can play one more time to add score to that frame.

## Functionality to be implemented

- [x] Calculating the score without any bonus
- [x] Calculating Strike bonuses
- [x] Calculating Spare bonuses
- [ ] Implement last frame game logic
- [ ] Game logic for multiple players
- [ ] Create tests to confirm all functionality works properly
- [ ] Create a Web Api so that a client interface can access logic from the server
