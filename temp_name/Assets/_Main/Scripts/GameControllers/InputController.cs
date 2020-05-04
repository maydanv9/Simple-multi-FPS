using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public IMovement movementlistener;
    [SerializeField] private InputValues inputs = new InputValues();

    [System.Serializable]
    public struct InputValues
    {
        public bool isSpacePressed;
        public bool isCtrlPressed;
        public bool isShiftPressed;
        public bool alpha1;
        public bool alpha2;
        public bool alpha3;
        public bool alpha4;

        public bool isEscPressed;
        public bool isRightMousePressed;
        public bool isLeftMousePressed;

        public float mouseX;
        public float mouseY;
        public float vertical;
        public float horizontal;
    }

    public void InputUpdate()
    {
        #region KEYBOARD
        inputs.isEscPressed = Input.GetKeyDown(KeyCode.Escape);
        inputs.isCtrlPressed = Input.GetKey(KeyCode.LeftControl);
        inputs.isShiftPressed = Input.GetKey(KeyCode.LeftShift);
        inputs.isSpacePressed = Input.GetKey(KeyCode.Space);
        inputs.alpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        inputs.alpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        inputs.alpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        inputs.alpha4 = Input.GetKeyDown(KeyCode.Alpha4);
        #endregion

        #region MOUSE
        inputs.isRightMousePressed = Input.GetMouseButtonDown(Keys.Inputs.RIGHT_MOUSE_CLICKED);
        inputs.isLeftMousePressed = Input.GetMouseButtonDown(Keys.Inputs.LEFT_MOUSE_CLICKED);
        #endregion

        #region MOVEMENT
        inputs.mouseX = Input.GetAxis(Keys.Inputs.MOUSE_X);
        inputs.mouseY = Input.GetAxis(Keys.Inputs.MOUSE_Y);
        inputs.vertical = Input.GetAxis(Keys.Inputs.MOVE_VERTICAL);
        inputs.horizontal = Input.GetAxis(Keys.Inputs.MOVE_HORIZONTAL);
        #endregion

        movementlistener.UpdateAxis(inputs);
    }
    
    public InputValues GetInputValues()
    {
        return inputs;
    }
}
