using System;
using Godot;
using EndlessRunner.Objects;
using EndlessRunner.States.Player;

namespace EndlessRunner.States
{
    public class GameContext : Node2D
    {
        public IGameState gameState;        
        public Rect2 GameScreen;
        public PlayerContext Player;

        public override void _Ready()
        {
            GameScreen = GetTree().Root.GetVisibleRect();

            Player = new PlayerContext();

            Player.Size = new Vector2
            {
                x = 35f,
                y = 100f
            };

            Player.Position = new Vector2
            {
                x = (GameScreen.Size.x / 3) - Player.Size.x,
                y = GameScreen.Size.y - Player.Size.y
            };

            AddChild(Player);

            gameState = new GameStartState(this);            
        }

        public override void _Input(InputEvent @event)
        {
        }

        public override void _PhysicsProcess(float delta)
        {
            gameState.Process(delta);
        }

        public GameContext GetContext()
        {
            return this;
        }
    }
}
