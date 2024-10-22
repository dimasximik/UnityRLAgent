# UnityRLAgent

### Train a Simple AI Agent in Unity Using C# and Q-Learning

**UnityRLAgent** is a straightforward AI agent for Unity that uses Reinforcement Learning (Q-Learning) to learn how to reach a target. Built entirely with C#, it requires no external AI libraries, making it easy to integrate and visualize the learning process.

## Key Features

- **Simple AI Agent**: Learn to navigate towards a stationary target using basic movements and rotations.
- **Visual Learning Process**: Watch the agent improve its behavior over time directly in the Unity scene.
- **Configurable Learning Parameters**: Easily adjust learning rate, discount factor, exploration rate, and more.
- **No External Dependencies**: Fully implemented in C# for seamless integration into your Unity projects.
- **Easy to Extend**: Simple project structure allows for easy customization and feature additions.

## Usage

- **Start Training**: Click the Play button in Unity. The agent will begin moving towards the target.
- **Adjust Parameters**: Modify the agent's learning and movement parameters in the Inspector to see how they affect training.
- **Observe Learning**: Watch as the agent gradually improves its ability to reach the target more efficiently.

## Configuration

### Agent.cs Variables

- **moveStep (float)**
  - **Description:** Distance the agent moves with each action.
  - **Impact:** Higher values speed up movement but reduce precision. Smaller values make movement more accurate but slower.

- **rotationStep (float)**
  - **Description:** Degrees the agent rotates with each action.
  - **Impact:** Larger angles allow quicker direction changes. Smaller angles provide smoother directional adjustments.

- **learningRate (float)**
  - **Description:** How much new information overrides old information.
  - **Impact:** Higher values lead to faster learning but can cause instability. Lower values make learning more stable but slower.

- **discountFactor (float)**
  - **Description:** Importance of future rewards.
  - **Impact:** Higher values encourage long-term planning. Lower values focus more on immediate rewards.

- **explorationRate (float)**
  - **Description:** Probability of choosing a random action.
  - **Impact:** Higher values promote exploration of actions. Lower values make the agent rely more on known best actions.

- **explorationDecay (float)**
  - **Description:** Rate at which exploration decreases over time.
  - **Impact:** Slower decay keeps exploration active longer, allowing the agent to continue discovering new actions.

- **minExplorationRate (float)**
  - **Description:** Minimum exploration probability.
  - **Impact:** Ensures the agent always has some chance to explore, preventing it from getting stuck on suboptimal actions.

- **maxStepsPerEpisode (int)**
  - **Description:** Maximum steps per training episode.
  - **Impact:** Limits the duration of each episode to ensure consistent training and prevent endless attempts.

- **stepDelay (float)**
  - **Description:** Delay between each training step for visualization.
  - **Impact:** Set to 0 for faster training or increase to slow down and observe the agent's behavior.

## Contributing

If you find this project useful and have ideas for improvements, feel free to open an issue or submit a pull request. Contributions are welcome!

For direct questions, reach out on Telegram: [@CodeOrDie42](https://t.me/codeOrDie42).

## License

This project is open-source and available under the [MIT License](https://opensource.org/licenses/MIT).

---

**UnityRLAgent** helps you understand the basics of Reinforcement Learning in Unity, providing a foundation for building more complex AI systems. Happy coding! 🚀
