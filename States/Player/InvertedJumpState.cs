using Godot;
using System;

namespace EndlessRunner.States.Player
{
    public class InvertedJumpState : IPlayer
    {
        public Vector2 InitialPosition;

        private PlayerContext _context;
        private float _gravity;
        private float _jumpSpeed = 400f;

        public InvertedJumpState(PlayerContext context)
        {
            _context = context;

            InitialPosition = _context.Position;

            _gravity = _context.Gravity;
        }

        public void Process(float delta)
        {
            _context.Position = new Vector2
            {
                x = _context.Position.x,
                y = Mathf.Clamp(_context.Position.y + _jumpSpeed * delta, InitialPosition.y, InitialPosition.y + (_context.Size.y * 1.5f))
            };

            if (_context.Position.y == InitialPosition.y)
            {
                _context.playerState = new InvertedState(_context);
            }

            _jumpSpeed -= _gravity;
            _context.Update();
        }

        public void HandleInput(InputEvent @event)
        {

        }
    }
}
