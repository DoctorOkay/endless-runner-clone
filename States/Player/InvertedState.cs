using Godot;
using System;

namespace EndlessRunner.States.Player
{
    public class InvertedState : IPlayer
    {
        private PlayerContext _context;
        private float _fallingSpeed = 400f;

        public InvertedState(PlayerContext context)
        {
            _context = context;            
        }

        public void Process(float delta)
        {
            _context.Position = new Vector2
            {
                x = _context.Position.x,
                y = Mathf.Clamp(_context.Position.y - (_fallingSpeed * delta), _context.GameScreen.Position.y, _context.GameScreen.Size.y - _context.Size.y)
            };

            _fallingSpeed += _context.Gravity;

            if (_context.Position.y == _context.GameScreen.Position.y)
            {
                _fallingSpeed = 100f;
            }

            _context.Update();
        }

        public void HandleInput(InputEvent @event)
        {
            if (@event is InputEventKey eventKey)
            {
                if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Space)
                {
                    _context.playerState = new InvertedJumpState(_context);
                }
                if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Down)
                {
                    _context.playerState = new IdleState(_context);
                }
            }
        }
    }
}
