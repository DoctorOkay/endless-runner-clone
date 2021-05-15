using Godot;
using System;

namespace EndlessRunner.States
{
    public interface IGameState
    {
        void Process(float detla);
    }
}
