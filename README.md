# Monogame Breakout example in VS Code

## Resources

Ultimate guide to getting started with Monogame and VS Code:
https://www.reddit.com/r/monogame/comments/cst49i/the_ultimate_guide_to_getting_started_with/

Previous projects:
- Pong: https://github.com/laxa88/monogame-pong

## To-dos

- Block
  - [ ] lose a life on getting hit by ball
  - [ ] change sprite or color depending on life
  - [ ] invulnerable types
  - [ ] destroy on life reaching zero
  - [ ] tilemap system to allow custom levels

- Ball
  - [ ] Stick to paddle before launch
  - [ ] movement
  - [ ] bounce off paddle, walls and blocks
  - [ ] lose a life when all balls exits bottom of screen

- Paddle
  - [x] left/right movement

- Power-ups
  - [ ] reduce paddle size to 0.5
  - [ ] increase paddle size to 1.5
  - [ ] slow paddle speed to 0.25
  - [ ] increase paddle speed to 1.25
  - [ ] add ball

- UI
  - [ ] score, hi-score
  - [ ] life
  - [ ] current stage

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