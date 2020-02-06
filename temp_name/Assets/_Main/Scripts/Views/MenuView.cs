using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : BaseView {

    public IMenuView listener;
    
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
