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
        public bool isWPressed;
        public bool isSPressed;
        public bool isAPressed;
        public bool isDPressed;
    }
    public void InputUpdate()
    {
        #region PLAYER MOVEMENT
        inputs.isWPressed = Input.GetKeyDown(KeyCode.W);
        inputs.isSPressed = Input.GetKeyDown(KeyCode.S);
        inputs.isAPressed = Input.GetKeyDown(KeyCode.A);
        inputs.isDPressed = Input.GetKeyDown(KeyCode.D);
        //ctrl,shift,space
        #endregion

        inputs.isEscPressed = Input.GetKeyDown(KeyCode.Escape);

        #region MOUSE
        inputs.isRightMousePressed = Input.GetMouseButtonDown(Keys.Inputs.RIGHT_MOUSE_CLICKED);
        inputs.isLeftMousePressed = Input.GetMouseButtonDown(Keys.Inputs.LEFT_MOUSE_CLICKED);
        #endregion

        movementlistener.UpdateAxis(inputs);
    }

    public InputValues GetInputValues()
    {
        return inputs;
    }
}
