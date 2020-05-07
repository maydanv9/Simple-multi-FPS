using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys
{
    public const int TICKS_PER_SEC = 45; // How many ticks per second
    public const float MS_PER_TICK = 1000f / TICKS_PER_SEC; // How many milliseconds per tick

    public class Controls
    {
        public const int IS_SPACE_PPRESSED = 0;
        public const int IS_CTRL_PPRESSED = 1;
        public const int IS_SHIFT_PPRESSED = 2;
        public const int IS_LMB_PPRESSED = 3;
        public const int IS_RMB_PPRESSED = 4;
        public const int IS_ALPHA_1_PRESSED = 5;
        public const int IS_ALPHA_2_PRESSED = 6;
        public const int IS_ALPHA_3_PRESSED = 7;
        public const int IS_ALPHA_4_PRESSED = 8;
    }

    public class PlayerMovement
    {
        public const string ANIMATION_WALKING = "WALKING";
        public const string ANIMATION_RUNNING = "RUNNING";
        public const string ANIMATION_JUMPING = "JUMPING";
        public const string ANIMATION_CROUCHING = "CROUCHING";
        public const string ANIMATION_IDLE = "IDLE";
    }

    public class PlayerAction
    {
        public const string ANIMATION_SHOOT = "SHOOTING";
        public const string ANIMATION_IDLE = "IDLE";
        public const string ANIMATION_AIM = "AIM";
    }

    public class PlayerWeapon
    {
        public const string WEAPON_KNIFE = "KNIFE";
        public const string WEAPON_PISTOL = "PISTOL";
        public const string WEAPON_RIFLE = "RIFLE";
        public const string WEAPON_GRENADE = "GRENADE";
    }

    public class Tags
    {
        public const string PLAYER_TAG = "Player tag";
    }
}
