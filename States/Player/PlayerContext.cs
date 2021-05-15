using Godot;
using System;

namespace EndlessRunner.States.Player
{
    public class PlayerContext : Node2D
    {
        public IPlayer playerState;

        new public Vector2 Position { get; set;}
        public Vector2 Size { get; set; }
        public Color Color { get; set; } = Colors.White;

        public float Gravity { set; get; } = 10f;
        public Rect2 GameScreen;

        public PlayerContext()
        {            
            playerState = new IdleState(this);
        }

        public override void _Ready()
        {
            GameScreen = GetTree().Root.GetVisibleRect();
        }

        public override void _Draw()
        {
            DrawRect(new Rect2(Position, Size), Color);
        }

        public override void _Input(InputEvent @event)
        {
            playerState.HandleInput(@event);
        }

        public override void _PhysicsProcess(float delta)
        {
            playerState.Process(delta);
        }
    }
}
