using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementController movementController = new MovementController();
    public PlayerInfoController player;

    public float sensitivity = 100f;
    public float clampAngle = 85f;

    private float verticalRotation;
    private float horizontalRotation;

    private void Start()
    {
        this.verticalRotation = transform.localEulerAngles.x;
        this.horizontalRotation = player.transform.eulerAngles.y;
    }

    public void MyUpdate(InputController.InputValues _inputValues)
    {
        Look();
        Debug.DrawRay(transform.position, transform.forward * 2, Color.red);
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
        };

        ClientSend.PlayerMovement(_inputs);
    }

    private void Look()
    {
        float _mouseVertical = -Input.GetAxis("Mouse Y");
        float _mouseHorizontal = Input.GetAxis("Mouse X");

        this.verticalRotation += _mouseVertical * sensitivity * Time.deltaTime;
        this.horizontalRotation += _mouseHorizontal * sensitivity * Time.deltaTime;

        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        this.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        this.player.transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }
}
