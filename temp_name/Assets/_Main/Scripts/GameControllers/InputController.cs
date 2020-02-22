using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public IMovement movementlistener;
    private InputValues inputs = new InputValues();
    public struct InputValues
    {
        public bool isEscPressed;
        public bool isRightMousePressed;
        public bool isLeftMousePressed;
        public bool isCtrlPressed;
        public bool isShiftPressed;
        public bool isSpacePressed;

        public float mouseX;
        public float mouseY;
        public float vertical;
        public float horizontal;
    }
    public void InputUpdate()
    {
        #region KEYBOARD
        inputs.isEscPressed = Input.GetKeyDown(KeyCode.Escape);
        inputs.isCtrlPressed = Input.GetKeyDown(KeyCode.LeftControl);
        inputs.isShiftPressed = Input.GetKeyDown(KeyCode.LeftShift);
        inputs.isSpacePressed = Input.GetKeyDown(KeyCode.Space);
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
