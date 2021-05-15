using Godot;
using System;

namespace EndlessRunner.States
{
    public class GameStartState : IGameState
    {
        private GameContext _context;

        public GameStartState(GameContext context) => _context = context;

        public void Process(float delta)
        {
        }
    }
}
