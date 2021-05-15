using Godot;
using System;

namespace EndlessRunner.States.Player
{
    public interface IPlayer
    {
        void Process(float delta);
        void HandleInput(InputEvent @event);
    }
}
