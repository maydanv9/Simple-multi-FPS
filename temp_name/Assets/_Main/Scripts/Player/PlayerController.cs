using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private MovementController movementController;
    private InputController.InputValues inputValues = new InputController.InputValues();

    public void Init()
    {
        movementController = new MovementController(this.transform, playerCamera.transform);
    }
        
    public void MyUpdate(InputController.InputValues _inputValues)
    {
        movementController.MyUpdate(_inputValues);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        SendInputToServer(_inputValues);
    }

    private void SendInputToServer(InputController.InputValues _inputValues)
    {
        bool[] _inputs = new bool[]
        {
            _inputValues.isSpacePressed,
            _inputValues.isCtrlPressed,
            _inputValues.isShiftPressed,
            _inputValues.isLeftMousePressed,
            _inputValues.isRightMousePressed,
            _inputValues.alpha1,
            _inputValues.alpha2,
            _inputValues.alpha3,
            _inputValues.alpha4,
        };

        float[] inputFloats = new float[]
        {
            _inputValues.vertical,
            _inputValues.horizontal,
        };

        ClientSend.PlayerInputs(_inputs);
        ClientSend.PlayerMovement(inputFloats);
    }
}
