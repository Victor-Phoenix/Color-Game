# Color Game

**Color Game** is a fast-paced reaction game built in Unity. Players must quickly move to the correct colored tile before time runs out. At the end of the countdown, all incorrect tiles disappear, and players standing on them are eliminated.

This was a learning-focused project where the goal was to understand Unity fundamentals by building a complete, working game loop from scratch.

---

## Gameplay Overview

- The game begins by randomly selecting a target color.
- Players have a few seconds to move to a tile of that color.
- When the timer ends, all non-matching tiles are destroyed.
- Players standing on the wrong tile are eliminated.
- The game continues until all players are eliminated or the session is reset.

---

## Key Features

- Custom player movement and controls (supports multiple players)
- Randomized tile color generation
- Round-based elimination system with timed countdown
- Modular architecture (separate GameManager, Player, Tile scripts)
- Resettable game loop and simple scene management

---

## What I Learned

This project helped me gain hands-on experience with:

- Unity’s scripting model and game loop structure
- GameObject interaction and communication
- Managing game state through timers and conditional logic
- Organizing code into reusable, maintainable components
- Refactoring logic as complexity increased

---

## Challenges and Solutions

### Game Flow Management
Initially, I struggled with controlling the game state transitions (e.g., from countdown to tile destruction to the next round). I resolved this by centralizing logic in a GameManager that handled timing, tile generation, and player resets.

### Color Detection and Matching
Color mismatches and elimination bugs were common early on. I learned how to reliably compare material colors and use tags to associate players with tile states more accurately.

### Movement During Elimination
Players could still move during the destruction phase, which created inconsistent results. I implemented a simple locking mechanism to freeze player input during critical stages.

### Code Organization
As the game grew, it became harder to test and modify. I broke large scripts into smaller components and used serialized fields to better manage object references and behaviors in the Unity Editor.

---

## Why I Stopped Here

I chose not to polish this game further. While I could have added UI, sound, animations, or a proper win condition, the goal was to understand how to structure a working Unity project. Once I had grasped the core systems, I decided to move on to more advanced challenges.

---

## Next Steps (Optional Ideas)

- Score tracking and round progression
- Improved UI and menus
- Sound effects and animations
- Networked multiplayer or AI-controlled opponents

---

## Tech Stack

- Unity Engine
- C#
- Unity Editor (2021 or later)

---

## Project Status

**Complete for learning purposes. Not under active development.**
