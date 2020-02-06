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
    private GameController gameController;
    private InputController.InputValues inputValues;

    public void Init(GameController _gameController)
    {
        gameController = _gameController;
    }

    public void MovementUpdate(InputController.InputValues inputValues)
    {
        this.inputValues = inputValues;
        CheckInput();
    }

    

    private void CheckInput()
    {
        if (inputValues.isLeftMousePressed)
        {

        }
    }
}