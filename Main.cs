using Godot;
using System;
using EndlessRunner.States;

namespace EndlessRunner
{
    public class Main : Node
    {
        GameContext game;

        public override void _Ready()
        {
            game = new GameContext();
            AddChild(game);
        }
    }
}