using Godot;
using System;
using EndlessRunner.Objects;

namespace EndlessRunner.States
{
    public class RunningState : Node, IGameState
    {        
        private Vector2 _worldSpeed = new Vector2
        {
            x = -500f,
            y = 0f
        };

        private Timer _timer = new Timer();
        private static Random _random = new Random();     
        private GameContext _context;

        public RunningState(GameContext context)
        {
            _context = context;

            _timer = new Timer();
            _context.AddChild(_timer);
            _timer.Connect("timeout", this, nameof(OnTimerTimeout));
            _timer.Start((float)_random.NextDouble());
        }

        public override void _Ready()
        {            
        }

        public void OnTimerTimeout()
        {            
            Vector2 offScreen = new Vector2
            {
                x = _context.GameScreen.End.x + (_context.GameScreen.Size.x / 2),
                y = _context.GameScreen.End.y
            };

            MakeObstacle(offScreen);

            _timer.Start(Mathf.Clamp((float)_random.NextDouble() * 2, 0.5f, 2f));
        }

        public void Process(float delta)
        {
            MoveWorld(delta);
        }

        public void MakeObstacle(Vector2 posiiton)
        {
            Obstacle obstacle = new Obstacle();
            obstacle.Position = new Vector2
            {
                x = posiiton.x,
                y = posiiton.y - obstacle.Size.y
            };
            obstacle.Color = Colors.Green;
            _context.AddChild(obstacle);
        }

        public void MoveWorld(float delta)
        {
            foreach (var child in _context.GetChildren())
            {
                if (child.GetType() == typeof(Obstacle))
                {
                    Obstacle obstacle = (Obstacle)child;
                    obstacle.Move(_worldSpeed * delta);
                }
            }
        }
    }
}
