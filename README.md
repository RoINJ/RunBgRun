# Run, BG, Run!

## Overview
This is a Unity game project for Android where the player runs through a forest, avoiding obstacles and collecting points. The game includes three types of obstacles that require the player to slide, jump, or move across. The player's score is stored in Firebase, allowing for a global scoreboard. This project requires Unity 2023 for building and uses several dependencies including Zenject, Firebase, and AdMob.

## Requirements
- **Unity 2023**: This project is built using Unity 2023. Ensure you have this version installed to avoid compatibility issues.

## Dependencies

- **Zenject**: Used for dependency injection.
- **Firebase**: Utilized for authentication and real-time database functionalities.
  - Firebase Auth
  - Firebase Database
- **AdMob**: Integrated for managing advertisements in the game.

## Features

- **Platform**: Android
- **Controls**: Supports swipes and keyboard controls
- **Three Types of Obstacles**: 
  - **Slide**: Requires the player to slide under low barriers.
  - **Jump**: Requires the player to jump over hurdles.
  - **Move Across**: Requires the player to move left or right to avoid obstacles.
  
- **Scoreboard**:
  - Player scores are stored in Firebase, allowing for a global scoreboard where players can compare their scores.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---
