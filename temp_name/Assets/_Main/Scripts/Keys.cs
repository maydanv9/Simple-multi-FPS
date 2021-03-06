﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{    public static class Inputs
    {
        public static int LEFT_MOUSE_CLICKED = 0;
        public static int RIGHT_MOUSE_CLICKED = 1;

        public static string MOUSE_X = "Mouse X";
        public static string MOUSE_Y = "Mouse Y";
        public static string MOVE_HORIZONTAL = "Horizontal";
        public static string MOVE_VERTICAL = "Vertical";

    }
    public static class Tags
    {
        public static string DEFAULT_TAG = "Untagged";
        public static string INTERACTABLE_TAG = "Interactable";
    }

    public static class Scenes
    {
        public static string TERRAIN_SCENE = "GameTerrain";
    }
    public class PlayerStatus
    {
        public const string ANIMATION_WALKING = "WALKING";
        public const string ANIMATION_RUNNING = "RUNNING";
        public const string ANIMATION_JUMPING = "JUMPING";
        public const string ANIMATION_CROUCHING = "CROUCHING";
    }

    public class PlayerAnimation
    {
        public const string ANIMATION_SHOOT = "SHOOTING";
        public const string ANIMATION_IDLE = "IDLE";
        public const string ANIMATION_AIM = "AIM";
    }
}
