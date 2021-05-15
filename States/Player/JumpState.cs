using Godot;
using System;

namespace EndlessRunner.States.Player
{
    public class JumpState : IPlayer
    {
        public Vector2 InitialPosition;

        private PlayerContext _context;
        private float _gravity;        
        private float _jumpSpeed = 400f;        

        public JumpState(PlayerContext context)
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
                y = Mathf.Clamp(_context.Position.y - _jumpSpeed * delta, InitialPosition.y - (_context.Size.y * 1.5f), InitialPosition.y)
            };

            if (_context.Position.y == InitialPosition.y)
            {
                _context.playerState = new IdleState(_context);
            }

            _jumpSpeed -= _gravity;
            _context.Update();
        }

        public void HandleInput(InputEvent @event)
        {

        }        
    }
}
