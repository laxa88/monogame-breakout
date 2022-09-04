# Monogame Breakout example in VS Code

## Resources

Ultimate guide to getting started with Monogame and VS Code:
https://www.reddit.com/r/monogame/comments/cst49i/the_ultimate_guide_to_getting_started_with/

Previous projects:
- Pong: https://github.com/laxa88/monogame-pong

## To-dos

- Block
  - [x] lose a life on getting hit by ball
  - [x] change sprite or color depending on life
  - [ ] ~invulnerable types~
  - [x] destroy on life reaching zero
  - [x] tilemap system to allow custom levels

- Ball
  - [x] Stick to paddle before launch
  - [x] movement
  - [x] bounce off paddle, walls and blocks
  - [x] lose a life when all balls exits bottom of screen

- Paddle
  - [x] left/right movement

- ~Power-ups~
  - [ ] reduce paddle size to 0.5
  - [ ] increase paddle size to 1.5
  - [ ] slow paddle speed to 0.25
  - [ ] increase paddle speed to 1.25
  - [ ] add ball

- UI
  - [ ] ~main menu (play, reset hi-score)~
  - [ ] ~pause menu (resume game, quit)~
  - [x] score, hi-score
  - [x] life
  - [ ] ~current stage~
  - [ ] ~save hi-score and reload on game startup~
  - [ ] ~reset hi-score~
  - [ ] game over / restart game

## Compilation

Refer to `.vscode` folder

## VS code plugins

- C# `v1.25.0`
- CSharpier `v1.2.4`
- Monogame Content Builder `v0.0.4`

Additionally, if OmniSharp doesn't work, make sure the `dotnet` SDK is up-to-date. As of writing, it was `.NET 6.0 SDK (v6.0.302)`

## Settings

Additional `settings.json` config:

```json
{
  "editor.formatOnSave": true,
  "omnisharp.enableImportCompletion": true,
  "csharpier.enableDebugLogs": true,
  "[csharp]": {
    "editor.defaultFormatter": "csharpier.csharpier-vscode",
  }
}
```