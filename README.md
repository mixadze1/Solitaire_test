#  ***Overview***

### Completed the test task in 2 hours. - [Solitaire_Developer_Case_Study_2.pdf](https://github.com/user-attachments/files/20658458/Solitaire_Developer_Case_Study_2.pdf)

I created a bootstrap class called "Game", which serves as the main entry point of the scene. It initializes all components when the game starts.

I implemented a "GeneratorCards" that loads prefabs from a Resources folder.

The core logic is handled in the "SpotsController". It spawns cards into "Spots", and handles adding/removing cards when they are dragged and dropped. Each spot uses a delegate callback to handle interactions when a card is dragged onto it.

I also added debug logs to make testing and debugging easier.

### I used AI to quickly generate:

- Raycast and touch input logic.

- The MoveAction class, to save time and focus on core gameplay.

## What I'd improve with more time
I'd make spots more flexible. Currently, their positions and configurations are hardcoded in the scene. It would be better to make this dynamic so we can easily adjust the number of spots and cards per spot.

I'd implement logic to transition from scene initialization to the Game class more cleanly.


https://github.com/user-attachments/assets/36f94147-ce85-4f9b-939f-aad862dc20b3

