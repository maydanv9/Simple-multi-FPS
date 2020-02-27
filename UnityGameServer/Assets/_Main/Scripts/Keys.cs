using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys
{
    public const int TICKS_PER_SEC = 30; // How many ticks per second
    public const float MS_PER_TICK = 1000f / TICKS_PER_SEC; // How many milliseconds per tick

    public class Controls
    {
        public const int IS_SPACE_PPRESSED = 0;
        public const int IS_CTRL_PPRESSED = 1;
        public const int IS_SHIFT_PPRESSED = 2;
    }

    public class Animations
    {
        public const int ANIMATION_IDLE = 0;
        public const int ANIMATION_WALKING = 1;
        public const int ANIMATION_RUNNING = 2;
        public const int ANIMATION_JUMPING = 3;
        public const int ANIMATION_CROUCHING = 4;
        public const int ANIMATION_CROUCHING_IDLE = 5;
        public const int ANIMATION_CROUCHING_WALK = 6;
    }
}
