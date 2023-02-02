﻿namespace Utilities.States
{
    public interface ISwitchStateCondition
    {
        bool Condition { get; }
        void Activate();
        void Deactivate();
    }
}