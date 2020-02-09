using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using System;
using System.IO;
using UnityEditor;


public class MovementController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private CharacterController playerCharacterController;

    private GameController gameController;
    private InputController.InputValues inputValues;

    private float walkValue;
    private float sprintValue;
    private float yClamp;
    private float mouseSensitivity = 100f;
    private float xRotation = 0;

    public void Init(GameController _gameController)
    {
        gameController = _gameController;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LookUpdate(InputController.InputValues _inputValues)
    {
        inputValues = _inputValues;

        float mouseY = inputValues.mouseY * mouseSensitivity * Time.deltaTime;
        float mouseX = inputValues.mouseX * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        mainCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
    }   

    public void MovementUpdate(InputController.InputValues _inputValues)
    {
        inputValues = _inputValues;

        Vector3 moveVector = playerTransform.right * inputValues.horizontal + playerTransform.forward * inputValues.vertical;
        playerCharacterController.Move(moveVector);
    }

    

    private void CheckInput()
    {
        if (inputValues.isLeftMousePressed)
        {

        }
    }
}