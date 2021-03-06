# Bowling Counter App 🎳

> The objective of this repository is to create an app that can count the number of points in a bowling game.

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

## Game Logic

The point system works as follows: A game is composed of 10 frames, each with two tries on dropping all pins, the score of the frame is determined by the number of pins dropped.
If the player manages to drop all pins, the score of the next two rolls will be added to the score of this frame. If a player manages to drop all pins in the second attempt a Spare will be given, so the points scored in the next roll will be added to its score.

When a player reaches the last frame if they score 2 strikes or a spare they can play one more time to add score to that frame.

## Functionality to be implemented

- [x] Calculating the score without any bonus
- [x] Calculating Strike bonuses
- [x] Calculating Spare bonuses
- [x] Implement last frame game logic
- [ ] Game logic for multiple players
- [x] Create tests to confirm all functionality works properly
- [ ] Create a Web Api so that a client interface can access logic from the server

## Steps To Generate Coverage Reports

1. Create a terminal instance in your tests project folder
2. Add the coverlet package to your project

    ``` bash
    dotnet add package coverlet.msbuild
    ```

3. Install the dotnet reportgenerator to generate HTML previews of the coverage report

    ``` bash
    dotnet tool install -g dotnet-reportgenerator-globaltool
    ```

4. Run the test command with this parameter to generate the coverage report

    ``` bash
    dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info ./BowlingCounterApp.Tests
    ```

5. Run the reportgenerator command to generate the HTML coverage report

    ``` bash
    reportgenerator -reports:./BowlingCounterApp.Tests/lcov.info -targetdir:coveragereport -reporttypes:Html
    ```

6. It is also possible to run dotnet watch to rerun tests and generate coverage whenever a new change is detected to one of the project files

    ``` bash
    dotnet watch --project BowlingCounterApp.Tests test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info
    ```

- Optional:
  If you are using Visual Studio Code I recommend using the [Coverage Gutters extension](https://marketplace.visualstudio.com/items?itemName=ryanluker.vscode-coverage-gutters) that can show you directly the coverage of your tests on the editor, if you also run the watch command it will automatically update the coverage report when the test completes.

[contributors-shield]: https://img.shields.io/github/issues/Henriqueba210/BowlingCounterApp?style=flat-square
[contributors-url]: https://github.com/Henriqueba210/BowlingCounterApp/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Henriqueba210/BowlingCounterApp?style=flat-square
[forks-url]: https://github.com/Henriqueba210/BowlingCounterApp/network
[stars-shield]: https://img.shields.io/github/stars/Henriqueba210/BowlingCounterApp?style=flat-square
[stars-url]: https://github.com/Henriqueba210/BowlingCounterApp/stargazers
[issues-shield]: https://img.shields.io/github/issues/Henriqueba210/BowlingCounterApp?style=flat-square
[issues-url]: https://github.com/Henriqueba210/BowlingCounterApp/issues
[license-shield]: https://img.shields.io/github/license/Henriqueba210/BowlingCounterApp?style=flat-square
[license-url]: https://github.com/Henriqueba210/BowlingCounterApp/blob/main/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/henrique-barros-de-almeida-1411a0177/
