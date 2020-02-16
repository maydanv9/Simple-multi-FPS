using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuView : BaseView {

    public IMenuView listener;
    [SerializeField] private TMP_InputField login;
    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        base.HideView();
    }

    public void SetGameState()
    {
        listener.SetGameState();
    }
}
