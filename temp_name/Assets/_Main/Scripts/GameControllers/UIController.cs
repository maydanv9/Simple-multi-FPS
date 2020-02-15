﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] private MenuView menuView;
    public MenuView MenuView => menuView;

    [SerializeField] private GameView gameView;
    public GameView GameView => gameView;
}
