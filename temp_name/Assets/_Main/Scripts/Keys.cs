using System.Collections;
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
}
