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
        inputs.isSpacePressed = Input.GetKeyDown(KeyCode.Space);
        #endregion

        #region MOUSE
        inputs.isRightMousePressed = Input.GetMouseButton(Keys.Inputs.RIGHT_MOUSE_CLICKED);
        inputs.isLeftMousePressed = Input.GetMouseButton(Keys.Inputs.LEFT_MOUSE_CLICKED);
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
