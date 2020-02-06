using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : BaseView {

    [SerializeField] private Text mainText;
    public IGameView listener;


    public override void ShowView()
    {
        base.ShowView();
        mainText.text = "GameView";
    }

    public override void HideView()
    {
        base.HideView();
    }

    public void SetMenuState()
    {
        listener.SetMenuState();
    }


}
