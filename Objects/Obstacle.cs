using System;
using Godot;

namespace EndlessRunner.Objects
{
    public class Obstacle : Node2D
    {
        public Vector2 Size { get; set; }
        new public Vector2 Position { get; set; }
        public Color Color { get; set; } = Colors.White;

        private Vector2 _maxSize = new Vector2
        {
            x = 200f,
            y = 100f
        };

        private Vector2 _minSize = new Vector2
        {
            x = 50f,
            y = 50f
        };

        private static Random _random = new Random();

        public Obstacle()
        {
            Size = new Vector2
            {
                x = Mathf.Clamp((float)(_random.NextDouble() * 200), _minSize.x, _maxSize.x),
                y = Mathf.Clamp((float)(_random.NextDouble() * 200), _minSize.y, _maxSize.y)
            };
        }

        public override void _Draw()
        {
            DrawRect(new Rect2(Position, Size), Color);
        }

        public void Move(Vector2 speed)
        {
            Position += speed;
            
            if (Position.x + Size.x <= 0)
            {
                QueueFree();
            }

            Update();
        }
    }
}
